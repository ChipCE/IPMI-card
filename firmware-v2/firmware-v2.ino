#include "HardwareController.h"
#include <WiFiMan.h>

//Global
WiFiMan wman;


void setup()
{
    //init serial , may not needed , WiFiMan will do it
    Serial.begin(115200);

    //init
    WiFiMan wman = WiFiMan(true,true,true);

    //wait for force config mode , 1 click

    //wait for rest config , hold

    //start wman
    wman.start();

    //if connected , run mqtt connect
}


//MQTT handle 
    //if serialLine -> decode it
    //if mqtt.mes -> decode it



void loop()
{
    //mqtt handle
}
