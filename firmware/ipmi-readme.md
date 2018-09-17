# IPMI ver 2.0 manual
Generic IPMI card version 2.0 manual

## IPMI MQTT topic structure

IPMI-root/
- /HardwareCotrol
- /HardwareReport
- /ShellControl
- /ShellReport
- /IpmiControl
- /IpmiReport
- /PowerStateReport

## Supported commands

### HardwareControl
    - status
    - shutdown
    - power-on

### ShellCommand
    - anything you can throw into Windows Powershell or Linux Terminal

### IpmiControl
    - reboot
    - clear
    - config