<?php
    $DEBUG = True;
    $usrname =  $_GET["usrname"];
    $passwd = $_GET["passwd"];
    if($DEBUG)
        echo $usrname."@".$passwd."<br/>";
    session_start();
    
    if($usrname == "admin" && $passwd == "admin")
    {
        $_SESSION["login"] = True;
        header("Location: index.php");
    }
    else
    {
        $_SESSION["login"] = False;
        header("Location: msg.php?msg=Wrong username or password");
    }
?>

