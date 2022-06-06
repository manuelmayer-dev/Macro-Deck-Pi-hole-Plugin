using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.Models
{
    public class PluginStrings
    {
        public string __Language__ { get; set; } = "English";
        public string __LanguageCode__ { get; set; } = "en";
        public string SuccessfullyConnectedToPiHole { get; set; } = "Successfully connected to Pi-hole";
        public string FailedToConnectToPiHole { get; set; } = "Failed to connected to Pi-hole. Make sure Pi-hole is running and you entered the correct host and api token.";
        public string InvalidHost { get; set; } = "Invalid host url";
        public string InvalidToken { get; set; } = "Invalid api token";
        public string Host { get; set; } = "Host url";
        public string Token { get; set; } = "API Token";
        public string ExampleHost { get; set; } = "e.g. \"http://pi-hole\" or \"http://192.168.178.62\"";
        public string TokenLocation { get; set; } = "Settings -> API / Web interface -> API settings -> Show API token";
        public string Temporarily { get; set; } = "Temporarily";
        public string Permanently { get; set; } = "Permanently";
        public string Seconds { get; set; } = "Seconds";
        public string ActionDisablePiHole { get; set; } = "Disable Pi-hole";
        public string ActionDisablePiHoleDescription { get; set; } = "Disables Pi-hole temporarily or permanently";
        public string ActionEnablePiHole { get; set; } = "Enable Pi-hole";
        public string ActionEnablePiHoleDescription { get; set; } = "Enable Pi-hole";


    }
}
