using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace SecuredChat
{
    public abstract class ChatService
    {
        protected IChatForm form;
        public BindingList<ClientModel> Clients { get; protected set; }
        public IChatForm Form { get { return form; } }

        private delegate void MyInvoker();

        public ChatService(IChatForm form)
        {
            this.form = form;
            Clients = new BindingList<ClientModel>();
            form.ClientsListBox.DataSource = Clients;
            form.ClientsListBox.DisplayMember = "Name";
            form.ClientsListBox.ValueMember = "SessionId";
        }

        protected void AddMessage(string msg)
        {
            AddMessage(msg, DarkUI.Config.Colors.LightText);
        }

        protected void AddMessage(string msg, Color color)
        {
            if (form.TextBox.InvokeRequired)
            {
                form.Invoke(new MyInvoker(() => { form.TextBox.AppendText(msg + Environment.NewLine, color); }));
            }
            else
            {
                form.TextBox.AppendText(msg + Environment.NewLine, color);
            }
        }

        protected void RemoveClient(string session_id)
        {
            if (Clients.Any(c => c.SessionId == session_id))
            {
                if (Form.ClientsListBox.InvokeRequired)
                {
                    Form.Invoke(new MyInvoker(() => { Clients.Remove(Clients.Single(c => c.SessionId == session_id)); }));
                }
                else
                {
                    Clients.Remove(Clients.Single(c => c.SessionId == session_id));
                }
            }
        }

        public Binding GetBinding()
        {
            NetTcpBinding tcpBinding = new NetTcpBinding(SecurityMode.None, true);
            tcpBinding.MaxConnections = 1000;
            tcpBinding.MaxBufferPoolSize = (int)67108864;
            tcpBinding.MaxBufferSize = 67108864;
            tcpBinding.MaxReceivedMessageSize = (int)67108864;
            tcpBinding.TransferMode = TransferMode.Buffered;
            tcpBinding.ReaderQuotas.MaxArrayLength = 67108864;
            tcpBinding.ReaderQuotas.MaxBytesPerRead = 67108864;
            tcpBinding.ReaderQuotas.MaxStringContentLength = 67108864;
            tcpBinding.ReliableSession.Enabled = true;
            tcpBinding.ReliableSession.InactivityTimeout = TimeSpan.FromDays(23);
            tcpBinding.Security.Mode = SecurityMode.None;
            return tcpBinding;
        }
    }
}
