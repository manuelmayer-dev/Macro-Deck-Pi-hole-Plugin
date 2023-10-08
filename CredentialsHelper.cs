using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SuchByte.PiHolePlugin;

internal static class CredentialsHelper
{

    public static void UpdateToken(string token)
    {
        Dictionary<string, string> credentials = new Dictionary<string, string>
        {
            ["token"] = token
        };
        PluginCredentials.SetCredentials(Main.Instance, credentials);
    }


    public static string GetToken()
    {
        try
        {
            List<Dictionary<string, string>> credentialsList = PluginCredentials.GetPluginCredentials(Main.Instance);
            if (credentialsList == null || credentialsList.Count == 0) return null;
            Dictionary<string, string> credentials = credentialsList.FirstOrDefault();
            if (credentials == null) return "";
            return credentials["token"];
        }
        catch (Exception ex)
        {
            MacroDeckLogger.Error(Main.Instance, $"Error while getting credentials: { ex.Message + Environment.NewLine + ex.StackTrace }");
        }
        return "";
    }

}