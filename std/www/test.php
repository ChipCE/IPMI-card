<?php
    session_start();
    if($_SESSION["login"] == True)
    {
        echo "Yes";
        header("refresh:3;url=index.php");
    }
    else
    {
        echo "No";
        header("refresh:3;url=index.php");
    }

?>

