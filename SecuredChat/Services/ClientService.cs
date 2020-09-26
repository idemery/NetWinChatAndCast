using System;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Timers;

namespace SecuredChat
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Single)]
    public class ClientService : ChatService, IClientService
    {
        private ClientModel clientModel;
        public ClientService(IChatForm form) : base(form)
        {
            string username = Form.ClientName;
            if (string.IsNullOrWhiteSpace(username))
            {
                if (System.DirectoryServices.AccountManagement.UserPrincipal.Current != null)
                {
                    username = System.DirectoryServices.AccountManagement.UserPrincipal.Current.DisplayName;
                }
                else
                {
                    username = Environment.UserName;
                }
            }

            clientModel = new ClientModel { Name = username };
        }

        public ClientModel Client { get => clientModel; }

        public void Receive(DataModel data)
        {
            string msg = string.Empty;

            if (data is ChatJoin)
            {
                ChatJoin join = data as ChatJoin;
                if (join.Clients != null && join.Clients.Any())
                {
                    foreach (var c in join.Clients)
                    {
                        Clients.Add(c);
                    }
                }
                else
                {
                    Clients.Add(data.Sender);
                }

                msg = $"{data.Sender.Name} joined.";
            }
            else if (data is ChatLeave)
            {
                RemoveClient(data.Sender.SessionId);
                msg = $"{data.Sender.Name} left.";
            }
            else if (data is ChatMessage)
            {
                string message = ((ChatMessage)data).Message;

                if (!string.IsNullOrWhiteSpace(Form.Password))
                {
                    try
                    {
                        message = AesHelper.DecryptText(message, Form.Password);
                    }
                    catch { }
                }

                msg = message;
            }
            else if (data is ChatTyping)
            {
                ChatTyping chatTyping = data as ChatTyping;
                Form.Status($"{chatTyping.Sender.Name} is typing ..");
                Timer timer = new Timer();
                timer.Interval = 1500;
                timer.Elapsed += (s, en) =>
                {
                    Form.Status(string.Empty);
                    timer.Stop();
                };
                timer.Start();
            }
            else if (data is ScreenModel)
            {
                ScreenModel screenModel = data as ScreenModel;
                if (screenModel.Stopped)
                {
                    Form.CastForm.Hide();
                }
                else
                {
                    if (screenModel.Reference)
                    {
                        Form.CastForm.Show();
                        Form.CastForm.Text = screenModel.Sender.Name;
                        Form.CastForm.DesktopRef.SetReferenceDesktop = screenModel.Desktop;
                    }
                    else
                    {
                        Form.CastForm.DesktopRef.SetDifferenceDesktop = screenModel.Desktop;
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                string msgWithClientName = $"{data.Sender.Name}: {msg}";

                if (data.Sender.Name == clientModel.Name)
                {
                    AddMessage(msgWithClientName, Color.LightGreen);
                }
                else
                {
                    AddMessage(msgWithClientName);
                    Form.Notify(data.Sender.Name, msg.Length > 30 ? msg.Substring(0, 30) + ".." : msg);
                }
            }
        }

        public void ClientJoined(ClientModel clientModel)
        {
            Clients.Add(clientModel);
            AddMessage($"{clientModel.Name} joined.");
        }
    }
}
