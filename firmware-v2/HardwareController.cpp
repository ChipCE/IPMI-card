#include "HardwareController.h"

HardwareController::HardwareController()
{
    initLed();
}


void HardwareController::initLed()
{
    pinMode(LED,OUTPUT);
    LED_startTime = 0;
    LED_lastExcute = 0;
    LED_status = false;
    LEd_lastStatus = false;
    LED_duration = 0;
    LED_interval = 0;

    //set default : off
    setLed(LED_status);
}

void HardwareController::setLed(bool status)
{
    LED_status = status;
    if(status)
        digitalWrite(LED,LOW);
    else
        digitalWrite(LED,HIGH);
}

void HardwareController::blinkLed(int interval,int duration)
{
    LEd_lastStatus = LED_status;
    LED_duration = duration;
    LED_interval = interval;
    LED_startTime = millis();
    LED_lastExcute = LED_startTime;
}

void HardwareController::handleLed()
{
    if(millis()-LED_startTime < LED_duration)
    {
        if(millis()-LED_lastExcute > LED_interval)
        {
            LED_lastExcute = millis();
            flipLed();
        }

        //revert back to the last condition before timeout
        if((LED_startTime + LED_duration) - millis() <LED_interval)
            setLed(LEd_lastStatus);
    }
}

void HardwareController::flipLed()
{
    setLed(!LED_status);
}


bool HardwareController::waitButtonInput(int duration)
{
    int startTime = millis();
    while(millis()<(startTime+duration))
    {
        if(digitalRead(CONF_PIN)==HIGH)
            return true;
    }
    return false;
}


bool HardwareController::isLongPress()
{
    int startTime = millis();
    if(digitalRead(CONF_PIN)==HIGH)
    {
        while(digitalRead(CONF_PIN)==HIGH);
        if(millis()-startTime > LONG_PRESS_THRESHOLD)
            return true;
        return false;
    }
    else
        return false;
}

/* --------------------------------------------------------------- */
void HardwareController::handleHardware()
{
    handleLed();
}

