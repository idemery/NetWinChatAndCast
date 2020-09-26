using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;

namespace SecuredChat
{
    public class Proxy : DuplexClientBase<IHostService>, IHostService
    {
        private ClientService clientService;
        public Proxy(InstanceContext instanceContext, ClientService clientService) 
            : base(instanceContext, clientService.GetBinding(), new EndpointAddress(clientService.Form.HostAddress))
        {
            this.clientService = clientService;

            InnerDuplexChannel.Opened += InnerDuplexChannel_StateChanged;
            InnerDuplexChannel.Closed += InnerDuplexChannel_StateChanged;
            InnerDuplexChannel.Faulted += InnerDuplexChannel_StateChanged;
            InnerChannel.Faulted += InnerChannel_Faulted;
            InnerChannel.Closed += InnerChannel_Closed;
        }

        private void InnerChannel_Closed(object sender, EventArgs e)
        {
            IClientChannel clientChannel = sender as IClientChannel;
            clientService.Form.Connected = false;
            clientService.Clients.Clear();
        }

        private void InnerChannel_Faulted(object sender, EventArgs e)
        {
            IClientChannel clientChannel = sender as IClientChannel;
            clientService.Form.Connected = false;
            clientService.Clients.Clear();
        }

        private void InnerDuplexChannel_StateChanged(object sender, EventArgs e)
        {
            IDuplexContextChannel duplexContext = sender as IDuplexContextChannel;

            clientService.Form.Connected = duplexContext.State == CommunicationState.Opened;
            clientService.Form.Status(duplexContext.State.ToString());
            if (duplexContext.State == CommunicationState.Closed || duplexContext.State == CommunicationState.Faulted)
            {
                clientService.Clients.Clear();
            }
        }

        public void Connect(ClientModel clientModel)
        {
            Channel.Connect(clientService.Client);
        }

        public void Disconnect()
        {
            if (State == CommunicationState.Opened)
            {
                try
                {
                    Channel.Disconnect();
                }
                catch
                {
                    Abort();
                }
            }
            else
            {
                Abort();
            }
        }

        public async Task Send(object data)
        {
            if (data == null)
            {
                return;
            }

            if (State != CommunicationState.Opened)
            {
                clientService.Form.Connected = false;
                clientService.Clients.Clear();
                return;
            }

            if (!string.IsNullOrWhiteSpace(clientService.Form.Password) && data is string && !string.IsNullOrWhiteSpace(Convert.ToString(data)))
            {
                data = AesHelper.EncryptText(data.ToString(), clientService.Form.Password);
            }

            if (State == CommunicationState.Opened)
            {
                try
                {
                    await Task.Run(() => Channel.Send(data));
                }
                catch
                {
                    clientService.Form.Connected = false;
                    clientService.Clients.Clear();
                    clientService.Form.Status("Closed by host");
                    return;
                }

            }
        }
    }
}
