using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace SecuredChat
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class HostService : ChatService, IHostService
    {
        private readonly ServiceHost serviceHost;

        public HostService(IChatForm form) : base(form)
        {
            serviceHost = new ServiceHost(this, new Uri("net.tcp://localhost:8080/SecuredChat/"));
            serviceHost.AddServiceEndpoint(typeof(IHostService), GetBinding(), "tcp");

            serviceHost.Opened += ServiceHost_StateChanegd;
            serviceHost.Closed += ServiceHost_StateChanegd;
            serviceHost.Faulted += ServiceHost_StateChanegd;
        }

        private void ServiceHost_StateChanegd(object sender, EventArgs e)
        {
            form.Connected = serviceHost.State == CommunicationState.Opened;
            form.Status(serviceHost.State.ToString());
            if (serviceHost.State == CommunicationState.Closed || serviceHost.State == CommunicationState.Faulted)
            {
                Clients.Clear();
            }
        }

        public string CurrentSessionId { get { return OperationContext.Current?.SessionId; } }

        public CommunicationState State { get { return serviceHost.State; } }

        public void Connect(ClientModel clientModel)
        {
            AddClient(clientModel);
            AddMessage($"{clientModel.Name} joined.");
            Receive(new ChatJoin { Sender = clientModel }, CurrentSessionId);
            ReceiveTo(new ChatJoin { Sender = clientModel, Clients = Clients.ToList() }, CurrentSessionId);
        }

        public void Disconnect()
        {
            DisconnectClient(CurrentSessionId);
        }

        private void DisconnectClient(string session_id)
        {
            var client = GetClient(session_id);
            if (client.Context != null && client.Context.Channel != null && client.Context.Channel.State == CommunicationState.Opened)
            {
                client.Context.Channel.Close();
            }

            RemoveClient(session_id);
            AddMessage($"{client.Name} left.");
            Receive(new ChatLeave { Sender = client });
        }

        private void DisconnectAll()
        {
            var sessions = Clients.Select(c => c.SessionId).ToList();
            foreach (var sid in sessions)
            {
                DisconnectClient(sid);
            }
        }

        public async Task Send(object data)
        {
            var client = GetClient(CurrentSessionId);

            List<string> send_to_all_except = new List<string>();

            DataModel dataModel = null;

            if (data is string && !string.IsNullOrWhiteSpace(Convert.ToString(data)))
            {
                dataModel = new ChatMessage { Sender = client, Data = data };
                AddMessage($"{client.Name}: {data}");
            }
            else if (data is ScreenModel)
            {
                send_to_all_except.Add(CurrentSessionId);
                dataModel = data as ScreenModel;
                dataModel.Sender = client;
            }
            else if (data is DataModel)
            {
                send_to_all_except.Add(CurrentSessionId);
                dataModel = (DataModel)data;
                dataModel.Sender = client;
            }

            if (dataModel != null)
            {
                await Receive(dataModel, send_to_all_except.ToArray());
            }
        }

        public void SendMessageToClients(string message)
        {
            var sender = new ClientModel { Name = $"{Environment.UserName} (HOST)" };
            Receive(new ChatMessage { Sender = sender, Message = message });
            AddMessage($"{sender.Name}: {message}");
        }

        private async Task Receive(DataModel data, params string[] except_session_ids)
        {
            var sessions = Clients.Select(c => c.SessionId).Except(except_session_ids).ToList();

            foreach (var sid in sessions)
            {
                var client = Clients.FirstOrDefault(c => c.SessionId == sid);
                try
                {
                    Task.Run(() => client.Callback.Receive(data));
                }
                catch { }
            }
        }

        private void ReceiveTo(DataModel data, params string[] session_ids)
        {
            var sessions = Clients.Select(c => c.SessionId).Where(sid => session_ids.Contains(sid)).ToList();
            foreach (var sid in sessions)
            {
                var client = Clients.FirstOrDefault(c => c.SessionId == sid);
                try
                {
                    client.Callback.Receive(data);
                }
                catch { }
            }
        }

        private ClientModel GetClient(string session_id)
        {
            return Clients.SingleOrDefault(c => c.SessionId == session_id);
        }

        private void AddClient(ClientModel clientModel)
        {
            clientModel.Context = OperationContext.Current;
            clientModel.SessionId = clientModel.Context.SessionId;
            clientModel.Context.Channel.Faulted += Channel_Faulted;

            RemoveClient(clientModel.SessionId);
            Clients.Add(clientModel);
        }

        private void Channel_Faulted(object sender, EventArgs e)
        {
            IContextChannel channel = sender as IContextChannel;
            DisconnectClient(channel.SessionId);
        }

        public void Start()
        {
            if (serviceHost.State != CommunicationState.Opened)
            {
                serviceHost.Open(TimeSpan.FromSeconds(5));
            }
        }

        public void Stop()
        {
            if (serviceHost.State == CommunicationState.Opened)
            {
                DisconnectAll();

                serviceHost.Close(TimeSpan.FromMilliseconds(1500));
            }
            else
            {
                serviceHost.Abort();
            }
        }
    }
}
