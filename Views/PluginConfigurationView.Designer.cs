
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.PiHolePlugin.Views
{
    partial class PluginConfigurationView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtHost = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.btnOk = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblToken = new System.Windows.Forms.Label();
            this.txtToken = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.lblExampleHost = new System.Windows.Forms.Label();
            this.lblTokenLocation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtHost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtHost.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtHost.Icon = null;
            this.txtHost.Location = new System.Drawing.Point(144, 22);
            this.txtHost.MaxCharacters = 32767;
            this.txtHost.Multiline = false;
            this.txtHost.Name = "txtHost";
            this.txtHost.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.txtHost.PasswordChar = false;
            this.txtHost.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtHost.PlaceHolderText = "";
            this.txtHost.ReadOnly = false;
            this.txtHost.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtHost.SelectionStart = 0;
            this.txtHost.Size = new System.Drawing.Size(456, 30);
            this.txtHost.TabIndex = 2;
            this.txtHost.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // btnOk
            // 
            this.btnOk.BorderRadius = 8;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnOk.ForeColor = System.Drawing.Color.White;
            this.btnOk.HoverColor = System.Drawing.Color.Empty;
            this.btnOk.Icon = null;
            this.btnOk.Location = new System.Drawing.Point(551, 163);
            this.btnOk.Name = "btnOk";
            this.btnOk.Progress = 0;
            this.btnOk.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.btnOk.Size = new System.Drawing.Size(75, 25);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.UseWindowsAccentColor = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // lblHost
            // 
            this.lblHost.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHost.Location = new System.Drawing.Point(39, 22);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(99, 30);
            this.lblHost.TabIndex = 4;
            this.lblHost.Text = "Host";
            this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblToken
            // 
            this.lblToken.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblToken.Location = new System.Drawing.Point(39, 86);
            this.lblToken.Name = "lblToken";
            this.lblToken.Size = new System.Drawing.Size(99, 30);
            this.lblToken.TabIndex = 5;
            this.lblToken.Text = "Token";
            this.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtToken
            // 
            this.txtToken.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.txtToken.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtToken.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtToken.Icon = null;
            this.txtToken.Location = new System.Drawing.Point(144, 86);
            this.txtToken.MaxCharacters = 32767;
            this.txtToken.Multiline = false;
            this.txtToken.Name = "txtToken";
            this.txtToken.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.txtToken.PasswordChar = true;
            this.txtToken.PlaceHolderColor = System.Drawing.Color.Gray;
            this.txtToken.PlaceHolderText = "";
            this.txtToken.ReadOnly = false;
            this.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtToken.SelectionStart = 0;
            this.txtToken.Size = new System.Drawing.Size(456, 30);
            this.txtToken.TabIndex = 6;
            this.txtToken.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // lblExampleHost
            // 
            this.lblExampleHost.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblExampleHost.ForeColor = System.Drawing.Color.Silver;
            this.lblExampleHost.Location = new System.Drawing.Point(144, 55);
            this.lblExampleHost.Name = "lblExampleHost";
            this.lblExampleHost.Size = new System.Drawing.Size(456, 18);
            this.lblExampleHost.TabIndex = 7;
            this.lblExampleHost.Text = "e.g. \"http://pi-hole\" or \"http://192.168.178.62\"";
            this.lblExampleHost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTokenLocation
            // 
            this.lblTokenLocation.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTokenLocation.ForeColor = System.Drawing.Color.Silver;
            this.lblTokenLocation.Location = new System.Drawing.Point(144, 119);
            this.lblTokenLocation.Name = "lblTokenLocation";
            this.lblTokenLocation.Size = new System.Drawing.Size(456, 18);
            this.lblTokenLocation.TabIndex = 8;
            this.lblTokenLocation.Text = "Settings -> API / Web interface -> API settings -> Show API token";
            this.lblTokenLocation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PluginConfigurationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(639, 202);
            this.Controls.Add(this.lblTokenLocation);
            this.Controls.Add(this.lblExampleHost);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.lblToken);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtHost);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "PluginConfigurationView";
            this.Text = "PluginConfigurationView";
            this.Load += new System.EventHandler(this.PluginConfigurationView_Load);
            this.Controls.SetChildIndex(this.txtHost, 0);
            this.Controls.SetChildIndex(this.btnOk, 0);
            this.Controls.SetChildIndex(this.lblHost, 0);
            this.Controls.SetChildIndex(this.lblToken, 0);
            this.Controls.SetChildIndex(this.txtToken, 0);
            this.Controls.SetChildIndex(this.lblExampleHost, 0);
            this.Controls.SetChildIndex(this.lblTokenLocation, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private RoundedTextBox txtHost;
        private ButtonPrimary btnOk;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblToken;
        private RoundedTextBox txtToken;
        private System.Windows.Forms.Label lblExampleHost;
        private System.Windows.Forms.Label lblTokenLocation;
    }
}