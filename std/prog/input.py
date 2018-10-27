import RPi.GPIO as gpio
import time

gpio.setmode(gpio.BCM)
gpio.setup(4, gpio.IN)

while True:
    if (gpio.input(4) == False):
        print "LOW"
    else:
        print "HIGH"
