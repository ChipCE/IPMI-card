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

        private void Form1_Load(object sender, EventArgs e)
        {
            //list COM port
            foreach (string comPort in SerialPort.GetPortNames())
            {
                comPortComboBox.Items.Add(comPort);  
            }
            //load config 
            configMan = new ConfigManager();
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
            comPortComboBox.SelectionLength = 0;
            comPortComboBox.Text ="--Select--";
            //clear old list
            comPortComboBox.Items.Clear();
            //re-list COM port
            foreach (string comPort in SerialPort.GetPortNames())
            {
                comPortComboBox.Items.Add(comPort);
            }
        }
    }
}
