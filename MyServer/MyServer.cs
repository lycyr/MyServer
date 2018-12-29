using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Photon.SocketServer;
using log4net.Config;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using System.IO;

namespace MyServer
{
    //所有Server端 主类
    //函数执行顺序：Setup()->CreatePeer()->TearDown()
    class MyServer : ApplicationBase
    {
        //定义一个ILogger对象，用于日志输出
        private static readonly ILogger log = LogManager.GetCurrentClassLogger();//只能初始化一次
        
        //当一个客户端请求连接时
        //peerbase表示和一个客户端的连接 由PhotonServer完成调用
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            log.Info("Client Request!");
            return new ClientPeer(initRequest);
        }
        //服务端应用启动的初始化操作  由PhotonServer完成调用
        protected override void Setup()
        {
            //日志初始化
            //ApplicationRootPath为部署服务端程序目录 在这里指的是：F:\Photon\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(this.ApplicationRootPath, "log");//配置日志输出目录 同下
            //log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = @"F:\Photon\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy\log";//配置日志输出目录

            //BinaryPath为当前程序集的目录 在这里指的是：F:\Photon\Photon-OnPremise-Server-SDK_v4-0-29-11263\deploy\MyServer\bin
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                //告知Photon使用的是log4net日志插件
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);
                //让log4net插件读取配置文件
                XmlConfigurator.ConfigureAndWatch(configFileInfo);
            }

            log.Info("SetUp Completed!");
        }
        //server端关闭 由PhotonServer完成调用
        protected override void TearDown()
        {
            log.Info("Server is shutdown.");
        }
    }
}
