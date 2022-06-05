using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.PiHolePlugin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.PiHolePlugin.ViewModels
{
    internal class DisablePiHoleActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;

        public DisablePiHoleActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public long Seconds
        {
            get => Configuration.Seconds;
            set => Configuration.Seconds = value;
        }

        public DisablePiHoleActionConfigViewModel(PluginAction action)
        {
            this.Configuration = DisablePiHoleActionConfigModel.Deserialize(action.Configuration);
            this._action = action;
        }

        public bool SaveConfig()
        {
            try
            {
                SetConfig();
                MacroDeckLogger.Info(Main.Instance, $"{GetType().Name}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(Main.Instance, $"{GetType().Name}: Error while saving config: { ex.Message + Environment.NewLine + ex.StackTrace }");
                return false;
            }
            return true;
        }

        public void SetConfig()
        {
            _action.ConfigurationSummary = Seconds == 0 ? "Permanently" : String.Format("{0} seconds", Seconds);
            _action.Configuration = Configuration.Serialize();
        }
    }
}
