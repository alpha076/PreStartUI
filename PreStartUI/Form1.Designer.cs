namespace PreStartUI
{
    partial class mainForm
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
            this.components = new System.ComponentModel.Container();
            this.OKButton = new System.Windows.Forms.Button();
            this.CnclButton = new System.Windows.Forms.Button();
            this.WMIHWInfo = new System.Windows.Forms.Label();
            this.HWGroupBox = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.diskTree = new System.Windows.Forms.TreeView();
            this.label4 = new System.Windows.Forms.Label();
            this.BIOSVersionLabel = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.BootMode = new System.Windows.Forms.Label();
            this.BIOSInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Continue = new System.Windows.Forms.Button();
            this.TSMediaErrorLabel = new System.Windows.Forms.Label();
            this.smtoolsStatusLabel = new System.Windows.Forms.Label();
            this.UUIDError = new System.Windows.Forms.Label();
            this.SMToolsIDError = new System.Windows.Forms.Label();
            this.PriUserError = new System.Windows.Forms.Label();
            this.UUIDTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.installerID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.primaryUser = new System.Windows.Forms.TextBox();
            this.UUIDLabel = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanDisk = new System.Windows.Forms.ToolStripMenuItem();
            this.networkTest = new System.Windows.Forms.Timer(this.components);
            this.HWGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.OKButton.Location = new System.Drawing.Point(622, 112);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(88, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "Submit";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CnclButton
            // 
            this.CnclButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CnclButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CnclButton.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.CnclButton.Location = new System.Drawing.Point(526, 112);
            this.CnclButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.CnclButton.Name = "CnclButton";
            this.CnclButton.Size = new System.Drawing.Size(88, 25);
            this.CnclButton.TabIndex = 1;
            this.CnclButton.Text = "Cancel";
            this.CnclButton.UseVisualStyleBackColor = true;
            this.CnclButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // WMIHWInfo
            // 
            this.WMIHWInfo.AutoSize = true;
            this.WMIHWInfo.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.WMIHWInfo.Location = new System.Drawing.Point(8, 22);
            this.WMIHWInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.WMIHWInfo.Name = "WMIHWInfo";
            this.WMIHWInfo.Size = new System.Drawing.Size(140, 15);
            this.WMIHWInfo.TabIndex = 4;
            this.WMIHWInfo.Text = "Manufacturer, Model";
            // 
            // HWGroupBox
            // 
            this.HWGroupBox.Controls.Add(this.label5);
            this.HWGroupBox.Controls.Add(this.diskTree);
            this.HWGroupBox.Controls.Add(this.label4);
            this.HWGroupBox.Controls.Add(this.BIOSVersionLabel);
            this.HWGroupBox.Controls.Add(this.treeView1);
            this.HWGroupBox.Controls.Add(this.BootMode);
            this.HWGroupBox.Controls.Add(this.BIOSInfo);
            this.HWGroupBox.Controls.Add(this.WMIHWInfo);
            this.HWGroupBox.Location = new System.Drawing.Point(17, 33);
            this.HWGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HWGroupBox.Name = "HWGroupBox";
            this.HWGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.HWGroupBox.Size = new System.Drawing.Size(814, 249);
            this.HWGroupBox.TabIndex = 5;
            this.HWGroupBox.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label5.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(358, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(175, 15);
            this.label5.TabIndex = 11;
            this.label5.Tag = "";
            this.label5.Text = "Disks (click to refresh)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // diskTree
            // 
            this.diskTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.diskTree.Location = new System.Drawing.Point(362, 163);
            this.diskTree.Name = "diskTree";
            this.diskTree.Size = new System.Drawing.Size(445, 80);
            this.diskTree.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(358, 16);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Network Adapters (click to refresh)";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // BIOSVersionLabel
            // 
            this.BIOSVersionLabel.AutoSize = true;
            this.BIOSVersionLabel.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.BIOSVersionLabel.Location = new System.Drawing.Point(8, 50);
            this.BIOSVersionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BIOSVersionLabel.Name = "BIOSVersionLabel";
            this.BIOSVersionLabel.Size = new System.Drawing.Size(91, 15);
            this.BIOSVersionLabel.TabIndex = 8;
            this.BIOSVersionLabel.Text = "BIOS Version";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(360, 35);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(446, 107);
            this.treeView1.TabIndex = 7;
            // 
            // BootMode
            // 
            this.BootMode.AutoSize = true;
            this.BootMode.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.BootMode.Location = new System.Drawing.Point(8, 65);
            this.BootMode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BootMode.Name = "BootMode";
            this.BootMode.Size = new System.Drawing.Size(70, 15);
            this.BootMode.TabIndex = 6;
            this.BootMode.Text = "Boot Mode";
            // 
            // BIOSInfo
            // 
            this.BIOSInfo.AutoSize = true;
            this.BIOSInfo.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.BIOSInfo.Location = new System.Drawing.Point(8, 35);
            this.BIOSInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BIOSInfo.Name = "BIOSInfo";
            this.BIOSInfo.Size = new System.Drawing.Size(70, 15);
            this.BIOSInfo.TabIndex = 5;
            this.BIOSInfo.Text = "BIOS Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 346);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 14);
            this.label1.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Continue);
            this.groupBox2.Controls.Add(this.TSMediaErrorLabel);
            this.groupBox2.Controls.Add(this.smtoolsStatusLabel);
            this.groupBox2.Controls.Add(this.UUIDError);
            this.groupBox2.Controls.Add(this.SMToolsIDError);
            this.groupBox2.Controls.Add(this.PriUserError);
            this.groupBox2.Controls.Add(this.UUIDTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.installerID);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.primaryUser);
            this.groupBox2.Controls.Add(this.UUIDLabel);
            this.groupBox2.Controls.Add(this.OKButton);
            this.groupBox2.Controls.Add(this.CnclButton);
            this.groupBox2.Location = new System.Drawing.Point(16, 288);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(814, 145);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // Continue
            // 
            this.Continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Continue.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.Continue.Location = new System.Drawing.Point(718, 112);
            this.Continue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Continue.Name = "Continue";
            this.Continue.Size = new System.Drawing.Size(88, 25);
            this.Continue.TabIndex = 23;
            this.Continue.Text = "Continue";
            this.Continue.UseVisualStyleBackColor = true;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // TSMediaErrorLabel
            // 
            this.TSMediaErrorLabel.AutoSize = true;
            this.TSMediaErrorLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TSMediaErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.TSMediaErrorLabel.Location = new System.Drawing.Point(1, 123);
            this.TSMediaErrorLabel.Name = "TSMediaErrorLabel";
            this.TSMediaErrorLabel.Size = new System.Drawing.Size(266, 14);
            this.TSMediaErrorLabel.TabIndex = 10;
            this.TSMediaErrorLabel.Text = "*Could not locate task sequence media";
            this.TSMediaErrorLabel.Click += new System.EventHandler(this.TSMediaErrorLabel_Click);
            // 
            // smtoolsStatusLabel
            // 
            this.smtoolsStatusLabel.AutoSize = true;
            this.smtoolsStatusLabel.Location = new System.Drawing.Point(8, 123);
            this.smtoolsStatusLabel.Name = "smtoolsStatusLabel";
            this.smtoolsStatusLabel.Size = new System.Drawing.Size(0, 14);
            this.smtoolsStatusLabel.TabIndex = 22;
            // 
            // UUIDError
            // 
            this.UUIDError.AutoSize = true;
            this.UUIDError.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.UUIDError.ForeColor = System.Drawing.Color.Red;
            this.UUIDError.Location = new System.Drawing.Point(134, 72);
            this.UUIDError.Name = "UUIDError";
            this.UUIDError.Size = new System.Drawing.Size(70, 15);
            this.UUIDError.TabIndex = 21;
            this.UUIDError.Text = "*Required";
            this.UUIDError.Visible = false;
            // 
            // SMToolsIDError
            // 
            this.SMToolsIDError.AutoSize = true;
            this.SMToolsIDError.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.SMToolsIDError.ForeColor = System.Drawing.Color.Red;
            this.SMToolsIDError.Location = new System.Drawing.Point(372, 47);
            this.SMToolsIDError.Name = "SMToolsIDError";
            this.SMToolsIDError.Size = new System.Drawing.Size(133, 15);
            this.SMToolsIDError.TabIndex = 20;
            this.SMToolsIDError.Text = "*Required (userid)";
            this.SMToolsIDError.Visible = false;
            // 
            // PriUserError
            // 
            this.PriUserError.AutoSize = true;
            this.PriUserError.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.PriUserError.ForeColor = System.Drawing.Color.Red;
            this.PriUserError.Location = new System.Drawing.Point(373, 22);
            this.PriUserError.Name = "PriUserError";
            this.PriUserError.Size = new System.Drawing.Size(182, 15);
            this.PriUserError.TabIndex = 19;
            this.PriUserError.Text = "*Required (domain\\userid)";
            this.PriUserError.Visible = false;
            // 
            // UUIDTextBox
            // 
            this.UUIDTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.UUIDTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.UUIDTextBox.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.UUIDTextBox.ForeColor = System.Drawing.Color.Blue;
            this.UUIDTextBox.Location = new System.Drawing.Point(4, 90);
            this.UUIDTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.UUIDTextBox.Name = "UUIDTextBox";
            this.UUIDTextBox.ReadOnly = true;
            this.UUIDTextBox.Size = new System.Drawing.Size(697, 16);
            this.UUIDTextBox.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label3.Location = new System.Drawing.Point(1, 42);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "SMTools ID";
            // 
            // installerID
            // 
            this.installerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installerID.Location = new System.Drawing.Point(124, 42);
            this.installerID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.installerID.Name = "installerID";
            this.installerID.Size = new System.Drawing.Size(241, 22);
            this.installerID.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.label2.Location = new System.Drawing.Point(1, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Primary User";
            // 
            // primaryUser
            // 
            this.primaryUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.primaryUser.Location = new System.Drawing.Point(124, 14);
            this.primaryUser.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.primaryUser.Name = "primaryUser";
            this.primaryUser.Size = new System.Drawing.Size(241, 22);
            this.primaryUser.TabIndex = 14;
            this.primaryUser.WordWrap = false;
            // 
            // UUIDLabel
            // 
            this.UUIDLabel.AutoSize = true;
            this.UUIDLabel.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.UUIDLabel.Location = new System.Drawing.Point(1, 72);
            this.UUIDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UUIDLabel.Name = "UUIDLabel";
            this.UUIDLabel.Size = new System.Drawing.Size(126, 15);
            this.UUIDLabel.TabIndex = 13;
            this.UUIDLabel.Text = "UUID\\SMBIOS GUID:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 17, 0);
            this.statusStrip1.Size = new System.Drawing.Size(843, 22);
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Consolas", 9.75F);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(794, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(843, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.advancedToolStripMenuItem,
            this.openShellToolStripMenuItem,
            this.startRemoteToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 20);
            this.toolStripMenuItem1.Text = "Options";
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.advancedToolStripMenuItem.Text = "Advanced";
            this.advancedToolStripMenuItem.Click += new System.EventHandler(this.advancedToolStripMenuItem_Click);
            // 
            // openShellToolStripMenuItem
            // 
            this.openShellToolStripMenuItem.Name = "openShellToolStripMenuItem";
            this.openShellToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.openShellToolStripMenuItem.Text = "Open Shell";
            this.openShellToolStripMenuItem.Click += new System.EventHandler(this.openShellToolStripMenuItem_Click);
            // 
            // startRemoteToolStripMenuItem
            // 
            this.startRemoteToolStripMenuItem.Name = "startRemoteToolStripMenuItem";
            this.startRemoteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.startRemoteToolStripMenuItem.Text = "Start Remote";
            this.startRemoteToolStripMenuItem.Click += new System.EventHandler(this.startRemoteToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // cleanDisk
            // 
            this.cleanDisk.Name = "cleanDisk";
            this.cleanDisk.Size = new System.Drawing.Size(32, 19);
            // 
            // networkTest
            // 
            this.networkTest.Interval = 60000;
            this.networkTest.Tick += new System.EventHandler(this.networkTest_Tick);
            // 
            // mainForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.CancelButton = this.CnclButton;
            this.ClientSize = new System.Drawing.Size(843, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HWGroupBox);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(859, 500);
            this.MinimumSize = new System.Drawing.Size(859, 451);
            this.Name = "mainForm";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank of America OS Deployment Automation";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_Closing);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.HWGroupBox.ResumeLayout(false);
            this.HWGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CnclButton;
        private System.Windows.Forms.Label WMIHWInfo;
        private System.Windows.Forms.GroupBox HWGroupBox;
        private System.Windows.Forms.Label BootMode;
        private System.Windows.Forms.Label BIOSInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox UUIDTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox installerID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox primaryUser;
        private System.Windows.Forms.Label UUIDLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label BIOSVersionLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem advancedToolStripMenuItem;
        private System.Windows.Forms.Label SMToolsIDError;
        private System.Windows.Forms.Label PriUserError;
        private System.Windows.Forms.Label UUIDError;
        private System.Windows.Forms.Label smtoolsStatusLabel;
        private System.Windows.Forms.Label TSMediaErrorLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TreeView diskTree;
        private System.Windows.Forms.ToolStripMenuItem openShellToolStripMenuItem;
        private System.Windows.Forms.Button Continue;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startRemoteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip diskOptions;
        private System.Windows.Forms.ToolStripMenuItem cleanDisk;
        private System.Windows.Forms.Timer networkTest;
    }
}

