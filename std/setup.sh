#!/bin/bash

# root check
FILE="/tmp/out.$$"
GREP="/bin/grep"

if [[ $EUID -ne 0 ]]; then
    echo "This script must be run as root!" 1>&2
    exit 1
fi

read -p "Install IPMI control program ? y/n : " uConfirm
if [ "$uConfirm" != "y" ]; then
    echo "Exit installer!"
    exit 1
fi


# create user
adduser ipmi

# add to sudo group
usermod -aG sudo ipmi

# gpio user group
echo "Add ipmi to gpio group."
useradd -g ipmi gpio

# install package
apt-get install -y apache2 php libapache2-mod-php


# ipmi to /bin
echo "Copy ipmi to /bin/ipmi"
yes | cp -rf prog/ipmi.sh /bin/ipmi
chmod 775 /bin/ipmi

# copy ipmi.conf
echo "Copy ipmi.conf to ~/.ipmi/ipmi.conf"
if [ ! -d "/home/ipmi/.ipmi" ]; then
    mkdir /home/ipmi/.ipmi
fi
yes | cp -rf prog/ipmi.conf /home/ipmi/.ipmi/ipmi.conf

# copy ipmi.py
echo "Copy ipmi.py to ~/.ipmi/ipmi.py"
yes | cp -rf prog/ipmi.py /home/ipmi/.ipmi/ipmi.py
chown -R ipmi:ipmi /home/ipmi/.ipmi

# neofetch conf
echo "Copy neofetch config to ~/.config/neofetch/config"
if [ ! -d "/home/ipmi/.config" ]; then
    mkdir /home/ipmi/.config
fi
if [ ! -d "/home/ipmi/.config/neofetch" ]; then
    mkdir /home/ipmi/.config/neofetch
fi
yes | cp -rf neofetch/config /home/ipmi/.config/neofetch/config
chown -R ipmi:ipmi /home/ipmi/.config
chmod 775 /home/ipmi/.config/neofetch/config

# neofetch ascii
echo "Copy neofetch ascii to /usr/share/neofetch/ascii/distro/raspbian"
yes | cp -rf neofetch/ipmi /usr/share/neofetch/ascii/distro/raspbian
chmod 775 /usr/share/neofetch/ascii/distro/raspbian

# man
echo "Copy ipmi to /usr/share/man/man1/ipmi.1"
yes | cp -rf man/ipmi /usr/share/man/man1/ipmi.1
gzip /usr/share/man/man1/ipmi.1

# copy www
echo "copy web interface to /var/www/html"
rm -rf /var/www/http/index.html
yes | cp -rf /var/www/http

# copy boot file
# echo "Add custom cmdline.txt to /boot"
# cp


echo "Done!"
exit 0



