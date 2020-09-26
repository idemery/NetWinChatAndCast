using System.ServiceModel;

namespace SecuredChat
{
    public interface IClientService
    {
        [OperationContract(IsOneWay = true)]
        void Receive(DataModel data);

        [OperationContract(IsOneWay = true)]
        void ClientJoined(ClientModel clientModel);
    }
}
