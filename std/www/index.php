<?php
    $DEBUG = True;

    session_start();
    if($_SESSION["login"] == False)
    {
        header("Location: login.php");
        die();
    }


    //uname
    $kernel = shell_exec("uname -r");
    
    $uptime = shell_exec("uptime -p | cut -c 3-");

    $wlan_ip = shell_exec('ifconfig wlan0 | grep -oP "inet \d+\.\d+\.\d+" | cut -c 6-');   

    $local_ip = shell_exec('ifconfig usb0 | grep -oP "inet \d+\.\d+\.\d+" | cut -c 6-');   

    $version = shell_exec('ipmi-version');

    $host_ip = shell_exec("cat /home/chip/.ipmi/ipmi.conf"); 

    $host_power = shell_exec("ipmi status | cut -c 15-"); 

    $host_shell = shell_exec("ipmi ping"); 

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
                <p class="text-white bg-primary p-3 mb-2 h4">System overview</p>
                <table class="table table-condensed table-borderless">
                    <tbody>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">Power state</th>
                            <td class="col-7 text-nowrap"><?php echo $host_power; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">SSH</th>
                            <td class="col-7 text-nowrap"><?php echo $host_shell; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">Local-link IP</th>
                            <td class="col-7 text-nowrap"><?php echo $host_ip; ?></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col-md-12">
                <p class="text-white bg-secondary p-3 mb-2 h4">IPMI</p>
                <table class="table table-condensed table-borderless">
                    <tbody>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">Kernel</th>
                            <td class="col-7 text-nowrap"><?php echo $kernel; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">Uptime</th>
                            <td class="col-7 text-nowrap"><?php echo $uptime; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">IP address</th>
                            <td class="col-7 text-nowrap"><?php echo $wlan_ip; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5">Local-link IP</th>
                            <td class="col-7 text-nowrap"><?php echo $local_ip; ?></td>
                        </tr>
                        <tr class="d-flex">
                            <th scope="row" class="text-nowrap col-5 text-truncate">Software</th>
                            <td class="col-7 text-nowrap"><?php echo $version; ?></td>
                        </tr>
                    </tbody>
                </table>
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