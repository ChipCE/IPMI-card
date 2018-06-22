using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
                System.IO.StreamReader file = new System.IO.StreamReader("config.conf");
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
                            if(line!="true" && line != "false")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "true")
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
                            if (line != "true" && line != "false")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "true")
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
                            if (line != "true" && line != "false")
                            {
                                file.Close();
                                Console.WriteLine("Invalid config.conf");
                                return false;
                            }
                            if (line == "true")
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

        public bool writeConfig()
        {
            return true;
        }

        public Config getconfig()
        {
            return config;
        }
    }



}
