# var
version="1.0 alpha 1018-10-21"

# function
ipmi-help () {
    echo "Generic IPMI std $version"
    echo -e "USAGE \n\t ipmi [help] [version] [status] [shell] [power-on] [power-off] [reboot] [-f]"
    echo "OPTIONS"
    echo -e "\t help \n\t\t Print a short help text and exit."
    echo -e "\t version \n\t\t Display application version."
    echo -e "\t status \n\t\t Display system current status."
    echo -e "\t shell \n\t\t Connect to system via ssh."
    echo -e "\t power-on \n\t\t Power-on the system."
    echo -e "\t power-off \n\t\t Power-off(shutdown) the system."
    echo -e "\t reboot \n\t\t Reboot the system."
    echo -e "\t -f \n\t\t Force power-off or reboot the system."
}

ipmi-version () {
    echo $version
}



# main program
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
    if [ "$1" = "power-on" ]; then
        echo "power-on"
        exit 0
    fi

    # handle power-off
    if [ "$1" = "power-off" ]; then
        if [ "$2" = "-f" ]; then
            echo "force shutdown"
            exit 0
        else
            echo "shutdown"
            exit 0
        fi
    fi


    # handle reboot
    if [ "$1" = "reboot" ]; then
        if [ "$2" = "-f" ]; then
            echo "force reboot"
            exit 0
        else
            echo "reboot"
            exit 0
        fi
    fi

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

