print "stop.py :3"

import sys
import RPi.GPIO as gpio
import time

gpio.setmode(gpio.BCM)
gpio.setup(4, gpio.IN)
gpio.setup(18, gpio.OUT)

print sys.argv[0]
print len(sys.argv)
print str(sys.argv)

wait = False
force = False

if (len(sys.argv) > 3):
    print "Error : Too much arguments!"
    sys.exit

if (len(sys.argv) == 1):
    print "normal script"
    sys.exit

if (len(sys.argv) == 2):
    if (sys.argv[1] == "-w"):
        wait = True
    if (sys.argv[1] == "-f"):
        force = True

if (len(sys.argv) == 3):
    if (sys.argv[1] == "-w" or sys.argv[2] == "-w"):
        wait = True
    if (sys.argv[1] == "-f" or sys.argv[2] == "-f"):
        force = True

# try to stop 
if (gpio.input(4) == False):
    print "System is already off.Stop command will be skip."
    sys.exit

gpio.output(18, gpio.HIGH)
time.sleep(0.5)
gpio.output(18, gpio.LOW)

if (wait == True) or (force == True):
    _startTime = time.time()
    while (gpio.input(4) != True) and (time.time() - _startTime < 30):
        print "."
    if (gpio.input(4) == False):
        print "Success"
    else:
        print "timeout"

if (force == True):
    print "Trying to force shutdown"
    _startTime = time.time()
    gpio.output(18, gpio.HIGH)
    while (gpio.input(4) != True) and (time.time() - _startTime < 10):
        print "."
    if (gpio.input(4) == True):
        print "Success"
    else:
        print "timeout"



