#include "HardwareController.h"

HardwareController::HardwareController()
{
    //define GPIO mode here
    pinMode(SENSE,INPUT);
    pinMode(RELAY,OUTPUT);
    pinMode(LED,OUTPUT);

    //default hardware state
    digitalWrite(RELAY,LOW);
    digitalWrite(LED,LOW);

    ledStatus = false;    
    hearbeatTimer = millis();
}

void HardwareController::nonBlockDelay(unsigned long millisecond)
{
    unsigned long endTime = millis() + millisecond;
    while(millis()<endTime)
        yield();
}

bool HardwareController::getPowerState()
{
    if(digitalRead(SENSE)==HIGH)
        return false;
    return true;
}

bool HardwareController::switchPower()
{
    //push button and release
    digitalWrite(RELAY,HIGH);
    nonBlockDelay(BUTTON_CLICK_INTERVAL);
    digitalWrite(RELAY,LOW);
    return true;
}


void HardwareController::switchLed(bool status)
{
    ledStatus = status;
    if(ledStatus)
        digitalWrite(LED,HIGH);
    else
        digitalWrite(LED,LOW);
}

void HardwareController::heartBeat()
{
    if(millis()-hearbeatTimer >= 1000)
    {
        hearbeatTimer = millis();
        switchLed(!ledStatus);
    }
}

void HardwareController::handleHardware()
{
    //handle led heartbeat
    heartBeat();
}
