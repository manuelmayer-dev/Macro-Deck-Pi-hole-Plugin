using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.PiHolePlugin.Language;
using SuchByte.PiHolePlugin.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.PiHolePlugin.Views
{
    public partial class DisablePiHoleActionConfigView : ActionConfigControl
    {

        private readonly DisablePiHoleActionConfigViewModel _viewModel;

        public DisablePiHoleActionConfigView(PluginAction action)
        {
            InitializeComponent();
            this.radioDisableTemporarily.Text = PluginLanguageManager.PluginStrings.Temporarily;
            this.radioDisablePermanently.Text = PluginLanguageManager.PluginStrings.Permanently;
            this.lblSeconds.Text = PluginLanguageManager.PluginStrings.Seconds;
            this._viewModel = new DisablePiHoleActionConfigViewModel(action);
        }

        private void RadioDisableTemporarily_CheckedChanged(object sender, EventArgs e)
        {
            this.panelConfigureSeconds.Visible = this.radioDisableTemporarily.Checked;
            if (this.radioDisableTemporarily.Checked)
            {
                this.nrSeconds.Value = 10;
            }
        }


        private void RadioDisablePermanently_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioDisablePermanently.Checked)
            {
                this.nrSeconds.Value = 0;
            }
        }

        private void DisablePiHoleActionConfigView_Load(object sender, EventArgs e)
        {
            if (this._viewModel.Seconds == 0)
            {
                this.radioDisablePermanently.Checked = true;
            } else
            {
                this.radioDisableTemporarily.Checked = true;
            }
            this.nrSeconds.Value = this._viewModel.Seconds;
        }

        public override bool OnActionSave()
        {
            this._viewModel.Seconds = (long)this.nrSeconds.Value;
            return this._viewModel.SaveConfig();
        }

    }
}
