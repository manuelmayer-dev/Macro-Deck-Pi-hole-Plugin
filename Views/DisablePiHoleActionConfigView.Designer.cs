
using SuchByte.MacroDeck.GUI.CustomControls;

namespace SuchByte.PiHolePlugin.Views
{
    partial class DisablePiHoleActionConfigView
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.radioDisableTemporarily = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.radioDisablePermanently = new SuchByte.MacroDeck.GUI.CustomControls.TabRadioButton();
            this.panelConfigureSeconds = new System.Windows.Forms.Panel();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.nrSeconds = new System.Windows.Forms.NumericUpDown();
            this.panelConfigureSeconds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nrSeconds)).BeginInit();
            this.SuspendLayout();
            // 
            // radioDisableTemporarily
            // 
            this.radioDisableTemporarily.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioDisableTemporarily.Checked = true;
            this.radioDisableTemporarily.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDisableTemporarily.Location = new System.Drawing.Point(230, 177);
            this.radioDisableTemporarily.Name = "radioDisableTemporarily";
            this.radioDisableTemporarily.Size = new System.Drawing.Size(195, 27);
            this.radioDisableTemporarily.TabIndex = 0;
            this.radioDisableTemporarily.TabStop = true;
            this.radioDisableTemporarily.Text = "Temporarily";
            this.radioDisableTemporarily.UseVisualStyleBackColor = true;
            this.radioDisableTemporarily.CheckedChanged += new System.EventHandler(this.RadioDisableTemporarily_CheckedChanged);
            // 
            // radioDisablePermanently
            // 
            this.radioDisablePermanently.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radioDisablePermanently.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radioDisablePermanently.Location = new System.Drawing.Point(431, 177);
            this.radioDisablePermanently.Name = "radioDisablePermanently";
            this.radioDisablePermanently.Size = new System.Drawing.Size(195, 27);
            this.radioDisablePermanently.TabIndex = 1;
            this.radioDisablePermanently.Text = "Permanently";
            this.radioDisablePermanently.UseVisualStyleBackColor = true;
            this.radioDisablePermanently.CheckedChanged += new System.EventHandler(this.RadioDisablePermanently_CheckedChanged);
            // 
            // panelConfigureSeconds
            // 
            this.panelConfigureSeconds.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelConfigureSeconds.Controls.Add(this.lblSeconds);
            this.panelConfigureSeconds.Controls.Add(this.nrSeconds);
            this.panelConfigureSeconds.Location = new System.Drawing.Point(230, 210);
            this.panelConfigureSeconds.Name = "panelConfigureSeconds";
            this.panelConfigureSeconds.Size = new System.Drawing.Size(259, 38);
            this.panelConfigureSeconds.TabIndex = 2;
            // 
            // lblSeconds
            // 
            this.lblSeconds.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeconds.Location = new System.Drawing.Point(84, 3);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(146, 27);
            this.lblSeconds.TabIndex = 1;
            this.lblSeconds.Text = "Seconds";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nrSeconds
            // 
            this.nrSeconds.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.nrSeconds.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nrSeconds.ForeColor = System.Drawing.Color.White;
            this.nrSeconds.Location = new System.Drawing.Point(3, 3);
            this.nrSeconds.Name = "nrSeconds";
            this.nrSeconds.Size = new System.Drawing.Size(75, 27);
            this.nrSeconds.TabIndex = 0;
            // 
            // DisablePiHoleActionConfigView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panelConfigureSeconds);
            this.Controls.Add(this.radioDisablePermanently);
            this.Controls.Add(this.radioDisableTemporarily);
            this.Name = "DisablePiHoleActionConfigView";
            this.Load += new System.EventHandler(this.DisablePiHoleActionConfigView_Load);
            this.panelConfigureSeconds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nrSeconds)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabRadioButton radioDisableTemporarily;
        private TabRadioButton radioDisablePermanently;
        private System.Windows.Forms.Panel panelConfigureSeconds;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.NumericUpDown nrSeconds;
    }
}
