using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyServer
{
    //管理每个客户端的连接(类似客服)
    public class ClientPeer : Photon.SocketServer.ClientPeer
    {
        //构造方法
        public ClientPeer(InitRequest initRequest) : base(initRequest)
        {

        }
        //断开连接
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {

        }

        //处理客户端的请求
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {

        }
    }
}
