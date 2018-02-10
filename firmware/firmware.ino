#include <FS.h>                  
#include <ESP8266WiFi.h>
#include <DNSServer.h>
#include <ESP8266WebServer.h>
#include <WiFiManagerMod.h>
#include <ArduinoJson.h>
#include <PubSubClient.h>


//reset pin , for reset setting
#define RESETPIN 14
//use to switch pc power button 
#define RELAYPIN 13
//to monitor pc state (from usb)
#define SENSEPIN 12

//delay between delay on/off (miliseconds)
#define RELAY_DELAY 100
//delay between power-state change (milisecond)
#define POWER_ON_WAIT 5000
//delay time to shutdown (milisecond)
#define SHUTDOWN_WAIT 60000
//delay time to force shutdown (milisecond)
#define FORCE_SHUTDOWN_WAIT 10000


//flag for saving data
bool shouldSaveConfig = false;

//default values
char mqtt_server[64] = "mqttserver.com";
char mqtt_port[8] = "1883";
char mqtt_user[16] = "user";
char mqtt_pass[16] = "password";
char mqtt_sub_topic[64] = "sub-topic";
char mqtt_pub_topic[64] = "pub-topic";
char mqtt_id[32] = "IPMI-ESP8266-based";

//version
char version[32] = "Ver 1.02b";


WiFiClient espClient;
PubSubClient client(espClient);

//callback notifying us of the need to save config
void saveConfigCallback () 
{
  Serial.println("# Set shouldSaveConfig = true");
  shouldSaveConfig = true;
}



void callback(char* topic, byte* payload, unsigned int length) 
{
  // Conver the incoming byte array to a string
  payload[length] = '\0'; // Null terminator used to terminate the char array
  String message = (char*)payload;
  unsigned long start;

  Serial.print("Message arrived on topic: [");
  Serial.print(topic);
  Serial.print("], ");
  Serial.println(message);

  if(message == "SystemReport")
  {
    client.publish(mqtt_pub_topic, version);
    //client.publish(mqtt_pub_topic,WiFi.localIP());
    //Serial.print(sensors.getTempCByIndex(0));
  }

  if(message == "power-on")
  {
    //read current pc power state
    if(digitalRead(SENSEPIN)==LOW)
    {
      //power is off 
      client.publish(mqtt_pub_topic, "Trying to send power on signal ! Please wait ...");
      //then send the power on signal
      digitalWrite(RELAYPIN,HIGH);
      delay(RELAY_DELAY);
      digitalWrite(RELAYPIN,LOW);
      //wait for pc to power up
      start = millis();
      while ((millis()-start)<POWER_ON_WAIT && digitalRead(SENSEPIN)!=HIGH);
      //re-check power state
      if(digitalRead(SENSEPIN)==HIGH)
        client.publish(mqtt_pub_topic, "Power-on successed!");
      else
        client.publish(mqtt_pub_topic, "Error : Power-on failed");
    }
    else
    {
      client.publish(mqtt_pub_topic, "Warning : PC is already on! Command will be skipped.");
    }
  }

  if(message == "shutdown")
  {
    //read current pc power state
    if(digitalRead(SENSEPIN)==HIGH)
    {
      //power is on 
      client.publish(mqtt_pub_topic, "Trying to send shutdown signal ! Please wait ...");
      //then send the power off signal
      digitalWrite(RELAYPIN,HIGH);
      delay(RELAY_DELAY);
      digitalWrite(RELAYPIN,LOW);
      //wait for pc to power down
      start = millis();
      while ((millis()-start)<SHUTDOWN_WAIT && digitalRead(SENSEPIN)!=LOW);
      //re-check power state
      if(digitalRead(SENSEPIN)==LOW)
        client.publish(mqtt_pub_topic, "Shutdown successed!");
      else
        client.publish(mqtt_pub_topic, "Error : Timeout , cannot shutdown pc !");
    }
    else
    {
      client.publish(mqtt_pub_topic, "Warning : PC is already off! Command will be skipped.");
    }
  }

  if(message == "force-shutdown")
  {
    //read current pc power state
    if(digitalRead(SENSEPIN)==HIGH)
    {
      //power is on 
      client.publish(mqtt_pub_topic, "Trying to send force shutdown signal ! Please wait ...");
      //then hold the power button
      digitalWrite(RELAYPIN,HIGH);
      //wait for pc to power down
      start = millis();
      while ((millis()-start)<FORCE_SHUTDOWN_WAIT && digitalRead(SENSEPIN)!=LOW);
      //release the power button
      digitalWrite(RELAYPIN,LOW);

      //re-check power state
      if(digitalRead(SENSEPIN)==LOW)
        client.publish(mqtt_pub_topic, "Force shutdown successed!");
      else
        client.publish(mqtt_pub_topic, "Error : Timeout , cannot force shutdown pc !");
    }
    else
    {
      client.publish(mqtt_pub_topic, "Warning : PC is already off! Command will be skipped.");
    }
  }

  if(message == "restart")
  {
    //read current pc power state
    if(digitalRead(SENSEPIN)==HIGH)
    {
      //power is on 
      client.publish(mqtt_pub_topic, "Trying to send restart signal ! Please wait ...");
     
      //step 1 : shutdown
      client.publish(mqtt_pub_topic, "Trying to restart ! [1/2] Waitting for pc to shutdown...");
       //then send the power off signal
      digitalWrite(RELAYPIN,HIGH);
      delay(RELAY_DELAY);
      digitalWrite(RELAYPIN,LOW);
      //wait for pc to power down
      start = millis();
      while ((millis()-start)<SHUTDOWN_WAIT && digitalRead(SENSEPIN)!=LOW);
      //re-check power state
      if(digitalRead(SENSEPIN)==HIGH)
      {
        client.publish(mqtt_pub_topic, "Error : Timeout , cannot shutdown pc !");
        return;
      }

      //step 2 : turn-on
      client.publish(mqtt_pub_topic, "Trying to restart ! [2/2] Waitting for pc to power-on...");
      //then send the power on signal
      digitalWrite(RELAYPIN,HIGH);
      delay(RELAY_DELAY);
      digitalWrite(RELAYPIN,LOW);
      //wait for pc to power on
      start = millis();
      while ((millis()-start)<POWER_ON_WAIT && digitalRead(SENSEPIN)!=HIGH);
      //re-check power state
      if(digitalRead(SENSEPIN)==HIGH)
        client.publish(mqtt_pub_topic, "Restart successed!");
      else
        client.publish(mqtt_pub_topic, "Error : Cannot restart pc !");
    }
    else
    {
      client.publish(mqtt_pub_topic, "Warning : PC is off! Restart command will be skipped.");
    }
  }
}


void setup() 
{
  // put your setup code here, to run once:

  //set mode for reset pin (pull-up)
  pinMode(RESETPIN,INPUT);
  //set mode for sense pin (pull-up)
  pinMode(SENSEPIN,INPUT);
  //set mode for relay pin
  pinMode(RELAYPIN,OUTPUT);
  
  Serial.begin(115200);
  Serial.println();
  Serial.println("Startingup....");

  WiFiManager wifiManager;
  
  //reset ap and SPIFFS
  if(digitalRead(RESETPIN)==LOW)
  {
    Serial.println("# Reset Ap setting ...");
    wifiManager.resetSettings();
    SPIFFS.format();
  }

  //parse version infor to portal
  wifiManager.setVersion(version);

  //read configuration from FS json
  Serial.println("# Mounting FS...");

  if (SPIFFS.begin()) 
  {
    Serial.println("# Mounted file system");
    if (SPIFFS.exists("/config.json")) 
    {
      //file exists, reading and loading
      Serial.println("# Reading config file");
      File configFile = SPIFFS.open("/config.json", "r");
      if (configFile) 
      {
        Serial.println("# Opened config file");
        size_t size = configFile.size();
        // Allocate a buffer to store contents of the file.
        std::unique_ptr<char[]> buf(new char[size]);

        configFile.readBytes(buf.get(), size);
        DynamicJsonBuffer jsonBuffer;
        JsonObject& json = jsonBuffer.parseObject(buf.get());
        json.printTo(Serial);
        if (json.success()) {
          Serial.println("\n# parsed json");
          strcpy(mqtt_server, json["mqtt_server"]);
          strcpy(mqtt_port, json["mqtt_port"]);
          strcpy(mqtt_user, json["mqtt_user"]);
          strcpy(mqtt_pass, json["mqtt_pass"]);
          strcpy(mqtt_sub_topic, json["mqtt_sub_topic"]);
          strcpy(mqtt_pub_topic, json["mqtt_pub_topic"]);
          strcpy(mqtt_id, json["mqtt_id"]);
        } 
        else 
        {
          Serial.println("# Failed to load json config");
        }
      }
    }
  } 
  else 
  {
    Serial.println("# Failed to mount FS");
  }
  //end read



  // The extra parameters
  WiFiManagerParameter custom_mqtt_server("server", "mqtt server", "", 63);
  WiFiManagerParameter custom_mqtt_port("port", "port", "1883", 7," type='number'");
  WiFiManagerParameter custom_mqtt_user("user", "mqtt user", "", 15);
  WiFiManagerParameter custom_mqtt_pass("pass", "mqtt pass", "", 15," type='password'");
  WiFiManagerParameter custom_mqtt_sub_topic("sub", "subscribe topic", "", 63);
  WiFiManagerParameter custom_mqtt_pub_topic("pub", "publish topic", "", 63);
  WiFiManagerParameter custom_mqtt_id("id", "mqtt id", mqtt_id, 31);

  //Custom text parameters
  WiFiManagerParameter custom_text_mqtt("<h2>MQTT Setting</h2>");

  //set config save notify callback
  wifiManager.setSaveConfigCallback(saveConfigCallback);

  //set static ip
  //  wifiManager.setSTAStaticIPConfig(IPAddress(10,0,1,99), IPAddress(10,0,1,1), IPAddress(255,255,255,0));
  
  //add parameters to wifiManager
  wifiManager.addParameter(&custom_text_mqtt);
  wifiManager.addParameter(&custom_mqtt_server);
  wifiManager.addParameter(&custom_mqtt_port);
  wifiManager.addParameter(&custom_mqtt_user);
  wifiManager.addParameter(&custom_mqtt_pass);
  wifiManager.addParameter(&custom_mqtt_sub_topic);
  wifiManager.addParameter(&custom_mqtt_pub_topic);
  wifiManager.addParameter(&custom_mqtt_id);

  //set minimum quality of signal so it ignores AP's under that quality , defaults to 8%
  //wifiManager.setMinimumSignalQuality();
  
  //sets timeout until configuration portal gets turned off ,useful to make it all retry or go to sleep ,in seconds
  //wifiManager.setTimeout(300);

  //fetches ssid and pass and tries to connect
  //if it does not connect it starts an access point with the specified name
  //here  "AutoConnectAP"
  //and goes into a blocking loop awaiting configuration
  if (!wifiManager.autoConnect("ESP8266", "password")) 
  {
    Serial.println("# Failed to connect and hit timeout");
    delay(3000);
    //reset and try again, or maybe put it to deep sleep
    ESP.reset();
    delay(5000);
  }

  //if you get here you have connected to the WiFi
  Serial.println("# Connected !");

  //read updated parameters
  strcpy(mqtt_server, custom_mqtt_server.getValue());
  strcpy(mqtt_port, custom_mqtt_port.getValue());
  strcpy(mqtt_user, custom_mqtt_user.getValue());
  strcpy(mqtt_pass, custom_mqtt_pass.getValue());
  strcpy(mqtt_sub_topic, custom_mqtt_sub_topic.getValue());
  strcpy(mqtt_pub_topic, custom_mqtt_pub_topic.getValue());
  strcpy(mqtt_id, custom_mqtt_id.getValue());

  //display debug parameters
  Serial.println("#DEBUG : Updated parameters");
  Serial.print("\tMQTT Server :");
  Serial.println(mqtt_server);
  Serial.print("\tMQTT Port :");
  Serial.println(mqtt_port);
  Serial.print("\tMQTT User :");
  Serial.println(mqtt_user);
  Serial.print("\tMQTT Password :");
  Serial.println(mqtt_pass);
  Serial.print("\tMQTT Subscribe topic :");
  Serial.println(mqtt_sub_topic);
  Serial.print("\tMQTT Publish topic :");
  Serial.println(mqtt_pub_topic);
  Serial.print("\tMQTT Id :");
  Serial.println(mqtt_id);

  //save the custom parameters to FS
  if (shouldSaveConfig) 
  {
    Serial.println("# Saving config...");
    DynamicJsonBuffer jsonBuffer;
    JsonObject& json = jsonBuffer.createObject();
    json["mqtt_server"] = mqtt_server;
    json["mqtt_port"] = mqtt_port;
    json["mqtt_user"] = mqtt_user;
    json["mqtt_pass"] = mqtt_pass;
    json["mqtt_sub_topic"] = mqtt_sub_topic;
    json["mqtt_pub_topic"] = mqtt_pub_topic;
    json["mqtt_id"] = mqtt_id;

    File configFile = SPIFFS.open("/config.json", "w");
    if (!configFile) 
    {
      Serial.println("# Failed to open config file for writing");
    }

    json.printTo(Serial);
    json.printTo(configFile);
    configFile.close();
    //end save
    Serial.println("# Save successed!");
  }

  Serial.print("# Local ip : ");
  Serial.println(WiFi.localIP());

  client.setServer(mqtt_server, atoi( mqtt_port ));
  client.setCallback(callback);
}


void reconnect() 
{
  // Loop until we're reconnected
  while (!client.connected()) 
  {
    Serial.println("# Attempting MQTT connection...");
    // Attempt to connect
    // If you do not want to use a username and password, change next line to
    // if (client.connect("ESP8266Client")) {
    if (client.connect(mqtt_id, mqtt_user, mqtt_pass)) 
    {
      Serial.println("# Connected to MQTT server");
      //subscribe
      client.subscribe(mqtt_sub_topic);
    } 
    else 
    {
      Serial.print("\tFailed, rc=");
      Serial.print(client.state());
      Serial.println("\tTry again in 5 seconds");
      // Wait 5 seconds before retrying
      delay(5000);
    }
  }
}



void loop() 
{
  // put your main code here, to run repeatedly:


  //MQTT connect
  if (!client.connected()) 
  {
    reconnect();
  }
  client.loop();
  
  //Serial.println("publish new value...");
  //client.publish(mqtt_pub_topic,"test Value", true);
  delay(5000);
}
