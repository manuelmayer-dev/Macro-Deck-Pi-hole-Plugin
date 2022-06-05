using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuchByte.PiHolePlugin.Views
{
    public partial class PluginConfigurationView : DialogForm
    {
        public PluginConfigurationView()
        {
            InitializeComponent();
        }

        private void PluginConfigurationView_Load(object sender, EventArgs e)
        {
            this.txtHost.Text = PluginConfigurationHelper.GetHost();
            this.txtToken.Text = CredentialsHelper.GetToken();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.txtHost.Enabled = false;
            this.txtToken.Enabled = false;
            this.btnOk.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            
            Task.Run(() =>
            {
                if (PiHoleHelper.Connect(txtHost.Text, txtToken.Text).Result)
                {
                    this.Invoke(new Action(() =>
                    {
                        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                        {
                            msgBox.ShowDialog("Pi-hole", $"Successfully connected to Pi-hole @{this.txtHost.Text}", MessageBoxButtons.OK);
                        }
                        PluginConfigurationHelper.UpdateHost(this.txtHost.Text);
                        CredentialsHelper.UpdateToken(this.txtToken.Text);
                        this.Close();
                    }));
                } else
                {
                    this.Invoke(new Action(() =>
                    {
                        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                        {
                            msgBox.ShowDialog("Pi-hole", $"Failed to connected to Pi-hole. Make sure Pi-hole is running and you entered the correct host and token.", MessageBoxButtons.OK);
                        }
                        this.txtHost.Enabled = true;
                        this.txtToken.Enabled = true;
                        this.btnOk.Enabled = true;
                        this.Cursor = Cursors.Default;
                    }));
                }
            });
        }
    }
}
