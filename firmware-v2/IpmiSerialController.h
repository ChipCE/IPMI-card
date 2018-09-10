#ifndef __IPMI_SERIAL_CONTROLLER_H
#define __IPMI_SERIAL_CONTROLLER_H

#include <Arduino.h>
#include <PubSubClient.h>
#include <Boot.h>

class IpmiSerialController
{
    private:
        String serialBuffer;
        String shellReportTopic;
        String ipmiReportTopic;
        PubSubClient *mqttClient;
        //Execute serial command from host (reboot,clear,config)
        bool executeCommand();
        //Report output from host to mqtt server
        void shellCommandReport();
      public:
        IpmiSerialController();
        IpmiSerialController(String shellTopic,String ipmiTopic,PubSubClient *client);
        //wait for serial input and merge chars to String
        void handleSerial();
        //Send serial comman to host
        void executeShellCommand(char *cmd);
};

#endif

