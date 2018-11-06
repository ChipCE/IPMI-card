import sys
import os
import RPi.GPIO as gpio
import time

gpio.setmode(gpio.BCM)
# power monitor (active low)
gpio.setup(4, gpio.IN)
# relay control (active high)
gpio.setup(18, gpio.OUT)



# function define ---------------------------------------
# shutdown control
def stop(_force):
    print("Stop")
    # if the sys is already off
    if powerState() == False:
        print("System state is OFF.")
        return
    # if not , then turn it off
    if _force == true:
        print("Trying to force shutdown...")
        gpio.output(18, gpio.HIGH)
        while powerState():
            pass
        gpio.output(18, gpio.LOW)
        return
    else:
        # just click the button
        print("Trying in to stop...")
        gpio.output(18, gpio.HIGH)
        time.sleep(0.3)
        gpio.output(18, gpio.LOW)
        return

# power-on control
def start():
    if powerState() == True:
        print("System state is ON.")
        return
    else:
        print("Trying in to start...")
        gpio.output(18, gpio.HIGH)
        time.sleep(0.3)
        gpio.output(18, gpio.LOW)
        return

# restart control
def restart(_force):
    print("Trying to restart...")
    print("Step 1 of 2 : Stop...")
    stop(_force)
    print("Step 2 of 2 : Start..")
    start()
    return

# status report
def status():
    print("Status report")
    # power
    if powerState():
        print("Power state : ON")
    else:
        print("Power stste : OFF")
    # os ready
    with open("ipmi.conf") as f:
        lines = f.readlines()
    ip = lines[0]
    response = os.system("ping -c 1 " + ip)
    if response == 0:
        print("OS state : Ready")
    else:
        print("OS state : Unknown")
    return

# get power-state
def powerState():
    if(gpio.input(4) == False):
        return True
    else:
        return False

def default():
    gpio.output(18, gpio.LOW)

def pingCheck():
    try:
        output = subprocess.check_output("ping -c 1 " + ip, shell=True)
    except Exception, e:
        return False
    return True

# -----------------------------------------------------

# get force and wait flag
force = False

if (len(sys.argv) > 3):
    print("Error : Too much arguments!")
    sys.exit

if (len(sys.argv) <2 ):
    print("Error : Too few arguments")
    sys.exit

if (len(sys.argv) == 3):
    if (sys.argv[2] == "-f"):
        force = True


if (sys.argv[1] == "start"):
    start()
    sys.exit

if (sys.argv[1] == "stop"):
    stop(force)
    sys.exit
    
if (sys.argv[1] == "restart"):
    restart(force)
    sys.exit

if (sys.argv[1] == "status"):
    status()
    sys.exit

print("Error : Unknow arguments")
sys.exit

