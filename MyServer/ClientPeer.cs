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
            switch (operationRequest.OperationCode)//通过OpCode区分请求
            {
                case 1:
                    MyServer.log.Info("服务器：收到了一个客户端的请求");
                    Dictionary<byte, object> data = operationRequest.Parameters;
                    object intValue;
                    data.TryGetValue(1, out intValue);
                    object stringValue;
                    data.TryGetValue(2, out stringValue);
                    MyServer.log.Info("服务器：得到客户端传来的参数数据是  " + intValue.ToString() + stringValue.ToString());

                    OperationResponse opResponse = new OperationResponse(1);

                    //向客户端发送参数
                    Dictionary<byte, object> data2 = new Dictionary<byte, object>();
                    data2.Add(1, 300);
                    data2.Add(2, "服务器：给客户端发送参数数据");
                    opResponse.SetParameters(data2);

                    SendOperationResponse(opResponse, sendParameters);//给客户端一个响应，只能在这里调用，在其它地方无效
                                                                      //客户端在没有向服务器端发送请求，但服务器端想通知或发送数据给客户端时，
                                                                      //就可以使用SendEvent方法，SendEvent方法可以在服务器任何地方调用。                   
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
    }
}
