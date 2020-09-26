namespace SecuredChat
{
    partial class FormChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChat));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new DarkUI.Controls.DarkMenuStrip();
            this.remootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableEncryptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.changeScreencastIntervalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMyNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendScreenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startScreenCastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showHideDesktopFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.listBoxClients = new System.Windows.Forms.ListBox();
            this.tableLayoutPanelChatBoxText = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelMsg = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSend = new DarkUI.Controls.DarkButton();
            this.textBoxMsg = new DarkUI.Controls.DarkTextBox();
            this.richTextBoxMsgs = new DarkUI.Controls.DarkRichTextBox();
            this.notifyIconMain = new System.Windows.Forms.NotifyIcon(this.components);
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanelMain.SuspendLayout();
            this.tableLayoutPanelChatBoxText.SuspendLayout();
            this.tableLayoutPanelMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(753, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.StatusStrip1_Paint);
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.menuStrip1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remootToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(753, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Tag = "";
            this.menuStrip1.Text = "menuStrip1";
            // 
            // remootToolStripMenuItem
            // 
            this.remootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.toolStripSeparator1,
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.remootToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.remootToolStripMenuItem.Name = "remootToolStripMenuItem";
            this.remootToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.remootToolStripMenuItem.Text = "Remoot";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.connectToolStripMenuItem.Tag = "Disconnected";
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.disconnectToolStripMenuItem.Tag = "Connected";
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(132, 6);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enableEncryptionToolStripMenuItem,
            this.disableEncryptionToolStripMenuItem,
            this.toolStripSeparator4,
            this.changeScreencastIntervalToolStripMenuItem,
            this.setMyNameToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.settingsToolStripMenuItem.Text = "Preferences";
            // 
            // enableEncryptionToolStripMenuItem
            // 
            this.enableEncryptionToolStripMenuItem.Name = "enableEncryptionToolStripMenuItem";
            this.enableEncryptionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.enableEncryptionToolStripMenuItem.Text = "Enable Encryption";
            this.enableEncryptionToolStripMenuItem.Click += new System.EventHandler(this.enableEncryptionToolStripMenuItem_Click);
            // 
            // disableEncryptionToolStripMenuItem
            // 
            this.disableEncryptionToolStripMenuItem.Checked = true;
            this.disableEncryptionToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.disableEncryptionToolStripMenuItem.Name = "disableEncryptionToolStripMenuItem";
            this.disableEncryptionToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.disableEncryptionToolStripMenuItem.Text = "Disable Encryption";
            this.disableEncryptionToolStripMenuItem.Click += new System.EventHandler(this.disableEncryptionToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(213, 6);
            // 
            // changeScreencastIntervalToolStripMenuItem
            // 
            this.changeScreencastIntervalToolStripMenuItem.Name = "changeScreencastIntervalToolStripMenuItem";
            this.changeScreencastIntervalToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.changeScreencastIntervalToolStripMenuItem.Text = "Change Screencast Interval";
            this.changeScreencastIntervalToolStripMenuItem.Click += new System.EventHandler(this.changeScreencastIntervalToolStripMenuItem_Click);
            // 
            // setMyNameToolStripMenuItem
            // 
            this.setMyNameToolStripMenuItem.Name = "setMyNameToolStripMenuItem";
            this.setMyNameToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.setMyNameToolStripMenuItem.Text = "Set Custom User Name";
            this.setMyNameToolStripMenuItem.Click += new System.EventHandler(this.SetMyNameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(132, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendScreenShotToolStripMenuItem,
            this.startScreenCastToolStripMenuItem,
            this.toolStripSeparator3,
            this.showHideDesktopFormToolStripMenuItem});
            this.actionsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // sendScreenShotToolStripMenuItem
            // 
            this.sendScreenShotToolStripMenuItem.Name = "sendScreenShotToolStripMenuItem";
            this.sendScreenShotToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.sendScreenShotToolStripMenuItem.Tag = "Connected";
            this.sendScreenShotToolStripMenuItem.Text = "Send Screen Shot";
            this.sendScreenShotToolStripMenuItem.Click += new System.EventHandler(this.sendScreenShotToolStripMenuItem_Click);
            // 
            // startScreenCastToolStripMenuItem
            // 
            this.startScreenCastToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.startScreenCastToolStripMenuItem.Name = "startScreenCastToolStripMenuItem";
            this.startScreenCastToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.startScreenCastToolStripMenuItem.Tag = "Connected";
            this.startScreenCastToolStripMenuItem.Text = "Screen Cast";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.StartToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.StopToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(179, 6);
            // 
            // showHideDesktopFormToolStripMenuItem
            // 
            this.showHideDesktopFormToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.showHideDesktopFormToolStripMenuItem.Name = "showHideDesktopFormToolStripMenuItem";
            this.showHideDesktopFormToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.showHideDesktopFormToolStripMenuItem.Text = "Screen Cast Window";
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.ShowToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 2;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanelMain.Controls.Add(this.listBoxClients, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelChatBoxText, 0, 0);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 1;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(753, 416);
            this.tableLayoutPanelMain.TabIndex = 2;
            // 
            // listBoxClients
            // 
            this.listBoxClients.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.listBoxClients.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxClients.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClients.ForeColor = System.Drawing.Color.Gainsboro;
            this.listBoxClients.FormattingEnabled = true;
            this.listBoxClients.ItemHeight = 15;
            this.listBoxClients.Location = new System.Drawing.Point(556, 3);
            this.listBoxClients.Name = "listBoxClients";
            this.listBoxClients.Size = new System.Drawing.Size(194, 410);
            this.listBoxClients.TabIndex = 0;
            this.listBoxClients.Tag = "Connected";
            // 
            // tableLayoutPanelChatBoxText
            // 
            this.tableLayoutPanelChatBoxText.ColumnCount = 1;
            this.tableLayoutPanelChatBoxText.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChatBoxText.Controls.Add(this.tableLayoutPanelMsg, 0, 1);
            this.tableLayoutPanelChatBoxText.Controls.Add(this.richTextBoxMsgs, 0, 0);
            this.tableLayoutPanelChatBoxText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelChatBoxText.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelChatBoxText.Name = "tableLayoutPanelChatBoxText";
            this.tableLayoutPanelChatBoxText.RowCount = 2;
            this.tableLayoutPanelChatBoxText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelChatBoxText.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanelChatBoxText.Size = new System.Drawing.Size(547, 410);
            this.tableLayoutPanelChatBoxText.TabIndex = 1;
            // 
            // tableLayoutPanelMsg
            // 
            this.tableLayoutPanelMsg.ColumnCount = 2;
            this.tableLayoutPanelMsg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMsg.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanelMsg.Controls.Add(this.buttonSend, 1, 0);
            this.tableLayoutPanelMsg.Controls.Add(this.textBoxMsg, 0, 0);
            this.tableLayoutPanelMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMsg.Location = new System.Drawing.Point(3, 375);
            this.tableLayoutPanelMsg.Name = "tableLayoutPanelMsg";
            this.tableLayoutPanelMsg.RowCount = 1;
            this.tableLayoutPanelMsg.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelMsg.Size = new System.Drawing.Size(541, 32);
            this.tableLayoutPanelMsg.TabIndex = 0;
            // 
            // buttonSend
            // 
            this.buttonSend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSend.Location = new System.Drawing.Point(424, 3);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Padding = new System.Windows.Forms.Padding(5);
            this.buttonSend.Size = new System.Drawing.Size(114, 26);
            this.buttonSend.TabIndex = 0;
            this.buttonSend.Tag = "Connected";
            this.buttonSend.Text = "Send";
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // textBoxMsg
            // 
            this.textBoxMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.textBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxMsg.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.textBoxMsg.Location = new System.Drawing.Point(3, 3);
            this.textBoxMsg.Name = "textBoxMsg";
            this.textBoxMsg.Size = new System.Drawing.Size(415, 26);
            this.textBoxMsg.TabIndex = 1;
            this.textBoxMsg.Tag = "Connected";
            this.textBoxMsg.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBoxMsg_KeyUp);
            // 
            // richTextBoxMsgs
            // 
            this.richTextBoxMsgs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.richTextBoxMsgs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxMsgs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxMsgs.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxMsgs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.richTextBoxMsgs.Location = new System.Drawing.Point(3, 3);
            this.richTextBoxMsgs.Name = "richTextBoxMsgs";
            this.richTextBoxMsgs.Size = new System.Drawing.Size(541, 366);
            this.richTextBoxMsgs.TabIndex = 1;
            this.richTextBoxMsgs.Tag = "Connected";
            this.richTextBoxMsgs.Text = "";
            this.richTextBoxMsgs.TextChanged += new System.EventHandler(this.richTextBoxMsgs_TextChanged);
            // 
            // notifyIconMain
            // 
            this.notifyIconMain.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconMain.Icon")));
            this.notifyIconMain.Text = "Remoot";
            this.notifyIconMain.BalloonTipClicked += new System.EventHandler(this.NotifyIconMain_BalloonTipClicked);
            this.notifyIconMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIconMain_MouseDoubleClick);
            // 
            // FormChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 462);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FormChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remoot";
            this.Load += new System.EventHandler(this.FormChat_Load);
            this.Resize += new System.EventHandler(this.FormChat_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelChatBoxText.ResumeLayout(false);
            this.tableLayoutPanelMsg.ResumeLayout(false);
            this.tableLayoutPanelMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private DarkUI.Controls.DarkMenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem remootToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendScreenShotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startScreenCastToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem showHideDesktopFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.ListBox listBoxClients;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelChatBoxText;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMsg;
        private DarkUI.Controls.DarkButton buttonSend;
        private DarkUI.Controls.DarkTextBox textBoxMsg;
        private DarkUI.Controls.DarkRichTextBox richTextBoxMsgs;
        private System.Windows.Forms.ToolStripMenuItem enableEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableEncryptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeScreencastIntervalToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.NotifyIcon notifyIconMain;
        private System.Windows.Forms.ToolStripMenuItem setMyNameToolStripMenuItem;
    }
}

