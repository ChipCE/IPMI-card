import sys
import RPi.GPIO as gpio
import time

gpio.setmode(gpio.BCM)
# power monitor (active low)
gpio.setup(4, gpio.IN)
# relay control (active high)
gpio.setup(18, gpio.OUT)

# shutdown control
def stop(_wait, _force):
    print "stop"

# power-on control
def start(_wait):
    print "start"

# restart control
def restart(_force):
    print "restart"

# status report
def status():
    print "Status report"

# get force and wait flag
wait = False
force = False

if (len(sys.argv) > 4):
    print "Error : Too much arguments!"
    sys.exit

if (len(sys.argv) <2 ):
    print "Error : Too few arguments"
    sys.exit

if (len(sys.argv) == 3):
    if (sys.argv[2] == "-w"):
        wait = True
    if (sys.argv[2] == "-f"):
        force = True

if (len(sys.argv) == 4):
    if (sys.argv[2] == "-w" or sys.argv[3] == "-w"):
        wait = True
    if (sys.argv[2] == "-f" or sys.argv[3] == "-f"):
        force = True

if (sys.argv[2] == "start"):
    start(wait)
    sys.exit

if (sys.argv[2] == "stop"):
    stop(wait, force)
    sys.exit
    
if (sys.argv[2] == "restart"):
    restart(force)
    sys.exit

if (sys.argv[2] == "status"):
    restart(force)
    sys.exit

print "Error : Unknow arguments"

