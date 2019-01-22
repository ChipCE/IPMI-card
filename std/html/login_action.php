<?php
    $DEBUG = True;
    $usrname =  $_GET["usrname"];
    $passwd = $_GET["passwd"];
    if($DEBUG)
        echo $usrname."@".$passwd."<br/>";
    session_start();

    //calc hash
    $usrHash = hash('sha256', $usrname);
    $passwdHash = hash('sha256', $passwd);

    //read hash from config file
    //cat ipmi.conf | grep "WebUser=" | cut -c 9-
    //cat ipmi.conf | grep "WebPasswd=" | cut -c 11-
    $savedUsrHash = shell_exec('cat /home/ipmi/.ipmi/ipmi.conf | grep "WebUser=" | cut -c 9-');
    $savedPasswdHash = shell_exec('cat /home/ipmi/.ipmi/ipmi.conf | grep "WebPasswd=" | cut -c 11-');

    //trim the hash string
    if(trim($usrHash) == trim($savedUsrHash) && trim($passwdHash) == trim($savedPasswdHash))
    {
        $_SESSION["login"] = True;
        header("Location: index.php");
    }
    else
    {
        $_SESSION["login"] = False;
        header("Location: msg.php?msg=Wrong username or password!");
    }
?>

