#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <WiFiMan.h>
#include "HardwareController.h"
#include "IpmiSerialController.h"

#define CONF_PIN 14
#define DEBUG 1
#define BUFFER_LENGTH 256

//Controller
Config conf;
HardwareController hwController;
IpmiSerialController ipmiSerialController;
WiFiClient espClient;
PubSubClient mqttClient;

//Global var
bool powerState;

//--------------MQTT Topic-----------------------------------------
String _hardwareCotrolTopic;
String _hardwareReportTopic;
String _shellCommandTopic;
String _shellReportTopic;
String _ipmiControlTopic;
String _ipmiReportTopic;
String _powerStateReport;
String _connectionStatus;

//---------------FUNCTION--------------------------------------------
void callback(char *topic, byte *payload, unsigned int length);
void reconnect();
bool handleHardwareCommand(char* cmd);
bool handleShellCommand(char* cmd);
bool handleIpmiCommand(char* cmd);
void updatePowerState(bool forceUpdate);

//---------------MAIN PROG-------------------------------------------
void setup()
{
  if(DEBUG)
    Serial.begin(115200);

  //pin mode ---
  pinMode(CONF_PIN, INPUT_PULLUP);

  //create default object
  WiFiMan wman = WiFiMan();
  wman.setDebug(true);
  hwController = HardwareController();

  //get current power state
  powerState = hwController.getPowerState();

  //set status led ON and Start Wifi manager
  hwController.switchLed(true);
  wman.start();

  if (wman.getConfig(&conf))
  {
    //Connected :3
    //set MQTT Server hand callback
    mqttClient = PubSubClient(espClient);
    mqttClient.setServer(conf.mqttAddr, conf.mqttPort);
    mqttClient.setCallback(callback);

    //get mqtt topic
    _hardwareCotrolTopic = String(conf.mqttSub) + "/HardwareControl";
    _hardwareReportTopic = String(conf.mqttPub) + "/HardwareReport";
    _shellCommandTopic = String(conf.mqttSub) + "/ShellCommand";
    _shellReportTopic = String(conf.mqttPub) + "/ShellReport";
    _ipmiControlTopic = String(conf.mqttSub) + "/IpmiControl";
    _ipmiReportTopic = String(conf.mqttPub) + "/IpmiReport";
    _powerStateReport = String(conf.mqttPub) + "/PowerStateReport";
    _connectionStatus = String(conf.mqttPub) + "/ConnectionStatus";

    //enable serial controller
    delay(100);
    ipmiSerialController = IpmiSerialController(_shellReportTopic,_ipmiReportTopic,&mqttClient);

    if(DEBUG)
      Serial.println("Connected!!!");
  }
  else
  {
    //Connect failed or config timeout , put the device to sleep mode
    hwController.switchLed(false);
    ESP.deepSleep(0);

  }
}



void loop()
{
  //check for Force-config-button
  if (digitalRead(CONF_PIN) == LOW)
    rebootToApMode();
  //re-connect to mqtt server if needed
  mqttReconnect();
  //handle mqtt client
  mqttClient.loop();
  //handle serial
  ipmiSerialController.handleSerial();
  //blink status led
  hwController.heartBeat();
  //update power state
  updatePowerState(false);
}


//-------------------------------------------
void mqttReconnect()
{
  //_connectionStatus
  //check connection status
  while (!mqttClient.connected())
  {
    hwController.switchLed(true);
    if (DEBUG)
      Serial.print("Attempting MQTT connection...");
    // Attempt to connect
    bool connectResult;
    if(strcmp(conf.mqttUsername,"")==0)
      connectResult = mqttClient.connect(conf.mqttId,_connectionStatus.c_str(),2,true,"Offline");
    else
      connectResult = mqttClient.connect(conf.mqttId,conf.mqttUsername,conf.mqttPasswd,_connectionStatus.c_str(),2,true,"Offline");
    if (connectResult)
    {
      if (DEBUG)
        Serial.println("connected to MQTT server");

      //(re)subscribe
      mqttClient.subscribe(_hardwareCotrolTopic.c_str());
      mqttClient.subscribe(_shellCommandTopic.c_str());
      mqttClient.subscribe(_ipmiControlTopic.c_str());

      //send hello
      mqttClient.publish(_connectionStatus.c_str(), "Online",true);
    }
    else
    {
      if (DEBUG)
      {
        Serial.print("failed, rc=");
        Serial.print(mqttClient.state());
        Serial.println(" try again in 5 seconds");
        // Wait 5 seconds before retrying
        delay(5000);
      }
    }
    //re-update power status
    updatePowerState(true);
  }
}

void callback(char *topic, byte *payload, unsigned int length)
{
  //create copy of playload
  char msg[BUFFER_LENGTH];
  if(length<BUFFER_LENGTH)
  {
    for(int i=0;i<length;i++)
      msg[i] = (char)payload[i];
    msg[length] = '\0';
  }
  else
  {
    for(int i=0;i<BUFFER_LENGTH-1;i++)
      msg[i] = (char)payload[i];
    msg[BUFFER_LENGTH-1] = '\0';
  }

  if(DEBUG)
  {
    Serial.print("Message arrived [");
    Serial.print(topic);
    Serial.print("] ");
    Serial.println(msg);
  }
  
  if(strcmp(topic,_hardwareCotrolTopic.c_str())==0)
    handleHardwareCommand(msg);
  
  if(strcmp(topic,_shellCommandTopic.c_str())==0)
    handleShellCommand(msg);

  if(strcmp(topic,_ipmiControlTopic.c_str())==0)
    handleIpmiCommand(msg);
}


bool handleHardwareCommand(char* cmd)
{
  if (strcmp(cmd, "status") == 0)
  {
    //report device status here
    updatePowerState(true);
    return true;
  }

  if (strcmp(cmd, "shutdown") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI shutdown command...");
    if(hwController.shutdown())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Shutdown success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Shutdown failed!");
    return true;
  }

  /*
  if (strcmp(cmd, "reboot") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI reboot command...");
    if(hwController.reboot())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Reboot success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Reboot failed!");
    return true;
  }
  */

  /*
  if (strcmp(cmd, "force-shutdown") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI force-shutdown command...");
    if(hwController.forceShutdown())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Force-shutdown success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Force-shutdown failed!");
    return true;
  }
  */
 
  if (strcmp(cmd, "power-on") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI power-on command...");
    if(hwController.powerOn())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Power-on success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Power-on failed!");
    return true;
  }

  return false;
}

bool handleShellCommand(char* cmd)
{
  mqttClient.publish(_shellReportTopic.c_str(), "Trying to execute command : ");
  mqttClient.publish(_shellReportTopic.c_str(), cmd);
  ipmiSerialController.executeShellCommand(cmd);
  return true;
}

bool handleIpmiCommand(char* cmd)
{
  if(strcmp(cmd,"reboot")==0)
  {
    mqttClient.publish(_ipmiReportTopic.c_str(), "IPMI : Reboot...");
    reboot();
    return true;
  }

  if(strcmp(cmd,"clear")==0)
  {
    mqttClient.publish(_ipmiReportTopic.c_str(), "IPMI : Clear al setting and reboot...");
    clear();
    return true;
  }

  if(strcmp(cmd,"config")==0)
  {
    mqttClient.publish(_ipmiReportTopic.c_str(), "IPMI : Reboot to config mode...");
    rebootToApMode();
    return true;
  }

  return true;
}

void updatePowerState(bool forceUpdate)
{
  bool currentPowerState = hwController.getPowerState();
  if( (powerState != currentPowerState) || forceUpdate )
  {
    powerState = currentPowerState;
    if(powerState)
      mqttClient.publish(_powerStateReport.c_str(), "1");
    else
      mqttClient.publish(_powerStateReport.c_str(), "0");
  }
}