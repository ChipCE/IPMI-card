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
            
            return false;
        }

        public bool writeConfig()
        {
            return true;
        }
    }



}
