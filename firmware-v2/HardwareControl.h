#ifndef __HARDWARE_CONTROL_H
#define __HARDWARE_CONTROL_H
#include <Arduino.h>

//define PIN
#define SENSE 0
#define RELAY 1

//define time threshold
#define SHUTDOWN_TIMEOUT 120
#define POWER_ON_TIMEOUT 30
#define FORCE_SHUTDOWN_TIMEOUT 15
#define BUTTON_CLICK_INTERVAL 300

class HardwareControl
{
    private:
        unsigned long startTime;
    public:
        HardwareControl();
        void nonBlockDelay(unsigned long millisecond);
        bool getPowerState();
        bool reboot();
        bool shutdown();
        bool forceShutdown();
        bool powerOn();
        void update();
        unsigned long getOnTime();
};

#endif