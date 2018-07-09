#include <PubSubClient.h>
#include "HardwareHelper.h"
#include <WiFiMan.h>

#define SWITCH 0

//Global
WiFiMan wman;
WiFiClient espClient;
PubSubClient mqttClient(espClient);


void connectMqtt(String id,String user,String passwd)
{
  // Loop until we're reconnected
    while (!mqttClient.connected()) 
    {
        if (mqttClient.connect(id.c_str(),user.c_str(),passwd.c_str()))
            break;
        delay(5000);
    }
}


void setup()
{
    //init
    WiFiMan wman = WiFiMan(true,true,true);

    //wait for config reset button 
    if(waitForPushed(SWITCH,LOW,5))
        wman.deleteConfig();

    //wait for force config mode button
    if(waitForPushed(SWITCH,LOW,5))
        wman.forceApMode();

    //start wman
    wman.start();

    if(wman.isConnected())
    {
        mqttClient.setServer(wman.getMqttServerAddr().c_str(), wman.getMqttPort());
        mqttClient.setCallback(callback);

        connectMqtt(wman.getMqttId(),wman.getMqttUsername(),wman.getMqttServerPasswd());
        mqttClient.publish(wman.getMqttPub().c_str(), "hello world");
        mqttClient.subscribe(wman.getMqttSub().c_str());
    }

    //if connected , run mqtt connect
}


//MQTT handle 
void callback(char* topic, byte* payload, unsigned int length) 
{
    payload[length] = '\0';

    //decode json 
    DynamicJsonBuffer jsonBuffer;
    JsonObject& json = jsonBuffer.parseObject(payload);
    if(json.success())
    {
        String command = json["command"].as<String>();
        String args = json["args"].as<String>();

        if(command == "status")
        {

        }
        else if(command == "reboot")
        {
            ESP.restart();

        }
        else if(command == "clear")
        {
            wman.deleteConfig();
            ESP.restart();

        }
        else if(command == "save")
        {
            if(wman.setJsonConfig(args))
                ESP.restart();

        }
        else if(command = "hardware")
        {
            //hardware control 
            if(args == "reboot");
            if(args == "shutdown");
            if(args == "power-on");
            if(args == "force-shutdown");
        }
        else if(command = "shell")
        {
            wman.handleSerial(args);
        }
    }
    else
    {
        //invalid format
    }

}


void loop()
{
    mqttClient.loop();
    wman.handleSerial();
}
