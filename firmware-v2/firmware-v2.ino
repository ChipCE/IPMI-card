#include "HardwareController.h"

HardwareController hc;

void setup()
{
    hc = HardwareController();
    Serial.begin(115200);
    hc.setLed(true);
    hc.blinkLed(200,15000);
}

void loop()
{
    
    hc.handleHardware();
}