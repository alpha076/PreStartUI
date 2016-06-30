namespace PreStartUI
{
    partial class Options
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.CMSites = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TargetingModes = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelOpticalMediaError = new System.Windows.Forms.Label();
            this.labelSiteDisableNote1 = new System.Windows.Forms.Label();
            this.SMToolsSites = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 17;
            this.label1.Text = "SMTools URI";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(9, 124);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(373, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "\\\\165.37.230.111\\BuildLogs$";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Logging Share";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(388, 124);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Send Logs";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonClose.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(401, 252);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 7;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // CMSites
            // 
            this.CMSites.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMSites.FormattingEnabled = true;
            this.CMSites.Location = new System.Drawing.Point(12, 80);
            this.CMSites.Name = "CMSites";
            this.CMSites.Size = new System.Drawing.Size(137, 22);
            this.CMSites.TabIndex = 2;
            this.CMSites.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 14);
            this.label3.TabIndex = 15;
            this.label3.Text = "Config Manager Site";
            // 
            // TargetingModes
            // 
            this.TargetingModes.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TargetingModes.FormattingEnabled = true;
            this.TargetingModes.Location = new System.Drawing.Point(329, 80);
            this.TargetingModes.Name = "TargetingModes";
            this.TargetingModes.Size = new System.Drawing.Size(137, 22);
            this.TargetingModes.TabIndex = 3;
            this.TargetingModes.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(326, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 14);
            this.label5.TabIndex = 0;
            this.label5.Text = "Targeting Mode";
            // 
            // labelOpticalMediaError
            // 
            this.labelOpticalMediaError.AutoSize = true;
            this.labelOpticalMediaError.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOpticalMediaError.ForeColor = System.Drawing.Color.Red;
            this.labelOpticalMediaError.Location = new System.Drawing.Point(9, 264);
            this.labelOpticalMediaError.Name = "labelOpticalMediaError";
            this.labelOpticalMediaError.Size = new System.Drawing.Size(217, 14);
            this.labelOpticalMediaError.TabIndex = 18;
            this.labelOpticalMediaError.Text = "*data path is on optical media";
            this.labelOpticalMediaError.Visible = false;
            // 
            // labelSiteDisableNote1
            // 
            this.labelSiteDisableNote1.AutoSize = true;
            this.labelSiteDisableNote1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSiteDisableNote1.ForeColor = System.Drawing.Color.Red;
            this.labelSiteDisableNote1.Location = new System.Drawing.Point(155, 83);
            this.labelSiteDisableNote1.Name = "labelSiteDisableNote1";
            this.labelSiteDisableNote1.Size = new System.Drawing.Size(14, 14);
            this.labelSiteDisableNote1.TabIndex = 19;
            this.labelSiteDisableNote1.Text = "*";
            this.labelSiteDisableNote1.Visible = false;
            // 
            // SMToolsSites
            // 
            this.SMToolsSites.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SMToolsSites.FormattingEnabled = true;
            this.SMToolsSites.Location = new System.Drawing.Point(12, 30);
            this.SMToolsSites.Name = "SMToolsSites";
            this.SMToolsSites.Size = new System.Drawing.Size(454, 22);
            this.SMToolsSites.TabIndex = 20;
            this.SMToolsSites.SelectedIndexChanged += new System.EventHandler(this.SMToolsSites_SelectedIndexChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(488, 287);
            this.ControlBox = false;
            this.Controls.Add(this.SMToolsSites);
            this.Controls.Add(this.labelSiteDisableNote1);
            this.Controls.Add(this.labelOpticalMediaError);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TargetingModes);
            this.Controls.Add(this.CMSites);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Options";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OS Deployment Options";
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonClose;
        public System.Windows.Forms.ComboBox CMSites;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox TargetingModes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelOpticalMediaError;
        private System.Windows.Forms.Label labelSiteDisableNote1;
        public System.Windows.Forms.ComboBox SMToolsSites;
    }
}