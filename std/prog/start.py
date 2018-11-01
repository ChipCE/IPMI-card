print "start.py :3"

import RPi.GPIO as gpio
import time
import sys 

gpio.setmode(gpio.BCM)
gpio.setup(4, gpio.IN)
gpio.setup(18, gpio.OUT)

if (gpio.input(4) == True):
    print "System is already on.Start command will be skip."
    sys.exit

gpio.output(18, gpio.HIGH)
time.sleep(0.5)
gpio.output(18, gpio.LOW)

# wait for system up
if (len(sys.argv) == 2):
    if (sys.argv[1] == "-w"):
        _startTime = time.time()
        while (gpio.input(4) != False) and (time.time() - _startTime < 30):
            print "."
        if (gpio.input(4) == False):
            print "Success"
        else:
            print "timeout"