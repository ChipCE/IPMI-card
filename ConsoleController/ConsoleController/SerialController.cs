using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;

namespace ConsoleController
{
    class SerialController
    {
        private SerialPort serial;
        public delegate void DataReceivedHandler(byte[] data);
        public bool connected;
        private Config config;
        private System.Windows.Forms.TextBox textbox;
        private System.Windows.Forms.TextBox debugTextbox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        ConsoleController console;



        public SerialController(Config _config, System.Windows.Forms.TextBox textBoxControl, System.Windows.Forms.TextBox debugTextBoxControl, System.Windows.Forms.NotifyIcon notifyIconControl)
        {
            config = _config;
            serial = new SerialPort(config.port, config.baudRate, Parity.None, 8, StopBits.One);
            textbox = textBoxControl;
            debugTextbox = debugTextBoxControl;
            notifyIcon = notifyIconControl;
            connected = false;
            console = new ConsoleController();
        }

        public bool connect()
        {
            try
            {
                serial.Open();
                serial.DataReceived += new SerialDataReceivedEventHandler(processData);
                connected = true;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
            return true;
        }

        private void processData(object sender,SerialDataReceivedEventArgs e)
        {
            try
            {
                string msg = serial.ReadLine();
                Console.WriteLine("Received msg : " + msg);
                if(msg[0]!='#' && msg[0] != '$' && msg[0]!= '\r' && msg[0] != '\n' && msg.Length>0)
                {
                    //if msg are not the devide debug
                    if(textbox!=null && connected)
                    {
                        //textbox.AppendText("Received command : " + msg + "\n");
                        appendTextbox("Received command : " + msg + "\n");
                    }

                    //tray tooltip
                    if (notifyIcon != null && config.tooltip && config.enable && connected)
                    {
                        notifyIcon.ShowBalloonTip(config.duration, "Console controller","Excute command:" + msg, System.Windows.Forms.ToolTipIcon.Info);
                    }

                    if (config.enable && connected)
                    {
                        appendTextbox("Trying to excute command: " + msg + "\n");
                        //try to excute it
                        StringCollection resultCollection = console.excuteCommand(msg);
                        //display the output
                        foreach(string result in resultCollection)
                        {
                            appendTextbox(result + "\n");
                        }
                        //send back result to device via serial

                    }

                }
                else
                {
                    if(msg[0]=='$')
                        appendTextbox(msg + "\n");
                    if (msg[0] == '#')
                        appendDebugTextbox(msg + "\n");
                }
            }
            catch(Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        public void disconnect()
        {
            if(serial!=null)
                serial.Close();
            connected = false;
        }

        public void updateConfig(Config tmpConf)
        {
            config = tmpConf;
            serial = new SerialPort(config.port, config.baudRate, Parity.None, 8, StopBits.One);
        }

        public bool send(string msg)
        {
            serial.WriteLine(msg);
            appendTextbox("Send \"" + msg + "\"to module\n");
            return true;
        }


        //for cross-threading 
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;
            return true;
        }
        public void appendTextbox(String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(textbox, () => appendTextbox(text))) return;
            //textbox.Text = ellapsed;
            textbox.AppendText(text);
        }

        public void appendDebugTextbox(String text)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(debugTextbox, () => appendDebugTextbox(text))) return;
            //textbox.Text = ellapsed;
            debugTextbox.AppendText(text);
        }

    }
}
