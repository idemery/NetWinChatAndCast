using DarkUI.Forms;
using idemery.Remoot.ClientHelper;
using idemery.Remoot.Forms;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecuredChat
{
    public partial class FormChat : DarkForm, INotifyPropertyChanged, IChatForm
    {
        private HostService hostService;
        private Proxy proxy;
        private delegate void MyInvoker();

        public FormChat()
        {
            InitializeComponent();

            BindConnectedChilds(this);
            this.PropertyChanged += FormChat_PropertyChanged;
            screenCastTimer.Tick += ScreenCastTimer_Tick;
            screenCastTimer.Interval = 10;
            stopToolStripMenuItem.Enabled = false;
        }

        public void Status(string text)
        {
            statusLabel.Text = text;
        }

        private void FormChat_Load(object sender, EventArgs e)
        {
            Connected = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Hide();
                notifyIconMain.Visible = true;
                e.Cancel = true;
            }
            else
            {
                base.OnFormClosing(e);
            }

        }

        #region Properties
        public ICastForm CastForm { get { return castForm; } }
        public ListBox ClientsListBox { get { return listBoxClients; } }
        public RichTextBox TextBox { get { return richTextBoxMsgs; } }

        protected string password;
        public string Password { get => password; set { password = value; NotifyPropertyChanged(); } }
        #endregion

        #region Bind Enabled on Connected
        private void FormChat_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.PropertyName))
            {
                return;
            }

            object value = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);

            if (e.PropertyName.ToUpper().Contains("CONNECTED") && value is bool)
            {
                SetMenuItemEnabled((bool)value, e.PropertyName, menuStrip1.Items);
            }

            if (e.PropertyName.Equals("Password", StringComparison.OrdinalIgnoreCase))
            {
                enableEncryptionToolStripMenuItem.Checked = !string.IsNullOrWhiteSpace(Convert.ToString(value));
                disableEncryptionToolStripMenuItem.Checked = string.IsNullOrWhiteSpace(Convert.ToString(value));
            }
        }

        private void BindConnectedChilds(Control control)
        {
            foreach (Control subCtrl in control.Controls)
            {
                BindConnected(subCtrl);

                BindConnectedChilds(subCtrl);
            }
        }

        private void SetMenuItemEnabled(bool enabled, string propertyName, ToolStripItemCollection items)
        {
            foreach (ToolStripItem i in items)
            {
                ToolStripMenuItem item = i as ToolStripMenuItem;
                if (item == null)
                {
                    continue;
                }

                if (item.Tag is string && !string.IsNullOrEmpty(Convert.ToString(item.Tag)) && item.Tag.ToString() == propertyName)
                {
                    if (InvokeRequired)
                    {
                        this.Invoke(new MyInvoker(() => { item.Enabled = enabled; }));
                    }
                    else
                    {
                        item.Enabled = enabled;
                    }
                }

                SetMenuItemEnabled(enabled, propertyName, item.DropDownItems);
            }
        }

        private void BindConnected(Control control)
        {
            if (control.Tag is string && !string.IsNullOrEmpty(Convert.ToString(control.Tag)))
            {
                control.DataBindings.Add("Enabled", this, control.Tag.ToString());
            }
        }

        protected bool _connected = false;
        public bool Connected
        {
            get { return _connected; }
            set
            {
                _connected = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Disconnected");
            }
        }

        public bool Disconnected { get { return !_connected; } }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (InvokeRequired)
            {
                this.Invoke(new MyInvoker(() => { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }));
            }
            else
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }


        }
        #endregion

        #region Connect / Disconnect

        public string HostAddress { get; set; }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void Connect()
        {
            if (Connected)
            {
                return;
            }

            //var result = MessageBox.Show("Do you want to host the conversation or connect to a host?\r\nClick Yes to start a local host.\r\nClick No to connect a remote host.",
            //    "Is a Host?",
            //    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            var result = DarkMessageBox.ShowInformation("Do you want to host the conversation or connect to a host?\r\nClick Yes to start a local host.\r\nClick No to connect a remote host.",
                "Is a Host?", DarkDialogButton.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                this.Text = "Remoot Host";
                hostService = new HostService(this);
                try
                {
                    hostService.Start();
                    textBoxMsg.Focus();
                }
                catch (Exception ex)
                {
                    DarkMessageBox.ShowError(ex.Message, "Error");
                }
            }
            else if (result == DialogResult.No)
            {
                this.Text = "Remoot Client";

                HostAddress = Microsoft.VisualBasic.Interaction.InputBox("Kindly enter host IP.", "Host IP");
                if (!string.IsNullOrWhiteSpace(HostAddress))
                {
                    HostAddress = $"net.tcp://{HostAddress}:8080/SecuredChat/tcp";
                }

                ClientService clientService = new ClientService(this);
                InstanceContext context = new InstanceContext(clientService);
                proxy = new Proxy(context, clientService);
                try
                {
                    proxy.Connect(null);
                    textBoxMsg.Focus();
                }
                catch (Exception ex)
                {
                    DarkMessageBox.ShowError(ex.Message, "Error");
                }
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void Disconnect()
        {
            if (hostService != null && hostService.State == CommunicationState.Opened)
            {
                hostService.Stop();
            }

            if (proxy != null && proxy.State == CommunicationState.Opened)
            {
                proxy.Disconnect();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
            notifyIconMain.Visible = false;
            Application.Exit();
        }

        #endregion

        #region Chat Messages

        private async void buttonSend_Click(object sender, EventArgs e)
        {
            await SendMessage(textBoxMsg.Text);
            textBoxMsg.Text = string.Empty;
        }

        private async Task SendMessage(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            if (hostService != null && hostService.State == CommunicationState.Opened)
            {
                hostService.SendMessageToClients(text);
            }

            if (proxy != null && proxy.State == CommunicationState.Opened)
            {
                await proxy.Send(text);
            }
        }

        private void richTextBoxMsgs_TextChanged(object sender, EventArgs e)
        {
            RichTextBox sndr = sender as RichTextBox;
            if (sndr == null)
            {
                return;
            }

            sndr.SelectionStart = sndr.Text.Length;
            sndr.ScrollToCaret();
        }

        ChatTyping chatTyping = new ChatTyping();
        private async void textBoxMsg_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendMessage(textBoxMsg.Text);
                textBoxMsg.Text = string.Empty;
                e.Handled = true;
            }
            else
            {
                if (proxy != null && proxy.State == CommunicationState.Opened)
                {
                    await proxy.Send(chatTyping);
                }
            }
        }

        public void Notify(string tipTitle, string tipText)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                notifyIconMain.ShowBalloonTip(4000, tipTitle, tipText, ToolTipIcon.None);
            }
        }

        #endregion

        #region Notification Events

        private void FormChat_Resize(object sender, EventArgs e)
        {
            if (hostService != null && this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIconMain.Visible = true;
            }
        }

        private void NotifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconMain.Visible = false;
        }

        private void NotifyIconMain_BalloonTipClicked(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconMain.Visible = false;
        }

        #endregion

        #region Encryption
        private void enableEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password = Microsoft.VisualBasic.Interaction.InputBox("Kindly enter the password to use for encryption and decryption. This password won't be sent anywehre.",
                       "Password");
        }

        private void disableEncryptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password = null;
        }

        #endregion

        #region About

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FormAbout().ShowDialog();
        }

        #endregion

        #region Screen Cast
        Timer screenCastTimer = new Timer();
        FormCast castForm = new FormCast();
        PresenterDesktop Desktop = new PresenterDesktop();
        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            castForm.Show();
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            castForm.Hide();
        }

        private async void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!screenCastTimer.Enabled)
            {
                stopToolStripMenuItem.Enabled = true;
                startToolStripMenuItem.Enabled = false;
                await proxy.Send(new ScreenModel { Reference = true, Desktop = Desktop.GetCompressedReferenceDesktop() });
                System.Threading.Thread.Sleep(100);
                screenCastTimer.Start();
            }
        }

        private async void StopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (screenCastTimer.Enabled)
            {
                stopToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = true;

                screenCastTimer.Stop();
                await proxy.Send(new ScreenModel { Stopped = true });
                Status("Screen casting stopped.");
            }
        }

        private async void ScreenCastTimer_Tick(object sender, EventArgs e)
        {
            if (proxy != null && proxy.State == CommunicationState.Opened)
            {
                Status("Screen casting..");
                await proxy.Send(new ScreenModel { Reference = false, Desktop = Desktop.GetCompressedDifferenceDesktop() });
            }
            else
            {
                screenCastTimer.Stop();
                stopToolStripMenuItem.Enabled = false;
                startToolStripMenuItem.Enabled = true;
                Status("Screen casting stopped.");
            }
        }

        private async void sendScreenShotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            await SendScreenShot();
        }

        private async Task SendScreenShot()
        {
            if (screenCastTimer.Enabled)
            {
                DarkMessageBox.ShowWarning("Screen casting is already in progress.", "Screen casting in progress!");
                return;
            }

            if (proxy != null && proxy.State == CommunicationState.Opened)
            {
                await proxy.Send(new ScreenModel { Reference = true, Desktop = Desktop.GetCompressedReferenceDesktop() });
            }
        }

        private void changeScreencastIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int interval;
            string intervalText = Microsoft.VisualBasic.Interaction.InputBox("Kindly enter the screencast interval in milliseconds.\r\n(The bigger the slower is screen casting)",
                       "Screencast Interval", screenCastTimer.Interval.ToString());

            if (int.TryParse(intervalText, out interval))
            {
                screenCastTimer.Interval = interval;
            }
            else
            {
                DarkMessageBox.ShowWarning("You entered incorrect interval. Kindly try again.", "Wrong input");
            }

        }



        #endregion

        #region Client Name
        public string ClientName { get; set; }

        private void SetMyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientName = Microsoft.VisualBasic.Interaction.InputBox("Kindly enter your name.",
                       "User Name");
        }

        #endregion

        #region Shortcuts

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SendScreenShot();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.K))
            {
                HackText();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.H))
            {
                Hide();
                notifyIconMain.Visible = true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                Connect();
            }
            else if (keyData == (Keys.Control | Keys.D))
            {
                Disconnect();
            }
            else if (keyData == (Keys.Control | Keys.E))
            {
                Disconnect();
                Application.Exit();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        bool hacked = false;
        private void HackText()
        {
            #region TEXT
            string text = @"@echo off

echo.

echo.

color a

title hack01

cls

echo ---------------------Hacking CIA Accounts----------------------------

ping google.com>nul

echo Gathering Information...

ping google.com>nul

netstat -a

tree

ping google.com>nul

ping google.com>nul

echo _____________________

echo Information gathered

echo _____________________

echo %random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%%random%

ping google.com>nul

ping google.com

ping google.com>nul

:C

echo _________________

echo Hacked:

echo Username:Admin

echo Password:%random%

echo _________________

echo Please register

echo.

set /p user=Username:

set /p pass=Password:

echo Your account %user% has been created.

echo.

pause

:A echo Please Login.

echo.

set /p u=Username:

set /p p=Password:

if %u%==%user% if %p%==%pass% goto B

echo Invalid Username or Password echo. pause goto A

:B

echo ______________________

echo Logged in sucsessfully

echo ______________________

ping google.com>nul

echo View files [1]

echo Logout [2]

SET INPUT= SET /P INPUT=Please select a number:

IF /I '%INPUT%'=='1' GOTO D

IF /I '%INPUT%'=='2' GOTO C pause

:C echo Logged Out

ping google.com>nul

exit";
            #endregion

            hacked = !hacked;

            //richTextBoxMsgs.BackColor = hacked ? Color.Black : Color.White;
            listBoxClients.Visible = !hacked;

            if (hacked)
            {
                WindowState = FormWindowState.Maximized;
                richTextBoxMsgs.AppendText(text + Environment.NewLine, Color.LightGreen);
            }
            else
            {
                WindowState = FormWindowState.Normal;
                richTextBoxMsgs.SelectionStart = richTextBoxMsgs.Text.Length;
                richTextBoxMsgs.ScrollToCaret();
            }
        }

        #endregion

        private void StatusStrip1_Paint(object sender, PaintEventArgs e)
        {
            statusStrip1.BackColor = DarkUI.Config.Colors.LightBackground;
            statusStrip1.ForeColor = DarkUI.Config.Colors.LightText;
        }
    }
}
