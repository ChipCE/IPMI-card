#ifndef __HARDWARE_HELPER_H
#define __HARDWARE_HELPER_H
#include <Arduino.h>

//blink led 3 times
void shortBlink(int ledPin,bool signal);

//wait for button to be pressed 
bool waitForPushed(int switchPin,bool signal,int duration);

#endif
