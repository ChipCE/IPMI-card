#include "HardwareHelper.h"

void sortBlink(int ledPin,bool originalState)
{
    bool ledState = originalState;
    for(int i=1;i<6;i++)
    {
        ledState = !ledState;
        digitalWrite(ledPin,ledState);
        delay(200);
    }

    //return the original state
    digitalWrite(ledPin,originalState);
}

bool waitForPushed(int switchPin,bool signal,int duration)
{
    bool result = false;
    int startTime = millis();
    while(millis()-startTime < duration * 1000)
    {
        if(digitalRead(switchPin)== signal)
            result = true;
        yield();
    }
    return result;
}   