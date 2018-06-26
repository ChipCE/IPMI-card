using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;

namespace ConsoleController
{
    class SerialController
    {
        private SerialPort serial;
        public delegate void DataReceivedHandler(byte[] data);
        public bool connected;
        private Config config;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;

        public SerialController(String port,int baudRate, System.Windows.Forms.TextBox textBoxControl, System.Windows.Forms.NotifyIcon notifyIconControl)
        {
            serial = new SerialPort(port, baudRate, Parity.None, 8, StopBits.One);
            textBox = textBoxControl;
            notifyIcon = notifyIconControl;
            connected = false;
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
                if(msg[0]!='#')
                {
                    //not the devide debug
                    if(textBox!=null)
                    {
                        textBox.AppendText("Received command : " + msg + "\n");
                    }

                    //tray tooltip
                    if(notifyIcon!=null && config.tooltip && config.enable && connected)
                    {
                        notifyIcon.ShowBalloonTip(config.duration, "Console controller", msg, System.Windows.Forms.ToolTipIcon.Info);
                    }
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
        }
    }
}
