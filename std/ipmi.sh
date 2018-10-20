# var
version="1.0 alpha 1018-10-21"

# function
ipmi-help () {
    echo "Generic IPMI std $version"
    echo "usage : ipmi [help] [version] [status] [shell] [power-on] [power-off] [reboot] [force-shutdown]"
    echo -e "\tTest"
}

ipmi-version () {
    echo $version
}



# main program
echo "#DEBUG arg1 = $1"
# check if the first arg is empty
if [[ -z "$1" ]]; then
   ipmi-help
   exit 0
else
    # open ssh connection
    if [ "$1" = "shell" ]; then
        host=`cat ipmi.conf`
        if [ "$host" = "" ]; then
            echo "not configured"
        else
            echo "execute ssh $host"
            ssh $host
        fi
        exit 0
    fi

    # handle status report
    if [ "$1" = "status" ]; then
        python status.py
        exit 0
    fi

    # handle power-on


    # handle power-off


    # handle reboot


    # handle force-shutdown

    # help
    if [ "$1" = "help" ]; then
        ipmi-help
        exit 0
    fi

    # version
    if [ "$1" = "version" ]; then
        ipmi-version
        exit 0
    fi
fi




echo "EOF"
exit 0

