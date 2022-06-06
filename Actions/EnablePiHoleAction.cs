using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.PiHolePlugin.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.Actions
{
    public class EnablePiHoleAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionEnablePiHole;

        public override string Description => PluginLanguageManager.PluginStrings.ActionEnablePiHoleDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PiHoleHelper.Enable();
        }
    }
}
