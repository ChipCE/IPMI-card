#!/bin/bash
# var
version="1.2 beta"

# function
ipmi-help () {
    # or just call "man ipmi" here :3
    echo "Generic IPMI std $version"
    echo -e "USAGE \n\t ipmi [help]"
    echo -e "\t      [version]"
    echo -e "\t      [status]"
    echo -e "\t      [shell]"
    echo -e "\t      [start]"
    echo -e "\t      [stop] [-f]"
    echo -e "\t      [restart] [-f]"
    echo -e "\t      [setup]"
    echo "OPTIONS"
    echo -e "\t help \n\t\t Print a short help text and exit."
    echo -e "\t version \n\t\t Display application version."
    echo -e "\t status \n\t\t Display the host system's current status."
    echo -e "\t shell \n\t\t Connect to the host system via ssh."
    echo -e "\t start \n\t\t Start the host system."
    echo -e "\t stop \n\t\t Stop(shutdown) the host system."
    echo -e "\t restart \n\t\t restart the host system."
    echo -e "\t -f \n\t\t Force stop or restart the host system."
    echo -e "\t setup \n\t\t Setup IPMI."
}

# check if the first arg is empty 
if [ -z "$1" ]; then
    ipmi-help
    exit 0
fi

# force flag
_force=false

# check 2nd arg
if [ -n "$2" ]; then
    if [ "$2" == "-f" ]; then
        _force=true
    else
        echo -e "Error : Unknown argument \"$2\" !"
        exit 1
    fi
fi

# open ssh connection
if [ "$1" = "shell" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    # read config file
    host=(`cat /home/ipmi/.ipmi/ipmi.conf | grep "HostIP=" | cut -c 8-`)
    echo "$host"
    if [ "$host" = "" ]; then
        echo "Cannot get host IP address!"
    else
        printf "Username : "
        read username
        ssh $username@$host
    fi
    exit 0
fi

# handle status report
if [ "$1" = "status" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    # run status report script
    python /home/ipmi/.ipmi/ipmi.py status
    exit 0
fi

# handle start
if [ "$1" = "start" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    echo "Start : python ipmi.py start"
    python /home/ipmi/.ipmi/ipmi.py start
    exit 0
fi

# handle stop
if [ "$1" = "stop" ]; then
    if [ $# -gt 2 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    _command="python /home/ipmi/.ipmi/ipmi.py stop"

    if [ "$_force" == true ]; then
        _command="$_command -f"
    fi

    echo "Stop : $_command"
    $_command
    exit 0
fi

# handle restart
if [ "$1" = "restart" ]; then
    if [ $# -gt 2 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    _command="python /home/ipmi/.ipmi/ipmi.py restart"

    if [ "$_force" == true ]; then
        _command="$_command -f"
    fi

    echo "Restart : $_command"
    $_command
    exit 0
fi

# handle setup
if [ "$1" = "setup" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    # delete old config line
    if [ -f /home/ipmi/.ipmi/ipmi.conf ]; then
        echo "Delete old config file."
        rm /home/ipmi/.ipmi/ipmi.conf
    fi

    read -p "Enter ip address of the host PC : " hostIP
    echo "HostIP=$hostIP" >> /home/ipmi/.ipmi/ipmi.conf
    echo ""

    read -p "Enter username for web interface : " webUser
    userHash=($(echo -n $webUser | sha256sum | cut -c -64))
    echo "WebUser=$userHash" >> /home/ipmi/.ipmi/ipmi.conf
    echo ""

    read -p "Enter password for web interface : " webPasswd
    passwdHash=($(echo -n $webPasswd | sha256sum | cut -c -64))
    echo "WebPasswd=$passwdHash" >> /home/ipmi/.ipmi/ipmi.conf
    echo ""

    echo "Done!"
    exit 0
fi

# handle version
if [ "$1" = "version" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    echo $version
    exit 0
fi

# handle ping
if [ "$1" = "ping" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi
    
    host=(`cat /home/ipmi/.ipmi/ipmi.conf | grep "HostIP=" | cut -c 8-`)
    if [ "$host" = "" ]; then
        echo "Cannot get host IP address!"
    else
        pingRes=($(ping -q -c1 $host > /dev/null))
        if [ $? -eq 0 ]
        then
            echo "Available"
        else
            echo "Unavailable"
        fi
    fi
    exit 0
fi

echo -e "Error : Unknown argument \"$1\" !"
exit 1