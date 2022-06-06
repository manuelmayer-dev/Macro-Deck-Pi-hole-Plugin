using SuchByte.MacroDeck.Plugins;
using SuchByte.PiHolePlugin.Actions;
using SuchByte.PiHolePlugin.Language;
using SuchByte.PiHolePlugin.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuchByte.PiHolePlugin
{
    public class Main : MacroDeckPlugin
    {

        public static Main Instance;

        public override bool CanConfigure => true;

        public override void Enable()
        {
            Instance ??= this;
            PluginLanguageManager.Initialize();
            PiHoleHelper.Initialize(PluginConfigurationHelper.GetHost(), CredentialsHelper.GetToken());
            
            this.Actions = new List<PluginAction>()
            {
                new DisablePiHoleAction(),
                new EnablePiHoleAction(),
            };
        }

        public override void OpenConfigurator()
        {
            using (var pluginConfigurator = new PluginConfigurationView())
            {
                pluginConfigurator.ShowDialog();
            }
        }
    }
}
