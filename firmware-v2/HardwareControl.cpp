#include "HardwareControl.h"

HardwareControl::HardwareControl()
{
    //define GPIO mode here
    pinMode(SENSE,INPUT);
    pinMode(RELAY,OUTPUT);

    //default relay state
    digitalWrite(RELAY,LOW);

    //reset onTime
    onTime = 0;
}

void HardwareControl::nonBlockDelay(int millisecond)
{
    unsigned long endTime = millis() + millisecond;
    while(millis()<endTime)
        yield();
}

bool HardwareControl::getPowerState()
{
    if(digitalRead(SENSE)==HIGH)
        return false;
    return true;
}

bool HardwareControl::reboot()
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


bool HardwareControl::shutdown()
{
    if(!getPowerState())
        return true;
    //push button and release
    unsigned long endTime = millis() + BUTTON_CLICK_INTERVAL*1000;
    digitalWrite(RELAY,HIGH);
    while(millis()<endTime)
        yield();
    digitalWrite(RELAY,LOW);
    //wait for system to shutdown
    endTime = millis() + SHUTDOWN_TIMEOUT*1000;
    while(millis()<endTime && getPowerState())
        yield();
    return !getPowerState();
}


bool HardwareControl::forceShutdown()
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


bool HardwareControl::powerOn()
{
    if(getPowerState())
        return true;
    //push button and release
    unsigned long endTime = millis() + BUTTON_CLICK_INTERVAL*1000;
    digitalWrite(RELAY,HIGH);
    while(millis()<endTime)
        yield();
    digitalWrite(RELAY,LOW);
    //wait for system to startup
    endTime = millis() + POWER_ON_TIMEOUT*1000;
    while(millis()<endTime && !getPowerState())
        yield();
    return getPowerState();
}

void HardwareControl::update()
{
    if(getPowerState())
    {
        if(startTime == 0)
            startTime = millis();
    }
    else
        startTime = 0;
}


unsigned long HardwareControl::getOnTime()
{
    if(startTime == 0)
        return 0;
    return (millis()-startTime)/1000;
}

