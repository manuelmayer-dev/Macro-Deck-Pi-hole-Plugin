using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin
{
    public class PluginConfigurationHelper
    {

        public static void UpdateHost(string host)
        {
            PluginConfiguration.SetValue(Main.Instance, "host", host);
        }

        public static string GetHost()
        {
            var host = PluginConfiguration.GetValue(Main.Instance, "host");
            if (string.IsNullOrWhiteSpace(host))
            {
                host = "http://pi-hole";
            }
            return host;
        }


    }
}
