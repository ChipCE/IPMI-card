#include <WiFiMan.h>
#include "HardwareController.h"

Config conf;
HardwareController hwc;
#define CONF_PIN 14

void setup() 
{
    Serial.begin(115200);
pinMode(CONF_PIN,INPUT_PULLUP);
  //create default object
  WiFiMan wman = WiFiMan();
  wman.setDebug(true);
  
  wman.start();

  if(wman.getConfig(&conf))
  {
    //display device status
    Serial.println("Connected!!!");
  }
  hwc = HardwareController();
}

void loop() {
  //
  if(digitalRead(CONF_PIN)==LOW)
  {
      Serial.println("start--");
    hwc.powerOn();
    Serial.println("end--");
  }
  
}