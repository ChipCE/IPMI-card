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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.appConfTab = new System.Windows.Forms.TabPage();
            this.logGroupBox = new System.Windows.Forms.GroupBox();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.appConfGroupBox = new System.Windows.Forms.GroupBox();
            this.baudLabel = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.startupCheckBox = new System.Windows.Forms.CheckBox();
            this.enableCheckBox = new System.Windows.Forms.CheckBox();
            this.testBtn = new System.Windows.Forms.Button();
            this.refreshBtn = new System.Windows.Forms.Button();
            this.baudComboBox = new System.Windows.Forms.ComboBox();
            this.comPortComboBox = new System.Windows.Forms.ComboBox();
            this.comPortLabel = new System.Windows.Forms.Label();
            this.moduleConfTab = new System.Windows.Forms.TabPage();
            this.aboutTab = new System.Windows.Forms.TabPage();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tooltipCheckbox = new System.Windows.Forms.CheckBox();
            this.tooltipDurationLabel = new System.Windows.Forms.Label();
            this.durationComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.appConfTab.SuspendLayout();
            this.logGroupBox.SuspendLayout();
            this.appConfGroupBox.SuspendLayout();
            this.trayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 399);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(577, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.appConfTab);
            this.tabControl.Controls.Add(this.moduleConfTab);
            this.tabControl.Controls.Add(this.aboutTab);
            this.tabControl.Location = new System.Drawing.Point(0, 2);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(577, 395);
            this.tabControl.TabIndex = 9;
            // 
            // appConfTab
            // 
            this.appConfTab.Controls.Add(this.logGroupBox);
            this.appConfTab.Controls.Add(this.appConfGroupBox);
            this.appConfTab.Location = new System.Drawing.Point(4, 22);
            this.appConfTab.Name = "appConfTab";
            this.appConfTab.Padding = new System.Windows.Forms.Padding(3);
            this.appConfTab.Size = new System.Drawing.Size(569, 369);
            this.appConfTab.TabIndex = 0;
            this.appConfTab.Text = "Application config";
            this.appConfTab.UseVisualStyleBackColor = true;
            // 
            // logGroupBox
            // 
            this.logGroupBox.Controls.Add(this.logTextBox);
            this.logGroupBox.Location = new System.Drawing.Point(9, 176);
            this.logGroupBox.Name = "logGroupBox";
            this.logGroupBox.Size = new System.Drawing.Size(552, 187);
            this.logGroupBox.TabIndex = 1;
            this.logGroupBox.TabStop = false;
            this.logGroupBox.Text = "Log";
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(6, 19);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.ReadOnly = true;
            this.logTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.logTextBox.Size = new System.Drawing.Size(536, 162);
            this.logTextBox.TabIndex = 0;
            // 
            // appConfGroupBox
            // 
            this.appConfGroupBox.Controls.Add(this.durationComboBox);
            this.appConfGroupBox.Controls.Add(this.tooltipDurationLabel);
            this.appConfGroupBox.Controls.Add(this.tooltipCheckbox);
            this.appConfGroupBox.Controls.Add(this.baudLabel);
            this.appConfGroupBox.Controls.Add(this.saveBtn);
            this.appConfGroupBox.Controls.Add(this.startupCheckBox);
            this.appConfGroupBox.Controls.Add(this.enableCheckBox);
            this.appConfGroupBox.Controls.Add(this.testBtn);
            this.appConfGroupBox.Controls.Add(this.refreshBtn);
            this.appConfGroupBox.Controls.Add(this.baudComboBox);
            this.appConfGroupBox.Controls.Add(this.comPortComboBox);
            this.appConfGroupBox.Controls.Add(this.comPortLabel);
            this.appConfGroupBox.Location = new System.Drawing.Point(9, 7);
            this.appConfGroupBox.Name = "appConfGroupBox";
            this.appConfGroupBox.Size = new System.Drawing.Size(552, 163);
            this.appConfGroupBox.TabIndex = 0;
            this.appConfGroupBox.TabStop = false;
            this.appConfGroupBox.Text = "Application config";
            // 
            // baudLabel
            // 
            this.baudLabel.AutoSize = true;
            this.baudLabel.Location = new System.Drawing.Point(183, 25);
            this.baudLabel.Name = "baudLabel";
            this.baudLabel.Size = new System.Drawing.Size(53, 13);
            this.baudLabel.TabIndex = 8;
            this.baudLabel.Text = "Baud rate";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(10, 128);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(533, 23);
            this.saveBtn.TabIndex = 7;
            this.saveBtn.Text = "Save setting";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // startupCheckBox
            // 
            this.startupCheckBox.AutoSize = true;
            this.startupCheckBox.Location = new System.Drawing.Point(10, 99);
            this.startupCheckBox.Name = "startupCheckBox";
            this.startupCheckBox.Size = new System.Drawing.Size(199, 17);
            this.startupCheckBox.TabIndex = 6;
            this.startupCheckBox.Text = "Start application on Windows startup";
            this.startupCheckBox.UseVisualStyleBackColor = true;
            // 
            // enableCheckBox
            // 
            this.enableCheckBox.AutoSize = true;
            this.enableCheckBox.Location = new System.Drawing.Point(10, 52);
            this.enableCheckBox.Name = "enableCheckBox";
            this.enableCheckBox.Size = new System.Drawing.Size(94, 17);
            this.enableCheckBox.TabIndex = 5;
            this.enableCheckBox.Text = "Enable control";
            this.enableCheckBox.UseVisualStyleBackColor = true;
            // 
            // testBtn
            // 
            this.testBtn.Location = new System.Drawing.Point(427, 20);
            this.testBtn.Name = "testBtn";
            this.testBtn.Size = new System.Drawing.Size(117, 23);
            this.testBtn.TabIndex = 4;
            this.testBtn.Text = "Test connection";
            this.testBtn.UseVisualStyleBackColor = true;
            // 
            // refreshBtn
            // 
            this.refreshBtn.Location = new System.Drawing.Point(359, 20);
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
            this.baudComboBox.Location = new System.Drawing.Point(242, 22);
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
            this.comPortComboBox.Size = new System.Drawing.Size(111, 21);
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
            this.moduleConfTab.Location = new System.Drawing.Point(4, 22);
            this.moduleConfTab.Name = "moduleConfTab";
            this.moduleConfTab.Padding = new System.Windows.Forms.Padding(3);
            this.moduleConfTab.Size = new System.Drawing.Size(569, 397);
            this.moduleConfTab.TabIndex = 1;
            this.moduleConfTab.Text = "Module config";
            this.moduleConfTab.UseVisualStyleBackColor = true;
            // 
            // aboutTab
            // 
            this.aboutTab.Location = new System.Drawing.Point(4, 22);
            this.aboutTab.Name = "aboutTab";
            this.aboutTab.Size = new System.Drawing.Size(569, 397);
            this.aboutTab.TabIndex = 2;
            this.aboutTab.Text = "About";
            this.aboutTab.UseVisualStyleBackColor = true;
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
            this.trayMenu.Size = new System.Drawing.Size(101, 48);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // tooltipCheckbox
            // 
            this.tooltipCheckbox.AutoSize = true;
            this.tooltipCheckbox.Location = new System.Drawing.Point(10, 76);
            this.tooltipCheckbox.Name = "tooltipCheckbox";
            this.tooltipCheckbox.Size = new System.Drawing.Size(197, 17);
            this.tooltipCheckbox.TabIndex = 9;
            this.tooltipCheckbox.Text = "Show tooltip when excute command";
            this.tooltipCheckbox.UseVisualStyleBackColor = true;
            // 
            // tooltipDurationLabel
            // 
            this.tooltipDurationLabel.AutoSize = true;
            this.tooltipDurationLabel.Location = new System.Drawing.Point(356, 77);
            this.tooltipDurationLabel.Name = "tooltipDurationLabel";
            this.tooltipDurationLabel.Size = new System.Drawing.Size(66, 13);
            this.tooltipDurationLabel.TabIndex = 10;
            this.tooltipDurationLabel.Text = "Duration(ms)";
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
            this.durationComboBox.Location = new System.Drawing.Point(425, 72);
            this.durationComboBox.Name = "durationComboBox";
            this.durationComboBox.Size = new System.Drawing.Size(121, 21);
            this.durationComboBox.TabIndex = 11;
            this.durationComboBox.Text = "--Select--";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 421);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.Text = "Console Controller";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.mainForm_Resize);
            this.tabControl.ResumeLayout(false);
            this.appConfTab.ResumeLayout(false);
            this.logGroupBox.ResumeLayout(false);
            this.logGroupBox.PerformLayout();
            this.appConfGroupBox.ResumeLayout(false);
            this.appConfGroupBox.PerformLayout();
            this.trayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage appConfTab;
        private System.Windows.Forms.TabPage moduleConfTab;
        private System.Windows.Forms.TabPage aboutTab;
        private System.Windows.Forms.GroupBox logGroupBox;
        private System.Windows.Forms.GroupBox appConfGroupBox;
        private System.Windows.Forms.Label baudLabel;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.CheckBox startupCheckBox;
        private System.Windows.Forms.CheckBox enableCheckBox;
        private System.Windows.Forms.Button testBtn;
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
    }
}

