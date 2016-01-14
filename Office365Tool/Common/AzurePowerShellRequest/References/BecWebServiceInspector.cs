using Microsoft.Online.Administration.Automation;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Common
{
    public class BecWebServiceInspector : IClientMessageInspector
    {
        private string m_token;
        public BecWebServiceInspector(string token)
        {
            this.m_token = token;
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            UserIdentityHeader header = new UserIdentityHeader
            {
                LiveToken = m_token
            };

            MessageHeader header2 = MessageHeader.CreateHeader("UserIdentityHeader", "http://provisioning.microsoftonline.com/", header);

            ClientVersionHeader header3 = new ClientVersionHeader
            {
                ClientId = new Guid("{50AFCE61-C917-435b-8C6D-60AA5A8B8AA7}"),
                Version = "1.1.0.0"
            };
            request.Headers.Add(MessageHeader.CreateHeader("ClientVersionHeader", "http://provisioning.microsoftonline.com/", header3));

            ContractVersionHeader contractVersionHeader = new ContractVersionHeader();
            contractVersionHeader.BecVersion = Microsoft.Online.Administration.Version.Version16;

            request.Headers.Add(MessageHeader.CreateHeader("ContractVersionHeader", "http://provisioning.microsoftonline.com/", contractVersionHeader));

            request.Headers.Add(MessageHeader.CreateHeader("TrackingHeader", "http://becwebservice.microsoftonline.com/", Guid.NewGuid()));
            return null;
        }
    }
}