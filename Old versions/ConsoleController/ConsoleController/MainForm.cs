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
                            serialController = new SerialController(config,logTextBox,debugTextBox,notifyIcon);
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
            if(index >= comPortComboBox.Items.Count || comPortComboBox.Items.Count==0)
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
            if (index >= baudComboBox.Items.Count || baudComboBox.Items.Count == 0)
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
            if (index >= durationComboBox.Items.Count || durationComboBox.Items.Count == 0)
            {
                success = false;
            }
            
            //startup
            if (config.startup)
                startupCheckBox.Checked = true;
            else
                startupCheckBox.Checked = false;

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
            /*
            //cancel the close event 
            e.Cancel = true;
            //hide window
            this.Hide();
            //hide taskbar icon
            this.ShowInTaskbar = false;
            //show tooltip
            notifyIcon.ShowBalloonTip(1000, "Console controller", "Application minimized to system tray.", ToolTipIcon.Info);
            */
            if (serialController != null)
            {
                serialController.disconnect();
            }
            Application.Exit();
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
            if (serialController != null)
            {
                serialController.disconnect();
            }
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
                        serialController = new SerialController(config, logTextBox, debugTextBox, notifyIcon);
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
                serialController = new SerialController(config,logTextBox, debugTextBox, notifyIcon);
                if (serialController.connect())
                {
                    Console.WriteLine("Connect success!");
                    statusLabel.Text = "Connected: " + config.port;
                    logTextBox.AppendText("Connected to : "+ config.port+"\n");
                    enableConfigControl(true);

                }
                else
                {
                    Console.WriteLine("Cannot connect to serial port!");
                    logTextBox.AppendText("Cannot connect to : " + config.port + "\n");
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

        private void enableConfigControl(bool enable)
        {
            if(enable)
            {
                disconnectBtn.Enabled = true;
                rebootBtn.Enabled = true;
                configBtn.Enabled = true;
                clearBtn.Enabled = true;

                connectBtn.Enabled = false;
                saveBtn.Enabled = false;
            }
            else
            {
                disconnectBtn.Enabled = false;
                rebootBtn.Enabled = false;
                configBtn.Enabled = false;
                clearBtn.Enabled = false;

                connectBtn.Enabled = true;
                saveBtn.Enabled = true;
            }
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
            if (serialController.connected)
                serialController.send("#$> status");
        }

        private void rebootBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to reboot IPMI module ?\nCurrent connection will be lost!","Confirm reboot !!",MessageBoxButtons.OKCancel);
            if(confirmResult == DialogResult.OK)
            {
                if (serialController.connected)
                    serialController.send("#$> reboot");
                serialController.disconnect();
                Console.WriteLine("Disconnected!");
                statusLabel.Text = "Idle";
                enableConfigControl(false);
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to delete IPMI module setting ?\nCurrent connection will be lost!", "Confirm clear setting !!", MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                if (serialController.connected)
                    serialController.send("#$> clear");
                serialController.disconnect();
                Console.WriteLine("Disconnected!");
                statusLabel.Text = "Idle";
                enableConfigControl(false);
            }
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Are you sure to reboot IPMI to config mode ?\nCurrent connection will be lost!", "Confirm reboot to Config mode!!", MessageBoxButtons.OKCancel);
            if (confirmResult == DialogResult.OK)
            {
                if (serialController.connected)
                    serialController.send("#$> config");
                serialController.disconnect();
                Console.WriteLine("Disconnected!");
                statusLabel.Text = "Idle";
                enableConfigControl(false);
            }
        }

        private void gitLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/ChipTechno/IPMI-card");
        }
        
        private void allLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";
            debugTextBox.Text = "";
        }

        private void menuItemClearSysLog_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "";
        }

        private void menuItemClearDebugLog_Click(object sender, EventArgs e)
        {
            debugTextBox.Text = "";
        }
    }
}
