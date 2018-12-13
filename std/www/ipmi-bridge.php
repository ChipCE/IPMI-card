<?php
    $DEBUG = True;

    session_start();
    if($_SESSION["login"] == False)
    {
        header("Location: login.php");
        die();
    }

    $arg =  $_GET["arg"];

    if($arg == "start")
        shell_exec("ipmi start");
    if($arg == "stop")
        shell_exec("ipmi restart");
    if($arg == "")
        shell_exec("ipmi restart");

    header("Location: msg.php?msg=Please wait...");
?>

