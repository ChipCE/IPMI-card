#ifndef __HARDWARE_CONTROLLER_H
#define __HARDWARE_CONTROLLER_H

#include <Arduino.h>

#define LED 13 //led is pull down on pin 2 
#define CONF_PIN 15 //config pin is on pin 15 , pull down , only usable after boot 
#define LONG_PRESS_THRESHOLD 5000

class HardwareController
{
    private:
        //led control
        bool LEd_lastStatus = false;
        int LED_startTime;
        int LED_lastExcute;
        bool LED_status;
        int LED_duration;
        int LED_interval;

        void initLed();
        void flipLed();

    public:
        HardwareController();
        void blinkLed(int interval,int duration);
        void setLed(bool status);
        void handleHardware();

        void handleLed();

        //wait for config button , this will block the main thread
        bool waitButtonInput(int duration);
        //wait for longpress , this will not block the main thread if not triggered
        bool isLongPress();

};
#endif