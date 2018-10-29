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
    echo -e "\t      [start]"
    echo -e "\t      [stop] [-f]"
    echo -e "\t      [restart] [-f]"
    echo "OPTIONS"
    echo -e "\t help \n\t\t Print a short help text and exit."
    echo -e "\t version \n\t\t Display application version."
    echo -e "\t status \n\t\t Display the host system's current status."
    echo -e "\t shell \n\t\t Connect to the host system via ssh."
    echo -e "\t start \n\t\t Start the host system."
    echo -e "\t stop \n\t\t Stop(shutdown) the host system."
    echo -e "\t restart \n\t\t restart the host system."
    echo -e "\t -f \n\t\t Force stop or restart the host system."
    echo -e "\t -w \n\t\t Execute command and wait for the host system state to change."
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

# arg check
_wait=false
_force=false

# check 2nd arg
if [ -n "$2" ]; then
    if [ "$2" == "-f" ]; then
        _force=true
    else
        if [ "$2" == "-w" ]; then
            _wait=true
        else
            echo -e "Error : Unknown argument \"$2\" !"
            exit 1
        fi
    fi
fi

# check 3th arg
if [ -n "$3" ]; then
    if [ "$3" == "-f" ]; then
        _force=true
    else
        if [ "$3" == "-w" ]; then
            _wait=true
        else
            echo -e "Error : Unknown argument \"$3\" !"
            exit 1
        fi
    fi
fi


# open ssh connection
if [ "$1" = "shell" ]; then
    if [ $# -gt 1 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    # read config file
    host=`cat ipmi.conf`
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
    python status.py
    exit 0
fi


# handle start
if [ "$1" = "start" ]; then
    if [ $# -gt 2 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    _command="python start.py"

    if [ "$_wait" == true ]; then
        _command="$_command -w"
    fi

    if [ "$_force" == true ]; then
        echo "-f will be ignore!"
    fi

    echo $_command
    $_command
    exit 0
fi

# handle stop
if [ "$1" = "stop" ]; then
    if [ $# -gt 3 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    _command="python stop.py"

    if [ "$_wait" == true ]; then
        _command="$_command -w"
    fi

    if [ "$_force" == true ]; then
        _command="$_command -f"
    fi

    echo $_command
    $_command
    exit 0
fi

# handle restart
if [ "$1" = "restart" ]; then
    if [ $# -gt 2 ]; then
        echo "Error : Too much arguments!"
        exit 1
    fi

    _command="python restart.py"

    if [ "$_force" == true ]; then
        _command="$_command -f"
    fi

    if [ "$_wait" == true ]; then
        echo "-w will be ignore!"
    fi

    echo $_command
    $_command
    exit 0
fi

echo -e "Error : Unknown argument \"$1\" !"
exit 1