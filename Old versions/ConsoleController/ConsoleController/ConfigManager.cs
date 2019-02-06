using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;


namespace ConsoleController
{


    public struct Config
    {
        public String port;
        public int baudRate;
        public bool enable;
        public bool startup;
        public bool tooltip;
        public int duration;
    }


    class ConfigManager
    {
        private Config config;

        public ConfigManager()
        {
            config.port = "";
            config.baudRate = 0;
            config.enable = false;
            config.startup = false;
            config.tooltip = false;
            config.duration = 0;
        }

        public bool readConfig()
        {
            try
            {
                String dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\config.conf";
                System.IO.StreamReader file = new System.IO.StreamReader(dir);
                string line;
                int tmp = 0;
                for(int i=0; (line = file.ReadLine()) != null;i++)
                {
                    System.Console.WriteLine(line);
                    switch(i)
                    {
                        case 0:
                            if(line!="[port]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 1:
                            config.port = line;
                            break;
                        case 2:
                            if (line != "[baudRate]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 3:
                            if(!Int32.TryParse(line, out tmp))
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            config.baudRate = tmp;
                            break;
                        case 4:
                            if (line != "[enable]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 5:
                            if(line!="True" && line != "False")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "True")
                                config.enable = true;
                            else
                                config.enable = false;
                            break;
                        case 6:
                            if (line != "[tooltip]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 7:
                            if (line != "True" && line != "False")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "True")
                                config.tooltip = true;
                            else
                                config.tooltip = false;
                            break;
                        case 8:
                            if (line != "[duration]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 9:
                            if (!Int32.TryParse(line, out tmp))
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            config.duration = tmp;
                            break;
                        case 10:
                            if (line != "[startup]")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            break;
                        case 11:
                            if (line != "True" && line != "False")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "True")
                                config.startup = true;
                            else
                                config.startup = false;
                            break;
                    }
                }
                file.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool writeConfig(Config tmpConf)
        {
            //update config
            config = tmpConf;

            //write config.conf
            try
            {
                String dir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\config.conf";
                System.IO.StreamWriter file = new System.IO.StreamWriter(dir);
                file.WriteLine("[port]");
                file.WriteLine(config.port);
                file.WriteLine("[baudRate]");
                file.WriteLine(config.baudRate);
                file.WriteLine("[enable]");
                file.WriteLine(config.enable);
                file.WriteLine("[tooltip]");
                file.WriteLine(config.tooltip);
                file.WriteLine("[duration]");
                file.WriteLine(config.duration);
                file.WriteLine("[startup]");
                file.WriteLine(config.startup);

                Console.WriteLine("Config saved!");
                file.Close(); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            //write system startup entry
            setWinStartup();


            return true;
        }

        public Config getconfig()
        {
            return config;
        }

        private void setWinStartup()
        {
            String appLocation = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ConsoleController.exe";
            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (config.startup)
            {
                rk.SetValue("ConsoleController", Application.ExecutablePath);
            }
            else
            {
                rk.DeleteValue("ConsoleController", false);
            }
        }
    }



}
