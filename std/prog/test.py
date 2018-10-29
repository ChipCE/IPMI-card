import sys
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

print "wait : " , wait , "\nforce : ",force