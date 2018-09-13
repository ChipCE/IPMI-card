namespace ConsoleController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.gitLink = new System.Windows.Forms.LinkLabel();
            this.appConfTab = new System.Windows.Forms.TabPage();
            this.appConfGroupBox = new System.Windows.Forms.GroupBox();
            this.configBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.rebootBtn = new System.Windows.Forms.Button();
            this.startupLabel = new System.Windows.Forms.Label();
            this.tooltipLabel = new System.Windows.Forms.Label();
            this.enableLabel = new System.Windows.Forms.Label();
            this.disconnectBtn = new System.Windows.Forms.Button();
            this.durationComboBox = new System.Windows.Forms.ComboBox();
            this.tooltipDurationLabel = new System.Windows.Forms.Label();
            this.tooltipCheckbox = new System.Windows.Forms.CheckBox();
            this.baudLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.baudComboBox = new System.Windows.Forms.ComboBox();
            this.comPortComboBox = new System.Windows.Forms.ComboBox();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.appNameLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.buildLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.shellLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.aboutTab.SuspendLayout();
            this.appConfTab.SuspendLayout();
            this.appConfGroupBox.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 463);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(577, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(26, 17);
            this.statusLabel.Text = "Idle";
            // 
            // logTextBox
            // 
            this.logTextBox.AcceptsReturn = true;
            this.logTextBox.AcceptsTab = true;
            this.logTextBox.Location = new System.Drawing.Point(3, 6);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.logTextBox.Size = new System.Drawing.Size(559, 138);
            this.logTextBox.TabIndex = 0;
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.trayMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Console Controller";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(104, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 283);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 178);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 152);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Log";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.debugTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 152);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Debug";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // debugTextBox
            // 
            this.debugTextBox.Location = new System.Drawing.Point(0, 4);
            this.debugTextBox.Multiline = true;
            this.debugTextBox.Name = "debugTextBox";
            this.debugTextBox.ReadOnly = true;
            this.debugTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.debugTextBox.Size = new System.Drawing.Size(562, 140);
            this.debugTextBox.TabIndex = 0;
            // 
            // aboutTab
            // 
            this.aboutTab.Controls.Add(this.shellLabel);
            this.aboutTab.Controls.Add(this.richTextBox1);
            this.aboutTab.Controls.Add(this.buildLabel);
            this.aboutTab.Controls.Add(this.versionLabel);
            this.aboutTab.Controls.Add(this.appNameLabel);
            this.aboutTab.Controls.Add(this.gitLink);
            this.aboutTab.Location = new System.Drawing.Point(4, 22);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(569, 253);
            this.aboutTab.TabIndex = 2;
            this.aboutTab.Text = "About";
            this.aboutTab.UseVisualStyleBackColor = true;
            // 
            // gitLink
            // 
            this.gitLink.AutoSize = true;
            this.gitLink.Location = new System.Drawing.Point(4, 92);
            this.gitLink.Name = "gitLink";
            this.gitLink.Size = new System.Drawing.Size(209, 13);
            this.gitLink.TabIndex = 1;
            this.gitLink.TabStop = true;
            this.gitLink.Text = "https://github.com/ChipTechno/IPMI-card";
            this.gitLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gitLink_LinkClicked);
            // 
            // appConfTab
            // 
            this.appConfTab.Controls.Add(this.appConfGroupBox);
            this.appConfTab.Location = new System.Drawing.Point(4, 22);
            this.appConfTab.Name = "appConfTab";
            this.appConfTab.Padding = new System.Windows.Forms.Padding(3);
            this.appConfTab.Size = new System.Drawing.Size(569, 253);
            this.appConfTab.TabIndex = 0;
            this.appConfTab.Text = "Application config";
            this.appConfTab.UseVisualStyleBackColor = true;
            // 
            // appConfGroupBox
            // 
            this.appConfGroupBox.Controls.Add(this.configBtn);
            this.appConfGroupBox.Controls.Add(this.clearBtn);
            this.appConfGroupBox.Controls.Add(this.rebootBtn);
            this.appConfGroupBox.Controls.Add(this.startupLabel);
            this.appConfGroupBox.Controls.Add(this.tooltipLabel);
            this.appConfGroupBox.Controls.Add(this.enableLabel);
            this.appConfGroupBox.Controls.Add(this.disconnectBtn);
            this.appConfGroupBox.Controls.Add(this.durationComboBox);
            this.appConfGroupBox.Controls.Add(this.tooltipDurationLabel);
            this.appConfGroupBox.Controls.Add(this.tooltipCheckbox);
            this.appConfGroupBox.Controls.Add(this.baudLabel);
            this.appConfGroupBox.Controls.Add(this.saveBtn);
            this.appConfGroupBox.Controls.Add(this.startupCheckBox);
            this.appConfGroupBox.Controls.Add(this.enableCheckBox);
            this.appConfGroupBox.Controls.Add(this.connectBtn);
            this.appConfGroupBox.Controls.Add(this.refreshBtn);
            this.appConfGroupBox.Controls.Add(this.baudComboBox);
            this.appConfGroupBox.Controls.Add(this.comPortComboBox);
            this.appConfGroupBox.Controls.Add(this.comPortLabel);
            this.appConfGroupBox.Location = new System.Drawing.Point(9, 7);
            this.appConfGroupBox.Name = "appConfGroupBox";
            this.appConfGroupBox.Size = new System.Drawing.Size(552, 242);
            this.appConfGroupBox.TabIndex = 0;
            this.appConfGroupBox.TabStop = false;
            this.appConfGroupBox.Text = "Application config";
            // 
            // configBtn
            // 
            this.configBtn.Enabled = false;
            this.configBtn.Location = new System.Drawing.Point(413, 211);
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(133, 23);
            this.configBtn.TabIndex = 13;
            this.configBtn.Text = "Config";
            this.configBtn.UseVisualStyleBackColor = true;
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // clearBtn
            // 
            this.clearBtn.Enabled = false;
            this.clearBtn.Location = new System.Drawing.Point(267, 211);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(133, 23);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // rebootBtn
            // 
            this.rebootBtn.Enabled = false;
            this.rebootBtn.Location = new System.Drawing.Point(120, 211);
            this.rebootBtn.Name = "rebootBtn";
            this.rebootBtn.Size = new System.Drawing.Size(133, 23);
            this.rebootBtn.TabIndex = 11;
            this.rebootBtn.Text = "Reboot";
            this.rebootBtn.UseVisualStyleBackColor = true;
            this.rebootBtn.Click += new System.EventHandler(this.rebootBtn_Click);
            // 
            // startupLabel
            // 
            this.startupLabel.AutoSize = true;
            this.startupLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.startupLabel.Location = new System.Drawing.Point(23, 149);
            this.startupLabel.Name = "startupLabel";
            this.startupLabel.Size = new System.Drawing.Size(366, 13);
            this.startupLabel.TabIndex = 14;
            this.startupLabel.Text = "Write registry entry to SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
            // 
            // tooltipLabel
            // 
            this.tooltipLabel.AutoSize = true;
            this.tooltipLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.tooltipLabel.Location = new System.Drawing.Point(23, 113);
            this.tooltipLabel.Name = "tooltipLabel";
            this.tooltipLabel.Size = new System.Drawing.Size(211, 13);
            this.tooltipLabel.TabIndex = 13;
            this.tooltipLabel.Text = "Show tooltip when excute Powershell script";
            // 
            // enableLabel
            // 
            this.enableLabel.AutoSize = true;
            this.enableLabel.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.enableLabel.Location = new System.Drawing.Point(26, 75);
            this.enableLabel.Name = "enableLabel";
            this.enableLabel.Size = new System.Drawing.Size(242, 13);
            this.enableLabel.TabIndex = 12;
            this.enableLabel.Text = "Allow IPMI module to control Windows Powershell";
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Enabled = false;
            this.disconnectBtn.Location = new System.Drawing.Point(10, 182);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(100, 23);
            this.disconnectBtn.TabIndex = 8;
            this.disconnectBtn.Text = "Disconnect";
            this.disconnectBtn.UseVisualStyleBackColor = true;
            this.disconnectBtn.Click += new System.EventHandler(this.disconnectBtn_Click);
            // 
            // durationComboBox
            // 
            this.durationComboBox.FormattingEnabled = true;
            this.durationComboBox.Items.AddRange(new object[] {
            "200",
            "300",
            "500",
            "1000",
            "2000",
            "3000",
            "5000"});
            this.durationComboBox.Location = new System.Drawing.Point(425, 89);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(121, 21);
            this.durationComboBox.TabIndex = 6;
            this.durationComboBox.Text = "--Select--";
            // 
            // tooltipDurationLabel
            // 
            this.tooltipDurationLabel.AutoSize = true;
            this.tooltipDurationLabel.Location = new System.Drawing.Point(317, 94);
            this.tooltipDurationLabel.Name = "tooltipDurationLabel";
            this.tooltipDurationLabel.Size = new System.Drawing.Size(99, 13);
            this.tooltipDurationLabel.TabIndex = 10;
            this.tooltipDurationLabel.Text = "Tooltip duration(ms)";
            // 
            // tooltipCheckbox
            // 
            this.tooltipCheckbox.AutoSize = true;
            this.tooltipCheckbox.Location = new System.Drawing.Point(10, 93);
            this.tooltipCheckbox.Name = "tooltipCheckbox";
            this.tooltipCheckbox.Size = new System.Drawing.Size(203, 17);
            this.tooltipCheckbox.TabIndex = 5;
            this.tooltipCheckbox.Text = "Show tooltip when execute command";
            this.tooltipCheckbox.UseVisualStyleBackColor = true;
            // 
            // baudLabel
            // 
            this.baudLabel.AutoSize = true;
            this.baudLabel.Location = new System.Drawing.Point(308, 25);
            this.baudLabel.Name = "baudLabel";
            this.baudLabel.Size = new System.Drawing.Size(53, 13);
            this.baudLabel.TabIndex = 8;
            this.baudLabel.Text = "Baud rate";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 211);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(100, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Save setting";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(10, 129);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(199, 17);
            this.startupCheckBox.TabIndex = 7;
            this.startupCheckBox.Text = "Start application on Windows startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Location = new System.Drawing.Point(10, 55);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(94, 17);
            this.enableCheckBox.TabIndex = 4;
            this.enableCheckBox.Text = "Enable control";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(120, 182);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(426, 23);
            this.connectBtn.TabIndex = 9;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(484, 19);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(62, 23);
            this.refreshBtn.TabIndex = 3;
            this.refreshBtn.Text = "Refresh";
            this.refreshBtn.UseVisualStyleBackColor = true;
            this.refreshBtn.Click += new System.EventHandler(this.refreshBtn_Click);
            // 
            // baudComboBox
            // 
            this.baudComboBox.FormattingEnabled = true;
            this.baudComboBox.Items.AddRange(new object[] {
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000",
            "256000"});
            this.baudComboBox.Location = new System.Drawing.Point(367, 22);
            this.baudComboBox.Name = "baudComboBox";
            this.baudComboBox.Size = new System.Drawing.Size(111, 21);
            this.baudComboBox.TabIndex = 2;
            this.baudComboBox.Text = "--Select--";
            // 
            // comPortComboBox
            // 
            this.comPortComboBox.FormattingEnabled = true;
            this.comPortComboBox.Location = new System.Drawing.Point(66, 22);
            this.comPortComboBox.Name = "comPortComboBox";
            this.comPortComboBox.Size = new System.Drawing.Size(236, 21);
            this.comPortComboBox.TabIndex = 1;
            this.comPortComboBox.Text = "--Select--";
            // 
            // comPortLabel
            // 
            this.comPortLabel.AutoSize = true;
            this.comPortLabel.Location = new System.Drawing.Point(7, 25);
            this.comPortLabel.Name = "comPortLabel";
            this.comPortLabel.Size = new System.Drawing.Size(53, 13);
            this.comPortLabel.TabIndex = 0;
            this.comPortLabel.Text = "COM Port";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.appConfTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(577, 279);
            this.tabControl.TabIndex = 9;
            // 
            // appNameLabel
            // 
            this.appNameLabel.AutoSize = true;
            this.appNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appNameLabel.Location = new System.Drawing.Point(3, 10);
            this.appNameLabel.Name = "appNameLabel";
            this.appNameLabel.Size = new System.Drawing.Size(236, 20);
            this.appNameLabel.TabIndex = 2;
            this.appNameLabel.Text = "Generic IPMI Console Controller";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(4, 35);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(90, 13);
            this.versionLabel.TabIndex = 3;
            this.versionLabel.Text = "Version : 1.1 beta";
            // 
            // buildLabel
            // 
            this.buildLabel.AutoSize = true;
            this.buildLabel.Location = new System.Drawing.Point(4, 55);
            this.buildLabel.Name = "buildLabel";
            this.buildLabel.Size = new System.Drawing.Size(87, 13);
            this.buildLabel.TabIndex = 4;
            this.buildLabel.Text = "Build : 20180913";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(4, 113);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(562, 137);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "Generic IPMI Console Controller\n\nChange log : v1.0 beta\nKnown bugs\n   - none :3\nT" +
    "o-do\n   - Remove Debug mode in stable release.";
            // 
            // shellLabel
            // 
            this.shellLabel.AutoSize = true;
            this.shellLabel.Location = new System.Drawing.Point(4, 75);
            this.shellLabel.Name = "shellLabel";
            this.shellLabel.Size = new System.Drawing.Size(136, 13);
            this.shellLabel.TabIndex = 6;
            this.shellLabel.Text = "Shell : Windows powershell";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 485);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Console Controller 1.1 beta";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.aboutTab.ResumeLayout(false);
            this.aboutTab.PerformLayout();
            this.appConfTab.ResumeLayout(false);
            this.appConfGroupBox.ResumeLayout(false);
            this.appConfGroupBox.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox debugTextBox;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.TabPage appConfTab;
        private System.Windows.Forms.GroupBox appConfGroupBox;
        private System.Windows.Forms.Button configBtn;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.Button rebootBtn;
        private System.Windows.Forms.Label startupLabel;
        private System.Windows.Forms.Label tooltipLabel;
        private System.Windows.Forms.Label enableLabel;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.ComboBox durationComboBox;
        private System.Windows.Forms.Label tooltipDurationLabel;
        private System.Windows.Forms.CheckBox tooltipCheckbox;
        private System.Windows.Forms.Label baudLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ComboBox baudComboBox;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.LinkLabel gitLink;
        private System.Windows.Forms.Label appNameLabel;
        private System.Windows.Forms.Label buildLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label shellLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

