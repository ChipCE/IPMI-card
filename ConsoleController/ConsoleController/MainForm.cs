using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ConsoleController
{
    public partial class mainForm : Form
    {
        private Config config;
        private ConfigManager configMan;
        private SerialController serialController;

        public mainForm()
        {
            InitializeComponent();
            notifyIcon.Visible = true;
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            listComPort();
            //load config 
            configMan = new ConfigManager();
            if(configMan.readConfig())
            {
                logTextBox.AppendText("Loaded config.conf\n");
                config = configMan.getconfig();

                if(applyConfigToGUI())
                {
                    logTextBox.AppendText("Config applied!\n");
                    //try to auto connect
                    if(config.startup && config.enable)
                    {
                        if(updateRunningConfig())
                        {
                            serialController = new SerialController(config,logTextBox,notifyIcon);
                            serialController.updateConfig(config);
                            if (serialController.connect())
                            {
                                logTextBox.AppendText("Auto connect success!\n");
                                statusLabel.Text = "Connected: " + config.port;
                                enableConfigControl(true);

                                //hide
                                this.Hide();
                                //hide taskbar icon
                                this.ShowInTaskbar = false;
                                //show tooltip
                                notifyIcon.ShowBalloonTip(1000, "Console controller", "Application is running in background.", ToolTipIcon.Info);
                            }
                            else
                            {
                                logTextBox.AppendText("Auto connect failed!\n");
                            }
                        }
                    }
                }
                else
                {
                    logTextBox.AppendText("Cannot apply current config!\n");
                }
            }
            else
            {
                logTextBox.AppendText("Cannot read config.conf or invalid format!\n");
            }
        }


        bool listComPort()
        {
            comPortComboBox.SelectionLength = 0;
            comPortComboBox.Text = "--Select--";
            //clear old list
            comPortComboBox.Items.Clear();
            int counter = 0;
            //list COM port
            foreach (string comPort in SerialPort.GetPortNames())
            {
                comPortComboBox.Items.Add(comPort);
                counter++;
            }
            if (counter == 0)
                return false;
            else
                return true;
        }

        private bool applyConfigToGUI()
        {
            bool success = true;
            //port 
            int index = 0;
            foreach (var item in comPortComboBox.Items)
            {
                if(item.ToString() == config.port)
                {
                    comPortComboBox.SelectedIndex = index;
                    break;
                }
                index++;
            }
            if(index > comPortComboBox.Items.Count || comPortComboBox.Items.Count==0)
            {
                success = false;
            }
           


            //baud
            index = 0;
            foreach (var item in baudComboBox.Items)
            {
                if (Int32.Parse(item.ToString()) == config.baudRate)
                {
                    baudComboBox.SelectedIndex = index;
                    break;
                }
                index++;
            }
            if (index > baudComboBox.Items.Count || baudComboBox.Items.Count == 0)
            {
                success = false;
            }
            

            //enable 
            if (config.enable)
                enableCheckBox.Checked = true;
            else
                enableCheckBox.Checked = false;
            
            //tooltip
            if (config.tooltip)
                tooltipCheckbox.Checked = true;
            else
                tooltipCheckbox.Checked = false;
            
            //duration
            index = 0;
            foreach (var item in durationComboBox.Items)
            {
                if (Int32.Parse(item.ToString()) == config.duration)
                {
                    durationComboBox.SelectedIndex = index;
                    break;
                }
                index++;
            }
            if (index > durationComboBox.Items.Count || durationComboBox.Items.Count == 0)
            {
                success = false;
            }
            
            //startup
            if (config.startup)
                startupCheckBox.Checked = true;
            else
                startupCheckBox.Checked = false;
            
            //run startup script


            return success;
        }
   

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //cancel the close event 
            e.Cancel = true;
            //hide window
            this.Hide();
            //hide taskbar icon
            this.ShowInTaskbar = false;
            //show tooltip
            notifyIcon.ShowBalloonTip(1000, "Console controller", "Application minimized to system tray.", ToolTipIcon.Info);
        }

        private void mainForm_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                //hide window
                this.Hide();
                //hide taskbar icon
                this.ShowInTaskbar = false;
                //show tooltip
                notifyIcon.ShowBalloonTip(1000, "Console controller", "Application minimized to system tray.", ToolTipIcon.Info);
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            listComPort();
            applyConfigToGUI();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Config tmpConf;
            tmpConf.baudRate = 0;
            tmpConf.duration = 0;

            bool error = false;

            //check valid input
            try
            {
                tmpConf.baudRate = Int32.Parse(baudComboBox.Text);
                tmpConf.duration = Int32.Parse(durationComboBox.Text);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                error = true;
            }

            tmpConf.port = comPortComboBox.Text;
            if (tmpConf.port == "--Select--")
            {
                error = true;
            }

            tmpConf.enable = enableCheckBox.Checked;
            tmpConf.tooltip = tooltipCheckbox.Checked;
            tmpConf.startup = startupCheckBox.Checked;

            if(!error)
            {
                if(configMan.writeConfig(tmpConf))
                { 
                    logTextBox.AppendText("Setting saved!\n");
                    //update running config
                    config = tmpConf;

                    if (serialController != null)
                    {
                        serialController.disconnect();
                        enableConfigControl(false);
                        statusLabel.Text = "Idle";

                        serialController.updateConfig(config);
                        //reconnect 
                        if (serialController.connected)
                        {
                            logTextBox.AppendText("Trying to connect with new setting!\n");
                            if (serialController.connect())
                            {
                                logTextBox.AppendText("Connected!\n");
                                statusLabel.Text = "Connected: " + config.port;
                                enableConfigControl(true);
                            }
                            else
                            {
                                logTextBox.AppendText("Cannot connect!\n");
                            }
                        }
                    }
                    else
                    {
                        //init new serial
                        serialController = new SerialController(config, logTextBox, notifyIcon);
                    }
                }
                else
                {
                    logTextBox.AppendText("Cannot save setting! Unknown error\n");
                }
            }
            else
            {
                logTextBox.AppendText("Cannot save setting.Invalid config\n");
            }
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            //close old connection (just in case)
            if (serialController != null)
            {
                serialController.disconnect();
                statusLabel.Text = "Idle";
                enableConfigControl(false);
            }

            //load GUI profile to runningConfig
            if (updateRunningConfig())
            {
                serialController = new SerialController(config,logTextBox,notifyIcon);
                if (serialController.connect())
                {
                    Console.WriteLine("Connect success!");
                    statusLabel.Text = "Connected: " + config.port;
                    enableConfigControl(true);
                }
                else
                {
                    Console.WriteLine("Cannot connect to serial port!");
                }
            }
            else
            {
                logTextBox.AppendText("Cannot connect! Invalid running config!\n");
            }
        }

        private void disconnectBtn_Click(object sender, EventArgs e)
        {
            serialController.disconnect();
            Console.WriteLine("Disconnected!");
            statusLabel.Text = "Idle";
            enableConfigControl(false);
        }

        private bool updateRunningConfig()
        {
            Config tmpConf;
            tmpConf.baudRate = 0;
            tmpConf.duration = 0;

            bool error = false;

            //check valid input
            try
            {
                tmpConf.baudRate = Int32.Parse(baudComboBox.Text);
                tmpConf.duration = Int32.Parse(durationComboBox.Text);
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                error = true;
            }

            tmpConf.port = comPortComboBox.Text;
            if (tmpConf.port == "--Select--")
            {
                error = true;
            }

            tmpConf.enable = enableCheckBox.Checked;
            tmpConf.tooltip = tooltipCheckbox.Checked;
            tmpConf.startup = startupCheckBox.Checked;

            if (!error)
            {
                logTextBox.AppendText("Running config updated!\n");
                //update current config
                config = tmpConf;
                return true;
            }
            else
            {
                logTextBox.AppendText("Invalid running config\n");
                return false;
            }
        }

        private void moduleRebootBtn_Click(object sender, EventArgs e)
        {
            //send reboot command via serial
            if(serialController.connected)
            {

            }
        }

        private void moduleClearBtn_Click(object sender, EventArgs e)
        {
            //send clear config and reboot command to module via serial
            if(serialController.connected)
            {

            }
        }

        private void moduleSaveBtn_Click(object sender, EventArgs e)
        {
            //send new config and reboot command to module via serial
            if(serialController.connected)
            {
                //check current args
                string result = checkModuleConfig();
                if (result == "")
                {
                    //send it


                    showDialog("New setting was sent via UART", "Sent");
                }
                else
                    showDialog(result, "Error");
            }
        }


        private void enableConfigControl(bool enable)
        {
            if(enable)
            {
                moduleClearBtn.Enabled = true;
                moduleRebootBtn.Enabled = true;
                moduleSaveBtn.Enabled = true;
                statusBtn.Enabled = true;
                disconnectBtn.Enabled = true;
            }
            else
            {
                moduleClearBtn.Enabled = false;
                moduleRebootBtn.Enabled = false;
                moduleSaveBtn.Enabled = false;
                statusBtn.Enabled = false;
                disconnectBtn.Enabled = false;
            }
        }

        private string checkModuleConfig()
        {
            //empty value check
            if (wifiSsidTextbox.Text == "")
                return "Invalid SSID";


             if(mqttServerTextbox.Text == "")
                return "Invalid MQTT server";

            if(mqttPortTextbox.Text == "")
                return "Invalid MQTT port";

            if(mqttSubTextbox.Text == "")
                return "Invalid MQTT sub";

            if(mqttPubTextbox.Text == "")
                return "Invalid MQTT pub";




            //number only check
            int tmp;
            if (!Int32.TryParse(mqttPortTextbox.Text, out tmp))
                return "Invalid MQTT port";

            if ((passwdConfrimTextbox1.Text != "" || passwdConfirmTextbox2.Text != "") && (passwdConfirmTextbox2.Text != passwdConfrimTextbox1.Text))
                return "Confirm password not matched";

            return "";
        }

        private void showDialog(string message,string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                // Closes the parent form.
                this.Close();
            }
        }

        private void statusBtn_Click(object sender, EventArgs e)
        {
            serialController.send("{status}");
        }
    }
}
