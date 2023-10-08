using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.PiHolePlugin.Language;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuchByte.PiHolePlugin.Views;

public partial class PluginConfigurationView : DialogForm
{
    public PluginConfigurationView()
    {
        InitializeComponent();

        this.lblHost.Text = PluginLanguageManager.PluginStrings.Host;
        this.lblExampleHost.Text = PluginLanguageManager.PluginStrings.ExampleHost;
        this.lblToken.Text = PluginLanguageManager.PluginStrings.Token;
        this.lblTokenLocation.Text = PluginLanguageManager.PluginStrings.TokenLocation;
        this.btnOk.Text = LanguageManager.Strings.Ok;
    }

    private void PluginConfigurationView_Load(object sender, EventArgs e)
    {
        this.txtHost.Text = PluginConfigurationHelper.GetHost();
        this.txtToken.Text = CredentialsHelper.GetToken();
    }

    private void BtnOk_Click(object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(this.txtHost.Text) || !this.txtHost.Text.Contains("://"))
        {
            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
            {
                msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.InvalidHost, MessageBoxButtons.OK);
            }
            return;
        }

        if (string.IsNullOrWhiteSpace(this.txtToken.Text))
        {
            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
            {
                msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.InvalidToken, MessageBoxButtons.OK);
            }

            return;
        }

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
                        msgBox.ShowDialog("Pi-hole", PluginLanguageManager.PluginStrings.SuccessfullyConnectedToPiHole, MessageBoxButtons.OK);
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
                        msgBox.ShowDialog("Pi-hole", PluginLanguageManager.PluginStrings.FailedToConnectToPiHole, MessageBoxButtons.OK);
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