using System.Net.Sockets;
using System;
using System.Net;
using GFramework.Network;
using UnityEngine;

namespace Share.Network
{
    // 网络管理器
    public class RpcAgent : Singleton<RpcAgent>
    {
        // 大厅Rpc
        public HallService hallRpc { get; private set; }

        public NetStatHandler netStat = new NetStatHandler(NetStat.NotConnect);

        public void Setup()
        {
            var localIP = new IPEndPoint(IPAddress.Any, NetTool.GetAvailablePort());
            var remoteIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8888);
            var tcpClientProxy = new TcpClientProxy(new TcpClient(localIP), new LogicDispatcher(), new ProtoPacker());
            tcpClientProxy.Connect(remoteIP);
            this.hallRpc = new HallService(tcpClientProxy);
        }

        public void Dispose()
        {
            this.hallRpc.channel.Dispose();
        }
    }
}