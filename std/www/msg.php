<?php
    /*
    session_start();
    if($_SESSION["login"] == False)
    {
        echo "Yes";
        header("Location: login.php");
        die();
    }
    */
    $msg =  $_GET["msg"];
    header("refresh:3;url=index.php");
?>



<!doctype html>
<html lang="en">
  <head>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="bootstrap.min.css">
    <!-- custom css -->
    <link rel="stylesheet" href="style.css">

    <title>G-IPMI</title>
  </head>
  <body>
    <!-- Navigation  navbar-dark bg-dark -->
    <nav class="navbar navbar-expand-lg fixed-top navbar-dark">
        <div class="container">
            <a class="navbar-brand" href="index.php">Generic IPMI web portal</a>
            <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                <li class="nav-item active">
                    <a class="nav-link" href="index.php">Control panel
                    <span class="sr-only">(current)</span>
                    </a>
                </li>
                <li class="nav-item dropdown">
                    <a class="nav-link dropdown-toggle" data-toggle="dropdown" href="#" role="button" aria-haspopup="true" aria-expanded="false" id="dropdown01">Controls</a>
                    <div class="dropdown-menu" aria-labelledby="dropdown01">
                        <a class="dropdown-item" href="ipmi-bridge.php?arg=start">Start</a>
                        <a class="dropdown-item" href="ipmi-bridge.php?arg=stop">Stop</a>
                        <a class="dropdown-item" href="ipmi-bridge.php?arg=restart">Restart</a>
                    </div>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="https://github.com/ChipTechno/IPMI-card">Repository</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="logout.php">Logout</a>
                </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- main content -->
    <div class="container main-container">
        <div class="row main-content">
            <div class="col-md-12">
            <h4 class="display-4 text-center mt-5"><?php echo $msg; ?></h4><br/>
            </div>
        </div>
    </div>

    <!-- footer bg-dark -->
    <footer class="fixed-bottom text-center py-3 navbar-dark">
        <div class="container">
            <p class="m-0 text-white">Generic Intelligent Platform Management Interface</p>
            <a href="https://github.com/ChipTechno/IPMI-card">https://github.com/ChipTechno/IPMI-card</a>
        </div>
    </footer>
    
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="jquery-3.3.1.slim.min.js"></script>
    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>
    <script src="script.js"></script>
  </body>
</html>