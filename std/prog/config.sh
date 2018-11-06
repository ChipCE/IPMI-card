#!/bin/bash
echo "IPMI auto-config utility"
netIface="wlp12s0"
networkAddr="192.168.1.0/24"

# get current ip address
echo "Network interface : $netIface"
localIP=$(ifconfig $netIface | grep -Po "inet\s\d+\.\d+\.\d\.\d+" | grep -Po "\d+\.\d+\.\d\.\d+")
echo "Local IP address : $localIP"

# delete old tmp file if needed
if [ -f ./tmp.txt ]; then
    rm ./tmp.txt
fi

echo "Scan for device(s) in $networkAddr with nmap"
nmap $networkAddr >> tmp.txt
result=$(grep -Po "\d+\.\d+\.\d+\.\d+" tmp.txt | grep -v "$localIP" | head -1)
echo "Found host IP address : $result"

if [ -f ./ipmi.conf ]; then
    rm ./ipmi.conf
fi

echo "Writing config file..."
echo "$result" >> ipmi.conf
echo "Done!"

# delete tmp file
rm ./tmp.txt