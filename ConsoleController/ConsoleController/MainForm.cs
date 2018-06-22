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
            }
            else
            {
                logTextBox.AppendText("Cannot read config.conf or invalid format!\n");
            }

            applyConfigToGUI();
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
                logTextBox.AppendText("Apply config : Port : failed\n");
                success = false;
            }
            else
            {
                logTextBox.AppendText("Apply config : Port : "+ config.port +"\n");
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
                logTextBox.AppendText("Apply config : Baud rate : failed\n");
                success = false;
            }
            else
            {
                logTextBox.AppendText("Apply config : Baud rate : " + config.baudRate + "\n");
            }

            //enable 
            if (config.enable)
                enableCheckBox.Checked = true;
            else
                enableCheckBox.Checked = false;
            logTextBox.AppendText("Apply config : Enable : " + config.enable+ "\n");
            //tooltip
            if (config.tooltip)
                tooltipCheckbox.Checked = true;
            else
                tooltipCheckbox.Checked = false;
            logTextBox.AppendText("Apply config : Tooltip : " + config.tooltip + "\n");
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
                logTextBox.AppendText("Apply config : Tooltip duration : failed\n");
                success = false;
            }
            else
            {
                logTextBox.AppendText("Apply config : Tooltip duration : " + config.duration + "\n");
            }
            //startup
            if (config.startup)
                startupCheckBox.Checked = true;
            else
                startupCheckBox.Checked = false;
            logTextBox.AppendText("Apply config : Startup : " + config.startup + "\n");

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

        }

      
    }
}
