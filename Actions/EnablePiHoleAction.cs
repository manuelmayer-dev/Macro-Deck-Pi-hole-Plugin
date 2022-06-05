using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.Actions
{
    public class EnablePiHoleAction : PluginAction
    {
        public override string Name => "Enable Pi-hole";

        public override string Description => "Enables Pi-hole (API Token required!)";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PiHoleHelper.Enable();
        }
    }
}
