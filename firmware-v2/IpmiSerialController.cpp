#include "IpmiSerialController.h"

IpmiSerialController::IpmiSerialController()
{
    Serial.begin(115200);
    serialBuffer = "";
    //clear unwanted buffer
    Serial.flush();
    while (Serial.available() > 0)
        char t = Serial.read();
}

IpmiSerialController::IpmiSerialController(String shellTopic,String ipmiTopic,PubSubClient *client)
{
    //get mqtt controls
    shellReportTopic = shellTopic;
    ipmiReportTopic = ipmiTopic;
    mqttClient = client;

    //
        Serial.begin(115200);
    serialBuffer = "";
    //clear unwanted buffer
    Serial.flush();
    while (Serial.available() > 0)
        char t = Serial.read();
}

void IpmiSerialController::handleSerial()
{
    //append serial characters to line
    while (Serial.available() > 0)
    {
        char recievedChar = Serial.read();
        serialBuffer += recievedChar;

        // Process message when new line character is recieved
        if ((recievedChar == '\n') || (recievedChar == '\r'))
        {
            serialBuffer += '\0';
            executeCommand();
            //serialBuffer = "";
        }
    }
}

bool IpmiSerialController::executeCommand()
{
    if (strncmp(serialBuffer.c_str(), "#$> reboot", 10) == 0)
    {
        mqttClient->publish(ipmiReportTopic.c_str(), "Reboot...");
        serialBuffer = "";
        ESP.restart();
        return true;
    }

    if (strncmp(serialBuffer.c_str(), "#$> config", 10) == 0)
    {
        mqttClient->publish(ipmiReportTopic.c_str(), "Reboot to config mode...");
        serialBuffer = "";
        rebootToApMode();
        return true;
    }

    if (strncmp(serialBuffer.c_str(), "#$> clear", 9) == 0)
    {
        mqttClient->publish(ipmiReportTopic.c_str(), "Clear all setting and reboot...");
        serialBuffer = "";
        clear();
        ESP.restart();
        return true;
    }

    //if not , this must be result of shell command , send it to shellReportTopic
    shellCommandReport();
    return true;
}

void IpmiSerialController::shellCommandReport()
{
    //send result to shell report topic 
    mqttClient->publish(shellReportTopic.c_str(), serialBuffer.c_str());

    //clear used buffer
    serialBuffer = "";
}

void IpmiSerialController::executeShellCommand(char *cmd)
{
    Serial.println(cmd);
}