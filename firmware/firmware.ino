#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <WiFiMan.h>
#include "HardwareController.h"
#include "IpmiSerialController.h"

#define DEBUG 1

#define CONF_PIN 14
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
String _shellControlTopic;
String _shellReportTopic;
String _ipmiControlTopic;
String _ipmiReportTopic;
String _powerStateReport;
String _connectionStatus;

//---------------FUNCTION--------------------------------------------
void callback(char *topic, byte *payload, unsigned int length);
void mqttReconnect();
bool handleHardwareCommand(char* cmd);
bool handleShellCommand(char* cmd);
bool handleIpmiCommand(char* cmd);
void updatePowerState(bool forceUpdate);

//---------------MAIN PROG-------------------------------------------
void setup()
{
  //pin mode ---
  pinMode(CONF_PIN, INPUT_PULLUP);

  //create wifi controller
  WiFiMan wman = WiFiMan();

  if(DEBUG)
  {
    Serial.begin(115200);
    wman.setDebug(true);
  }
  
  //UI config
  wman.setApName("IPMI-ConfigPortal-");
  wman.setWebUi("Config portal","Generic IPMI","Build : 20180917 1.0b","Branch : Master","ChipCE");
  wman. setHelpInfo("For more information , please visit</br><a href=\"https://github.com/ChipTechno/IPMI-card\">https://github.com/ChipTechno/IPMI-card</a>");
  hwController = HardwareController();

  //get current power state
  powerState = hwController.getPowerState();

  //set Force config 
  if(digitalRead(CONF_PIN)==LOW)
    wman.forceApMode();

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
    _shellControlTopic = String(conf.mqttSub) + "/ShellControl";
    _shellReportTopic = String(conf.mqttPub) + "/ShellReport";
    _ipmiControlTopic = String(conf.mqttSub) + "/IpmiControl";
    _ipmiReportTopic = String(conf.mqttPub) + "/IpmiReport";
    _powerStateReport = String(conf.mqttPub) + "/PowerStateReport";
    _connectionStatus = String(conf.mqttPub) + "/ConnectionStatus";

    //enable serial controller
    delay(100);
    ipmiSerialController = IpmiSerialController(_shellReportTopic,_ipmiReportTopic,&mqttClient);

    if(DEBUG)
      Serial.println("#<> Connected!!!");
  }
  else
  {
    //Connect failed or config timeout ,turnoff led indicator, put the device to sleep mode
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
  //handle hardware 
  hwController.handleHardware();
  //update power state if needed
  updatePowerState(false);
}


//-------------------------------------------
void mqttReconnect()
{
  //check connection status
  while (!mqttClient.connected())
  {
    hwController.switchLed(true);
    if (DEBUG)
      Serial.println("#<> Attempting MQTT connection...");
    // Attempt to connect
    bool connectResult;
    if(strcmp(conf.mqttUsername,"")==0)
      connectResult = mqttClient.connect(conf.mqttId,_connectionStatus.c_str(),2,true,"0");
    else
      connectResult = mqttClient.connect(conf.mqttId,conf.mqttUsername,conf.mqttPasswd,_connectionStatus.c_str(),2,true,"0");
    if (connectResult)
    {
      if (DEBUG)
        Serial.println("#<> connected to MQTT server");

      //(re)subscribe
      mqttClient.subscribe(_hardwareCotrolTopic.c_str());
      mqttClient.subscribe(_shellControlTopic.c_str());
      mqttClient.subscribe(_ipmiControlTopic.c_str());

      //send hello
      mqttClient.publish(_connectionStatus.c_str(), "1",true);
    }
    else
    {
      if (DEBUG)
      {
        Serial.print("#<> failed, rc=");
        Serial.print(mqttClient.state());
        Serial.println("try again in 5 seconds");
        // Wait 5 seconds before retrying
        delay(5000);
      }
    }
    //re-update power status
    updatePowerState(true);
  }
  if(digitalRead(CONF_PIN)==LOW)
    rebootToApMode();
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
    Serial.print("#<> Message arrived [");
    Serial.print(topic);
    Serial.print("] ");
    Serial.println(msg);
  }
  
  if(strcmp(topic,_hardwareCotrolTopic.c_str())==0)
  {
    handleHardwareCommand(msg);
    return;
  }
  
  if(strcmp(topic,_shellControlTopic.c_str())==0)
  {
    handleShellCommand(msg);
    return;
  }

  if(strcmp(topic,_ipmiControlTopic.c_str())==0)
  {
    handleIpmiCommand(msg);
    return;
  }
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
    hwController.switchPower();
    return true;
  }

  if (strcmp(cmd, "power-on") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI power-on command...");
    hwController.switchPower();
    return true;
  }
  return false;
}

bool handleShellCommand(char* cmd)
{
  //String cmdStr(cmd);
  //String msg = "Trying to execute command : " + String(cmd);
  //mqttClient.publish(_shellReportTopic.c_str(),msg.c_str());
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
      mqttClient.publish(_powerStateReport.c_str(), "1",true);
    else
      mqttClient.publish(_powerStateReport.c_str(), "0",true);
  }
}