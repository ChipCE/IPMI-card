# var
version="1.0 alpha"

# function
ipmi-help () {
    # or just call "man ipmi" here :3
    echo "Generic IPMI std $version"
    echo -e "USAGE \n\t ipmi [help]"
    echo -e "\t      [version]"
    echo -e "\t      [status]"
    echo -e "\t      [shell]"
    echo -e "\t      [power-on]"
    echo -e "\t      [power-off] [-f]"
    echo -e "\t      [reboot] [-f]"
    echo "OPTIONS"
    echo -e "\t help \n\t\t Print a short help text and exit."
    echo -e "\t version \n\t\t Display application version."
    echo -e "\t status \n\t\t Display the host system's current status."
    echo -e "\t shell \n\t\t Connect to the host system via ssh."
    echo -e "\t power-on \n\t\t Power-on the host system."
    echo -e "\t power-off \n\t\t Power-off(shutdown) the host system."
    echo -e "\t reboot \n\t\t Reboot the host system."
    echo -e "\t -f \n\t\t Force power-off or reboot the host system."
}

# display current version
ipmi-version () {
    echo $version
}


# main program ------------------------------------------------------

# check if the first arg is empty 
if [ -z "$1" ]; then
    ipmi-help
    exit 0
fi

# open ssh connection
if [ "$1" = "shell" ]; then
    if [ -n "$2" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    # read config file
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
    if [ -n "$2" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    # run status report script
    python status.py
    exit 0
fi

# handle power-on
if [ "$1" = "power-on" ]; then
    if [ -n "$2" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    # run power-on script
    echo "power-on"
    exit 0
fi

# handle power-off
if [ "$1" = "power-off" ]; then
    if [ -n "$3" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    
    if [ -z "$2" ]; then
        echo "power-off"
        exit 0
    fi

    if [ "$2" = "-f" ]; then
        echo "force power-off"
        exit 0
    else
        echo -e "Error : Unknown argument \"$2\" !"
        exit 1
    fi
fi


# handle reboot
if [ "$1" = "reboot" ]; then
    if [ -n "$3" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    
    if [ -z "$2" ]; then
        echo "reboot"
        exit 0
    fi

    if [ "$2" = "-f" ]; then
        echo "force reboot"
        exit 0
    else
        echo -e "Error : Unknown argument \"$2\" !"
        exit 1
    fi
fi

# help
if [ "$1" = "help" ]; then
    if [ -n "$2" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    ipmi-help
    exit 0
fi

# version
if [ "$1" = "version" ]; then
    if [ -n "$2" ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    ipmi-version
    exit 0
fi

# force
if [ "$1" = "-f" ]; then
    if [ -z "$2" ]; then
        echo "Error : Too few arguments!"
        exit 1
    fi

    if [ "$2" = "power-off" ]; then
        echo "force shutdown"
        exit 0
    fi

    if [ "$2" = "reboot" ]; then
        echo "force reboot"
        exit 0
    fi

    echo -e "Error : Unknown argument \"$2\" !"
    exit 1
fi

# thes rest
echo -e "Error : Unknown argument!"
exit 1


echo "EOF"
exit 0

