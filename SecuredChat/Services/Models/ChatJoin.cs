using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecuredChat
{
    [DataContract]
    public class ChatJoin : DataModel
    {
        [DataMember]
        public List<ClientModel> Clients { get; set; }
    }
}
