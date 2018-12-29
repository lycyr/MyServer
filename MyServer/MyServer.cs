using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;


namespace MyServer
{
    //所有Server端 主类
    //函数执行顺序：Setup()->CreatePeer()->TearDown()
    class MyServer : ApplicationBase
    {
        //当一个客户端请求连接时
        //peerbase表示和一个客户端的连接 由PhotonServer完成调用
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            return new ClientPeer(initRequest);
        }
        //服务端应用启动的初始化操作  由PhotonServer完成调用
        protected override void Setup()
        {
           
        }
        //server端关闭 由PhotonServer完成调用
        protected override void TearDown()
        {
            
        }
    }
}
