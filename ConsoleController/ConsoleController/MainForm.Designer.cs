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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.appConfTab = new System.Windows.Forms.TabPage();
            this.appConfGroupBox = new System.Windows.Forms.GroupBox();
            this.startupLabel = new System.Windows.Forms.Label();
            this.tooltipLabel = new System.Windows.Forms.Label();
            this.enableLabel = new System.Windows.Forms.Label();
            this.statusBtn = new System.Windows.Forms.Button();
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
            this.moduleConfTab = new System.Windows.Forms.TabPage();
            this.moduleRebootBtn = new System.Windows.Forms.Button();
            this.securityConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.passwdConfirmTextbox2 = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.passwdConfirmLabel1 = new System.Windows.Forms.Label();
            this.masterPasswdTextbox = new System.Windows.Forms.TextBox();
            this.passwdConfrimTextbox1 = new System.Windows.Forms.TextBox();
            this.mqttConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.mqttServerLabel = new System.Windows.Forms.Label();
            this.mqttPortLabel = new System.Windows.Forms.Label();
            this.mqttUsernameLabel = new System.Windows.Forms.Label();
            this.mqttPasswdLabel = new System.Windows.Forms.Label();
            this.mqttSubLabel = new System.Windows.Forms.Label();
            this.mqttPubLabel = new System.Windows.Forms.Label();
            this.deviceIdLabel = new System.Windows.Forms.Label();
            this.deviceIdTextbox = new System.Windows.Forms.TextBox();
            this.mqttServerTextbox = new System.Windows.Forms.TextBox();
            this.mqttPubTextbox = new System.Windows.Forms.TextBox();
            this.mqttPortTextbox = new System.Windows.Forms.TextBox();
            this.mqttSubTextbox = new System.Windows.Forms.TextBox();
            this.mqttUsernameTextbox = new System.Windows.Forms.TextBox();
            this.mqttPasswdTextbox = new System.Windows.Forms.TextBox();
            this.moduleSaveBtn = new System.Windows.Forms.Button();
            this.moduleClearBtn = new System.Windows.Forms.Button();
            this.wifiConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.wifiSsidLabel = new System.Windows.Forms.Label();
            this.wifiPasswdLabel = new System.Windows.Forms.Label();
            this.wifiSsidTextbox = new System.Windows.Forms.TextBox();
            this.wifiPasswdTextbox = new System.Windows.Forms.TextBox();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.debugTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.appConfTab.SuspendLayout();
            this.appConfGroupBox.SuspendLayout();
            this.moduleConfTab.SuspendLayout();
            this.securityConfigGroupBox.SuspendLayout();
            this.mqttConfigGroupBox.SuspendLayout();
            this.wifiConfigGroupBox.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 522);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.appConfTab);
            this.tabControl.Controls.Add(this.moduleConfTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(577, 337);
            this.tabControl.TabIndex = 9;
            // 
            // appConfTab
            // 
            this.appConfTab.Controls.Add(this.appConfGroupBox);
            this.appConfTab.Location = new System.Drawing.Point(4, 22);
            this.appConfTab.Name = "appConfTab";
            this.appConfTab.Padding = new System.Windows.Forms.Padding(3);
            this.appConfTab.Size = new System.Drawing.Size(569, 311);
            this.appConfTab.TabIndex = 0;
            this.appConfTab.Text = "Application config";
            this.appConfTab.UseVisualStyleBackColor = true;
            // 
            // appConfGroupBox
            // 
            this.appConfGroupBox.Controls.Add(this.startupLabel);
            this.appConfGroupBox.Controls.Add(this.tooltipLabel);
            this.appConfGroupBox.Controls.Add(this.enableLabel);
            this.appConfGroupBox.Controls.Add(this.statusBtn);
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
            this.appConfGroupBox.Size = new System.Drawing.Size(552, 298);
            this.appConfGroupBox.TabIndex = 0;
            this.appConfGroupBox.TabStop = false;
            this.appConfGroupBox.Text = "Application config";
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
            // statusBtn
            // 
            this.statusBtn.Enabled = false;
            this.statusBtn.Location = new System.Drawing.Point(10, 240);
            this.statusBtn.Name = "statusBtn";
            this.statusBtn.Size = new System.Drawing.Size(536, 23);
            this.statusBtn.TabIndex = 10;
            this.statusBtn.Text = "Module status";
            this.statusBtn.UseVisualStyleBackColor = true;
            this.statusBtn.Click += new System.EventHandler(this.statusBtn_Click);
            // 
            // disconnectBtn
            // 
            this.disconnectBtn.Enabled = false;
            this.disconnectBtn.Location = new System.Drawing.Point(10, 211);
            this.disconnectBtn.Name = "disconnectBtn";
            this.disconnectBtn.Size = new System.Drawing.Size(536, 23);
            this.disconnectBtn.TabIndex = 9;
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
            this.durationComboBox.Location = new System.Drawing.Point(422, 89);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(121, 21);
            this.durationComboBox.TabIndex = 5;
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
            this.tooltipCheckbox.Size = new System.Drawing.Size(197, 17);
            this.tooltipCheckbox.TabIndex = 4;
            this.tooltipCheckbox.Text = "Show tooltip when excute command";
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
            this.saveBtn.Location = new System.Drawing.Point(10, 269);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(536, 23);
            this.saveBtn.TabIndex = 11;
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
            this.startupCheckBox.TabIndex = 6;
            this.startupCheckBox.Text = "Start application on Windows startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Location = new System.Drawing.Point(10, 55);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(94, 17);
            this.enableCheckBox.TabIndex = 3;
            this.enableCheckBox.Text = "Enable control";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(10, 182);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(536, 23);
            this.connectBtn.TabIndex = 8;
            this.connectBtn.Text = "Connect";
            this.connectBtn.UseVisualStyleBackColor = true;
            this.connectBtn.Click += new System.EventHandler(this.connectBtn_Click);
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(484, 19);
            this.refreshBtn.Name = "refreshBtn";
            this.refreshBtn.Size = new System.Drawing.Size(62, 23);
            this.refreshBtn.TabIndex = 7;
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
            // moduleConfTab
            // 
            this.moduleConfTab.Controls.Add(this.moduleRebootBtn);
            this.moduleConfTab.Controls.Add(this.securityConfigGroupBox);
            this.moduleConfTab.Controls.Add(this.mqttConfigGroupBox);
            this.moduleConfTab.Controls.Add(this.moduleSaveBtn);
            this.moduleConfTab.Controls.Add(this.moduleClearBtn);
            this.moduleConfTab.Controls.Add(this.wifiConfigGroupBox);
            this.moduleConfTab.Location = new System.Drawing.Point(4, 22);
            this.moduleConfTab.Name = "moduleConfTab";
            this.moduleConfTab.Padding = new System.Windows.Forms.Padding(3);
            this.moduleConfTab.Size = new System.Drawing.Size(569, 311);
            this.moduleConfTab.TabIndex = 1;
            this.moduleConfTab.Text = "Module config";
            this.moduleConfTab.UseVisualStyleBackColor = true;
            // 
            // moduleRebootBtn
            // 
            this.moduleRebootBtn.Enabled = false;
            this.moduleRebootBtn.Location = new System.Drawing.Point(384, 283);
            this.moduleRebootBtn.Name = "moduleRebootBtn";
            this.moduleRebootBtn.Size = new System.Drawing.Size(74, 23);
            this.moduleRebootBtn.TabIndex = 25;
            this.moduleRebootBtn.Text = "Reboot";
            this.moduleRebootBtn.UseVisualStyleBackColor = true;
            this.moduleRebootBtn.Click += new System.EventHandler(this.moduleRebootBtn_Click);
            // 
            // securityConfigGroupBox
            // 
            this.securityConfigGroupBox.Controls.Add(this.passwdConfirmTextbox2);
            this.securityConfigGroupBox.Controls.Add(this.passwordLabel);
            this.securityConfigGroupBox.Controls.Add(this.passwdConfirmLabel1);
            this.securityConfigGroupBox.Controls.Add(this.masterPasswdTextbox);
            this.securityConfigGroupBox.Controls.Add(this.passwdConfrimTextbox1);
            this.securityConfigGroupBox.Location = new System.Drawing.Point(6, 194);
            this.securityConfigGroupBox.Name = "securityConfigGroupBox";
            this.securityConfigGroupBox.Size = new System.Drawing.Size(563, 83);
            this.securityConfigGroupBox.TabIndex = 28;
            this.securityConfigGroupBox.TabStop = false;
            this.securityConfigGroupBox.Text = "Security configuration";
            // 
            // passwdConfirmTextbox2
            // 
            this.passwdConfirmTextbox2.Location = new System.Drawing.Point(319, 53);
            this.passwdConfirmTextbox2.Name = "passwdConfirmTextbox2";
            this.passwdConfirmTextbox2.PasswordChar = '*';
            this.passwdConfirmTextbox2.Size = new System.Drawing.Size(229, 20);
            this.passwdConfirmTextbox2.TabIndex = 23;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(6, 29);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(87, 13);
            this.passwordLabel.TabIndex = 9;
            this.passwordLabel.Text = "Master password";
            // 
            // passwdConfirmLabel1
            // 
            this.passwdConfirmLabel1.AutoSize = true;
            this.passwdConfirmLabel1.Location = new System.Drawing.Point(7, 56);
            this.passwdConfirmLabel1.Name = "passwdConfirmLabel1";
            this.passwdConfirmLabel1.Size = new System.Drawing.Size(77, 13);
            this.passwdConfirmLabel1.TabIndex = 10;
            this.passwdConfirmLabel1.Text = "New password";
            // 
            // masterPasswdTextbox
            // 
            this.masterPasswdTextbox.Location = new System.Drawing.Point(110, 26);
            this.masterPasswdTextbox.Name = "masterPasswdTextbox";
            this.masterPasswdTextbox.PasswordChar = '*';
            this.masterPasswdTextbox.Size = new System.Drawing.Size(438, 20);
            this.masterPasswdTextbox.TabIndex = 21;
            // 
            // passwdConfrimTextbox1
            // 
            this.passwdConfrimTextbox1.Location = new System.Drawing.Point(110, 53);
            this.passwdConfrimTextbox1.Name = "passwdConfrimTextbox1";
            this.passwdConfrimTextbox1.PasswordChar = '*';
            this.passwdConfrimTextbox1.Size = new System.Drawing.Size(203, 20);
            this.passwdConfrimTextbox1.TabIndex = 22;
            // 
            // mqttConfigGroupBox
            // 
            this.mqttConfigGroupBox.Controls.Add(this.mqttServerLabel);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPortLabel);
            this.mqttConfigGroupBox.Controls.Add(this.mqttUsernameLabel);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPasswdLabel);
            this.mqttConfigGroupBox.Controls.Add(this.mqttSubLabel);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPubLabel);
            this.mqttConfigGroupBox.Controls.Add(this.deviceIdLabel);
            this.mqttConfigGroupBox.Controls.Add(this.deviceIdTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttServerTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPubTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPortTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttSubTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttUsernameTextbox);
            this.mqttConfigGroupBox.Controls.Add(this.mqttPasswdTextbox);
            this.mqttConfigGroupBox.Location = new System.Drawing.Point(3, 60);
            this.mqttConfigGroupBox.Name = "mqttConfigGroupBox";
            this.mqttConfigGroupBox.Size = new System.Drawing.Size(563, 128);
            this.mqttConfigGroupBox.TabIndex = 27;
            this.mqttConfigGroupBox.TabStop = false;
            this.mqttConfigGroupBox.Text = "MQTT configuration";
            // 
            // mqttServerLabel
            // 
            this.mqttServerLabel.AutoSize = true;
            this.mqttServerLabel.Location = new System.Drawing.Point(7, 25);
            this.mqttServerLabel.Name = "mqttServerLabel";
            this.mqttServerLabel.Size = new System.Drawing.Size(70, 13);
            this.mqttServerLabel.TabIndex = 2;
            this.mqttServerLabel.Text = "MQTT server";
            // 
            // mqttPortLabel
            // 
            this.mqttPortLabel.AutoSize = true;
            this.mqttPortLabel.Location = new System.Drawing.Point(408, 22);
            this.mqttPortLabel.Name = "mqttPortLabel";
            this.mqttPortLabel.Size = new System.Drawing.Size(59, 13);
            this.mqttPortLabel.TabIndex = 3;
            this.mqttPortLabel.Text = "MQTT port";
            // 
            // mqttUsernameLabel
            // 
            this.mqttUsernameLabel.AutoSize = true;
            this.mqttUsernameLabel.Location = new System.Drawing.Point(6, 48);
            this.mqttUsernameLabel.Name = "mqttUsernameLabel";
            this.mqttUsernameLabel.Size = new System.Drawing.Size(87, 13);
            this.mqttUsernameLabel.TabIndex = 4;
            this.mqttUsernameLabel.Text = "MQTT username";
            // 
            // mqttPasswdLabel
            // 
            this.mqttPasswdLabel.AutoSize = true;
            this.mqttPasswdLabel.Location = new System.Drawing.Point(274, 48);
            this.mqttPasswdLabel.Name = "mqttPasswdLabel";
            this.mqttPasswdLabel.Size = new System.Drawing.Size(86, 13);
            this.mqttPasswdLabel.TabIndex = 5;
            this.mqttPasswdLabel.Text = "MQTT password";
            // 
            // mqttSubLabel
            // 
            this.mqttSubLabel.AutoSize = true;
            this.mqttSubLabel.Location = new System.Drawing.Point(7, 74);
            this.mqttSubLabel.Name = "mqttSubLabel";
            this.mqttSubLabel.Size = new System.Drawing.Size(80, 13);
            this.mqttSubLabel.TabIndex = 6;
            this.mqttSubLabel.Text = "Subscribe topic";
            // 
            // mqttPubLabel
            // 
            this.mqttPubLabel.AutoSize = true;
            this.mqttPubLabel.Location = new System.Drawing.Point(274, 74);
            this.mqttPubLabel.Name = "mqttPubLabel";
            this.mqttPubLabel.Size = new System.Drawing.Size(71, 13);
            this.mqttPubLabel.TabIndex = 7;
            this.mqttPubLabel.Text = "Publish Topic";
            // 
            // deviceIdLabel
            // 
            this.deviceIdLabel.AutoSize = true;
            this.deviceIdLabel.Location = new System.Drawing.Point(7, 100);
            this.deviceIdLabel.Name = "deviceIdLabel";
            this.deviceIdLabel.Size = new System.Drawing.Size(55, 13);
            this.deviceIdLabel.TabIndex = 8;
            this.deviceIdLabel.Text = "Device ID";
            // 
            // deviceIdTextbox
            // 
            this.deviceIdTextbox.Location = new System.Drawing.Point(110, 97);
            this.deviceIdTextbox.Name = "deviceIdTextbox";
            this.deviceIdTextbox.Size = new System.Drawing.Size(438, 20);
            this.deviceIdTextbox.TabIndex = 20;
            // 
            // mqttServerTextbox
            // 
            this.mqttServerTextbox.Location = new System.Drawing.Point(110, 19);
            this.mqttServerTextbox.Name = "mqttServerTextbox";
            this.mqttServerTextbox.Size = new System.Drawing.Size(276, 20);
            this.mqttServerTextbox.TabIndex = 14;
            // 
            // mqttPubTextbox
            // 
            this.mqttPubTextbox.Location = new System.Drawing.Point(367, 71);
            this.mqttPubTextbox.Name = "mqttPubTextbox";
            this.mqttPubTextbox.Size = new System.Drawing.Size(181, 20);
            this.mqttPubTextbox.TabIndex = 19;
            // 
            // mqttPortTextbox
            // 
            this.mqttPortTextbox.Location = new System.Drawing.Point(473, 19);
            this.mqttPortTextbox.Name = "mqttPortTextbox";
            this.mqttPortTextbox.Size = new System.Drawing.Size(75, 20);
            this.mqttPortTextbox.TabIndex = 15;
            // 
            // mqttSubTextbox
            // 
            this.mqttSubTextbox.Location = new System.Drawing.Point(110, 71);
            this.mqttSubTextbox.Name = "mqttSubTextbox";
            this.mqttSubTextbox.Size = new System.Drawing.Size(158, 20);
            this.mqttSubTextbox.TabIndex = 18;
            // 
            // mqttUsernameTextbox
            // 
            this.mqttUsernameTextbox.Location = new System.Drawing.Point(110, 45);
            this.mqttUsernameTextbox.Name = "mqttUsernameTextbox";
            this.mqttUsernameTextbox.Size = new System.Drawing.Size(158, 20);
            this.mqttUsernameTextbox.TabIndex = 16;
            // 
            // mqttPasswdTextbox
            // 
            this.mqttPasswdTextbox.Location = new System.Drawing.Point(366, 45);
            this.mqttPasswdTextbox.Name = "mqttPasswdTextbox";
            this.mqttPasswdTextbox.PasswordChar = '*';
            this.mqttPasswdTextbox.Size = new System.Drawing.Size(182, 20);
            this.mqttPasswdTextbox.TabIndex = 17;
            // 
            // moduleSaveBtn
            // 
            this.moduleSaveBtn.Enabled = false;
            this.moduleSaveBtn.Location = new System.Drawing.Point(6, 283);
            this.moduleSaveBtn.Name = "moduleSaveBtn";
            this.moduleSaveBtn.Size = new System.Drawing.Size(372, 23);
            this.moduleSaveBtn.TabIndex = 24;
            this.moduleSaveBtn.Text = "Save config";
            this.moduleSaveBtn.UseVisualStyleBackColor = true;
            this.moduleSaveBtn.Click += new System.EventHandler(this.moduleSaveBtn_Click);
            // 
            // moduleClearBtn
            // 
            this.moduleClearBtn.Enabled = false;
            this.moduleClearBtn.Location = new System.Drawing.Point(464, 283);
            this.moduleClearBtn.Name = "moduleClearBtn";
            this.moduleClearBtn.Size = new System.Drawing.Size(90, 23);
            this.moduleClearBtn.TabIndex = 26;
            this.moduleClearBtn.Text = "Clear all setting";
            this.moduleClearBtn.UseVisualStyleBackColor = true;
            this.moduleClearBtn.Click += new System.EventHandler(this.moduleClearBtn_Click);
            // 
            // wifiConfigGroupBox
            // 
            this.wifiConfigGroupBox.Controls.Add(this.wifiSsidLabel);
            this.wifiConfigGroupBox.Controls.Add(this.wifiPasswdLabel);
            this.wifiConfigGroupBox.Controls.Add(this.wifiSsidTextbox);
            this.wifiConfigGroupBox.Controls.Add(this.wifiPasswdTextbox);
            this.wifiConfigGroupBox.Location = new System.Drawing.Point(3, 3);
            this.wifiConfigGroupBox.Name = "wifiConfigGroupBox";
            this.wifiConfigGroupBox.Size = new System.Drawing.Size(563, 51);
            this.wifiConfigGroupBox.TabIndex = 26;
            this.wifiConfigGroupBox.TabStop = false;
            this.wifiConfigGroupBox.Text = "WiFi configuration";
            // 
            // wifiSsidLabel
            // 
            this.wifiSsidLabel.AutoSize = true;
            this.wifiSsidLabel.Location = new System.Drawing.Point(6, 20);
            this.wifiSsidLabel.Name = "wifiSsidLabel";
            this.wifiSsidLabel.Size = new System.Drawing.Size(32, 13);
            this.wifiSsidLabel.TabIndex = 0;
            this.wifiSsidLabel.Text = "SSID";
            // 
            // wifiPasswdLabel
            // 
            this.wifiPasswdLabel.AutoSize = true;
            this.wifiPasswdLabel.Location = new System.Drawing.Point(268, 20);
            this.wifiPasswdLabel.Name = "wifiPasswdLabel";
            this.wifiPasswdLabel.Size = new System.Drawing.Size(53, 13);
            this.wifiPasswdLabel.TabIndex = 1;
            this.wifiPasswdLabel.Text = "Password";
            // 
            // wifiSsidTextbox
            // 
            this.wifiSsidTextbox.Location = new System.Drawing.Point(44, 16);
            this.wifiSsidTextbox.Name = "wifiSsidTextbox";
            this.wifiSsidTextbox.Size = new System.Drawing.Size(179, 20);
            this.wifiSsidTextbox.TabIndex = 12;
            // 
            // wifiPasswdTextbox
            // 
            this.wifiPasswdTextbox.Location = new System.Drawing.Point(327, 17);
            this.wifiPasswdTextbox.Name = "wifiPasswdTextbox";
            this.wifiPasswdTextbox.PasswordChar = '*';
            this.wifiPasswdTextbox.Size = new System.Drawing.Size(221, 20);
            this.wifiPasswdTextbox.TabIndex = 13;
            // 
            // aboutTab
            // 
            this.aboutTab.Location = new System.Drawing.Point(4, 22);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(569, 311);
            this.aboutTab.TabIndex = 2;
            this.aboutTab.Text = "About";
            this.aboutTab.UseVisualStyleBackColor = true;
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
            this.tabControl1.Location = new System.Drawing.Point(4, 342);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 176);
            this.tabControl1.TabIndex = 10;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.logTextBox);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 150);
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
            this.tabPage2.Size = new System.Drawing.Size(565, 150);
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 544);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Console Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.appConfTab.ResumeLayout(false);
            this.appConfGroupBox.ResumeLayout(false);
            this.appConfGroupBox.PerformLayout();
            this.moduleConfTab.ResumeLayout(false);
            this.securityConfigGroupBox.ResumeLayout(false);
            this.securityConfigGroupBox.PerformLayout();
            this.mqttConfigGroupBox.ResumeLayout(false);
            this.mqttConfigGroupBox.PerformLayout();
            this.wifiConfigGroupBox.ResumeLayout(false);
            this.wifiConfigGroupBox.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage appConfTab;
        private System.Windows.Forms.TabPage moduleConfTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.GroupBox appConfGroupBox;
        private System.Windows.Forms.Label baudLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button refreshBtn;
        private System.Windows.Forms.ComboBox baudComboBox;
        private System.Windows.Forms.ComboBox comPortComboBox;
        private System.Windows.Forms.Label comPortLabel;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.CheckBox tooltipCheckbox;
        private System.Windows.Forms.ComboBox durationComboBox;
        private System.Windows.Forms.Label tooltipDurationLabel;
        private System.Windows.Forms.Button disconnectBtn;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.Button moduleSaveBtn;
        private System.Windows.Forms.Button moduleClearBtn;
        private System.Windows.Forms.TextBox passwdConfirmTextbox2;
        private System.Windows.Forms.TextBox passwdConfrimTextbox1;
        private System.Windows.Forms.TextBox masterPasswdTextbox;
        private System.Windows.Forms.TextBox deviceIdTextbox;
        private System.Windows.Forms.TextBox mqttPubTextbox;
        private System.Windows.Forms.TextBox mqttSubTextbox;
        private System.Windows.Forms.TextBox mqttPasswdTextbox;
        private System.Windows.Forms.TextBox mqttUsernameTextbox;
        private System.Windows.Forms.TextBox mqttPortTextbox;
        private System.Windows.Forms.TextBox mqttServerTextbox;
        private System.Windows.Forms.TextBox wifiPasswdTextbox;
        private System.Windows.Forms.TextBox wifiSsidTextbox;
        private System.Windows.Forms.Label passwdConfirmLabel1;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label deviceIdLabel;
        private System.Windows.Forms.Label mqttPubLabel;
        private System.Windows.Forms.Label mqttSubLabel;
        private System.Windows.Forms.Label mqttPasswdLabel;
        private System.Windows.Forms.Label mqttUsernameLabel;
        private System.Windows.Forms.Label mqttPortLabel;
        private System.Windows.Forms.Label mqttServerLabel;
        private System.Windows.Forms.Label wifiPasswdLabel;
        private System.Windows.Forms.Label wifiSsidLabel;
        private System.Windows.Forms.GroupBox wifiConfigGroupBox;
        private System.Windows.Forms.GroupBox securityConfigGroupBox;
        private System.Windows.Forms.GroupBox mqttConfigGroupBox;
        private System.Windows.Forms.Button moduleRebootBtn;
        private System.Windows.Forms.Button statusBtn;
        private System.Windows.Forms.Label startupLabel;
        private System.Windows.Forms.Label tooltipLabel;
        private System.Windows.Forms.Label enableLabel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox debugTextBox;
    }
}

