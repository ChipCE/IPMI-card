#include "HardwareController.h"

HardwareController::HardwareController()
{
    //define GPIO mode here
    pinMode(SENSE,INPUT);
    pinMode(RELAY,OUTPUT);
    pinMode(LED,OUTPUT);

    //default relay state
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

bool HardwareController::reboot()
{
    //if pc off, just turn it on
    if(!getPowerState())
        return powerOn();
    //if pc is on , shutdown it and re-power-on
    if(shutdown())
        return powerOn();
    else
        return false;
}


bool HardwareController::shutdown()
{
    if(!getPowerState())
        return false;
    //push button and release
    digitalWrite(RELAY,HIGH);
    nonBlockDelay(BUTTON_CLICK_INTERVAL);
    digitalWrite(RELAY,LOW);
    return true;
}


bool HardwareController::forceShutdown()
{
    if(!getPowerState())
        return true;
    unsigned long endTime = millis() + FORCE_SHUTDOWN_TIMEOUT*1000;
    digitalWrite(RELAY,HIGH);
    while(millis()<endTime && getPowerState())
        yield();
    digitalWrite(RELAY,LOW);
    return !getPowerState();
}


bool HardwareController::powerOn()
{
    if(getPowerState())
        return false;
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