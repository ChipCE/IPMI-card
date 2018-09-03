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
        PubSubClient *mqttClient;
      public:
        IpmiSerialController();
        IpmiSerialController(String topic,PubSubClient *client);
        void handleSerial();
        bool executeCommand();
        void shellCommandReport();
        void executeShellCommand(char *cmd);
};

#endif

