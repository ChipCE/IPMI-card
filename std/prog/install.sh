#!/bin/bash

# root check
FILE="/tmp/out.$$"
GREP="/bin/grep"

if [[ $EUID -ne 0 ]]; then
    echo "This script must be run as root!" 1>&2
    exit 1
fi

user=($(who))
echo "${user[0]}"

read -p "Install IPMI control program ? y/n : " uConfirm
if [ "$uConfirm" != "y" ]; then
    echo "Exit installer!"
    exit 1
fi

# gpio user group
echo "Add ipmi to gpio group."
useradd -g ${user[0]} gpio

# copy boot file
# echo "Add custom cmdline.txt to /boot"
# cp

# ipmi to /bin
echo "Copy ipmi to /bin/ipmi"
yes | cp -rf ipmi.sh /bin/ipmi
chmod 775 /bin/ipmi

# copy ipmi.conf
echo "Copy ipmi.conf to ~/.ipmi/ipmi.conf"
if [ ! -d "/home/${user[0]}/.ipmi" ]; then
    mkdir /home/${user[0]}/.ipmi
fi
yes | cp -rf ipmi.conf /home/${user[0]}/.ipmi/ipmi.conf

# copy ipmi.py
echo "Copy ipmi.py to ~/.ipmi/ipmi.py"
yes | cp -rf ipmi.py /home/${user[0]}/.ipmi/ipmi.py
chown -R ${user[0]}:${user[0]} ipmi.conf /home/${user[0]}/.ipmi

# neofetch conf
echo "Copy neofetch config to ~/.config/neofetch/config"
if [ ! -d "/home/${user[0]}/.config" ]; then
    mkdir /home/${user[0]}/.config
fi
if [ ! -d "/home/${user[0]}/.config/neofetch" ]; then
    mkdir /home/${user[0]}/.config/neofetch
fi
yes | cp -rf ../neofetch/config /home/${user[0]}/.config/neofetch/config
chown -R ${user[0]}:${user[0]} ipmi.conf /home/${user[0]}/.config
chmod 775 /home/${user[0]}/.config/neofetch/config

# neofetch ascii
echo "Copy neofetch ascii to /usr/share/neofetch/ascii/distro/raspbian"
yes | cp -rf ../neofetch/ipmi /usr/share/neofetch/ascii/distro/raspbian
chmod 775 /usr/share/neofetch/ascii/distro/raspbian

# man
echo "Copy ipmi to /usr/share/man/man1/ipmi.1"
yes | cp -rf ../man/ipmi /usr/share/man/man1/ipmi.1
gzip /usr/share/man/man1/ipmi.1

echo "Done!"
exit 0