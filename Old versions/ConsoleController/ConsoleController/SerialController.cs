﻿using System;
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
        private bool DEBUG;
        ConsoleController console;



        public SerialController(Config _config, System.Windows.Forms.TextBox textBoxControl, System.Windows.Forms.TextBox debugTextBoxControl, System.Windows.Forms.NotifyIcon notifyIconControl)
        {
            config = _config;
            serial = new SerialPort(config.port, config.baudRate, Parity.None, 8, StopBits.One);
            textbox = textBoxControl;
            debugTextbox = debugTextBoxControl;
            notifyIcon = notifyIconControl;
            connected = false;
            DEBUG = false;
            console = new ConsoleController();

            //arg
            string[] args = Environment.GetCommandLineArgs();
            appendDebugTextbox("Args count : " + args.Count() + "\n");
            foreach (string arg in args)
            {
                appendDebugTextbox(arg + "\n");
            }
            if (args.Count() > 1 && args[1] == "-d")
            {
                DEBUG = true;
                appendDebugTextbox("Debug : true\n");
            }
            else
            {
                DEBUG = false;
                appendDebugTextbox("Debug : false\n");
            }
               
        }

        public bool connect()
        {
            try
            {
                serial.Open();
                serial.DataReceived += new SerialDataReceivedEventHandler(processData);
                connected = true;
                console.init();
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
                return false;
            }
            //console.init();
            return true;
        }

        bool isCommandType(String msg)
        {
            if (
                DEBUG
                &&
                msg[0] == '#'
                &&
                (msg[1] == '<' || msg[1] == '>' || msg[1] == '_')
                &&
                (msg[2] == '<' || msg[2] == '>' || msg[2] == '_')
                )
            {
                Console.WriteLine("Debug command type");
                return false;
            }
            Console.WriteLine("Shell command type");
            return true;
        }

        //process data from module , must get msg type COMMAND or DEBUG
        private void processData(object sender,SerialDataReceivedEventArgs e)
        {
            try
            {
                string msg = serial.ReadLine();
                Console.WriteLine("Received msg : " + msg);
                if (isCommandType(msg))
                {
                    //execute
                    //append log textbox
                    if (textbox != null && connected)
                    {
                        //textbox.AppendText("Received command : " + msg + "\n");
                        appendTextbox("Received command : " + msg + "\n");
                    }

                    //tray tooltip
                    if (notifyIcon != null && config.tooltip && config.enable && connected)
                    {
                        notifyIcon.ShowBalloonTip(config.duration, "Console controller", "Execute command:" + msg, System.Windows.Forms.ToolTipIcon.Info);
                    }

                    if (config.enable && connected)
                    {
                        //console debug
                        Console.WriteLine("ipmi:$ " + msg);

                        appendTextbox("Trying to execute command: " + msg + "\n");
                        //try to execute it
                        //StringCollection resultCollection = console.excuteCommand(msg);
                        StringCollection resultCollection = console.excuteCommand(msg);

                        //display the output
                        serial.WriteLine(" ");
                        serial.WriteLine("ipmi:$ " + msg);
                        foreach (string result in resultCollection)
                        {
                            //append result to log textbox
                            appendTextbox(result + "\n");
                            //send back result to device via serial
                            serial.WriteLine(result);
                            //console debug
                            Console.WriteLine(result);
                        }
                    }
                }
                else
                {
                    //append debug textbox
                    appendDebugTextbox(msg + "\n");
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.ToString());
            }
        }

        public void disconnect()
        {
            if(serial!=null)
                serial.Close();
            connected = false;
            console.destroy();
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
