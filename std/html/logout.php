<?php
    session_start();
    $_SESSION["login"] = False;
    //unset($_SESSION["login"]);
    header("Location: login.php");
    die();
?>

