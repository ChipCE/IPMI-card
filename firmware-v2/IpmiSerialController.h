#ifndef __IPMI_SERIAL_CONTROLLER_H
#define __IPMI_SERIAL_CONTROLLER_H

#include <Arduino.h>
#include "Boot.h"

class IpmiSerialController
{
    private:
        String serialBuffer;
        bool bufferReady;
    public:
        IpmiSerialController();
        void handleSerial();
        bool executeCommand();
        String readLine();
        void executeShellCommand(char* cmd);
};


#endif

