#ifndef __HARDWARE_CONTROLLER_H
#define __HARDWARE_CONTROLLER_H
#include <Arduino.h>

//define PIN
#define SENSE 13
#define RELAY 12

//define time threshold
#define SHUTDOWN_TIMEOUT 120
#define POWER_ON_TIMEOUT 30
#define FORCE_SHUTDOWN_TIMEOUT 15
#define BUTTON_CLICK_INTERVAL 300

class HardwareController
{
    private:
        unsigned long startTime;
    public:
        HardwareController();
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