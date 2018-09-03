#include <ESP8266WiFi.h>
#include <PubSubClient.h>
#include <WiFiMan.h>
#include "HardwareController.h"
#include "IpmiSerialController.h"

#define CONF_PIN 14
#define DEBUG 1
#define BUFFER_LENGTH 256

Config conf;
HardwareController hwController;
IpmiSerialController ipmiSerialController;
WiFiClient espClient;
PubSubClient mqttClient;

//--------------MQTT Topic-----------------------------------------
String _hardwareCotrolTopic;
String _hardwareReportTopic;
String _shellCommandTopic;
String _shellReportTopic;
String _ipmiControlTopic;
String _ipmiReportTopic;

//---------------FUNCTION--------------------------------------------
void callback(char *topic, byte *payload, unsigned int length);
void reconnect();
bool handleHardwareCommand(char* cmd);
bool handleShellCommand(char* cmd);
bool handleIpmiCommand(char* cmd);

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

  //Start Wifi manager
  wman.start();

  if (wman.getConfig(&conf))
  {
    //Connected :3
    hwController = HardwareController();

    //set MQTT Server hand callback
    mqttClient = PubSubClient(espClient);
    mqttClient.setServer(conf.mqttAddr, conf.mqttPort);
    mqttClient.setCallback(callback);

    //get mqtt topic
    _hardwareCotrolTopic = String(conf.mqttSub) + "/HardwareCotrol";
    _hardwareReportTopic = String(conf.mqttPub) + "/HardwareReport";
    _shellCommandTopic = String(conf.mqttSub) + "/ShellCommand";
    _shellReportTopic = String(conf.mqttPub) + "/ShellReport";
    _ipmiControlTopic = String(conf.mqttSub) + "/IpmiControl";
    _ipmiReportTopic = String(conf.mqttPub) + "/IpmiReport";

    //enable serial controller
    delay(100);
    ipmiSerialController = IpmiSerialController(_shellReportTopic,&mqttClient);

    if(DEBUG)
      Serial.println("Connected!!!");
  }
  else
  {
    //Connect failed or config timeout , put the device to sleep mode
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
}

//-------------------------------------------
void mqttReconnect()
{
  //check connection status
  if (!mqttClient.connected())
  {
    while (!mqttClient.connected())
    {
      if(DEBUG) 
        Serial.print("Attempting MQTT connection...");
      // Attempt to connect
      if (mqttClient.connect(conf.mqttId))
      {
        if(DEBUG) 
          Serial.println("connected to MQTT server");

        //(re)subscribe
        mqttClient.subscribe(_hardwareCotrolTopic.c_str());
        mqttClient.subscribe(_shellCommandTopic.c_str());
        mqttClient.subscribe(_ipmiControlTopic.c_str());

        //send hello 
        mqttClient.publish(_ipmiReportTopic.c_str(), "Generic IPMI : Hello, World!");
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
    }
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

  if (strcmp(cmd, "reboot") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI reboot command...");
    if(hwController.reboot())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Reboot success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Reboot failed!");
    return true;
  }

  if (strcmp(cmd, "force-shutdown") == 0)
  {
    mqttClient.publish(_hardwareReportTopic.c_str(), "Execute IPMI force-shutdown command...");
    if(hwController.forceShutdown())
      mqttClient.publish(_hardwareReportTopic.c_str(), "Force-shutdown success!");
    else
      mqttClient.publish(_hardwareReportTopic.c_str(), "Force-shutdown failed!");
    return true;
  }

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