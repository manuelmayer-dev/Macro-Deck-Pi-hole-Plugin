﻿using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.PiHolePlugin.Models;
using SuchByte.PiHolePlugin.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.Actions
{
    public class DisablePiHoleAction : PluginAction
    {
        public override string Name => "Disable Pi-hole";

        public override string Description => "Disables Pi-hole (API Token required!)";

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var configModel = DisablePiHoleActionConfigModel.Deserialize(this.Configuration);
            PiHoleHelper.Disable(configModel.Seconds);
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new DisablePiHoleActionConfigView(this);
        }
    }
}
