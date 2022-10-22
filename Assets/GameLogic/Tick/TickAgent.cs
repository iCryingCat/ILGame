using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;

using GameLogic;
using Share.Protocols;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GFramework.Network
{
    public class TickAgent : Singleton<TickAgent>, IBattle2Scene
    {
        public TickService tickService { get; private set; }
        private Dictionary<ulong, NetPlayer> netPlayersMap = new Dictionary<ulong, NetPlayer>();
        public IPEndPoint handlerIP { get; private set; }
        public ulong netID { get; private set; }
        public ulong roomID { get; private set; }

        public ulong currFrameID { get; private set; }

        public void Setup()
        {
            this.handlerIP = new IPEndPoint(IPAddress.Parse("0.0.0.0"), NetTool.GetAvailablePort());
            var udpHandler = new UdpServerProxy(handlerIP, new TickDispatcher(), new ProtoPacker());
            udpHandler.BeginReceive();
            IPEndPoint senderIP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10086);
            var udpSender = new UdpClientProxy(senderIP, new TickDispatcher(), new ProtoPacker());
            udpSender.Connect(senderIP);
            tickService = new TickService(udpSender);
        }

        public void OnSynInput(TickUpdateDataList tickUpdateDataList)
        {
            List<TickUpdateData> dataList = tickUpdateDataList.dataList;
            int dataNum = dataList.Count;
            for (int i = 0; i < dataNum; ++i)
            {
                ulong netID = dataList[i].netID;
                NetPlayer player = null;
                if (netPlayersMap.TryGetValue(netID, out player))
                {
                    Loom.QueueOnMainThread((args) =>
                    {
                        var t = args as Tuple<NetPlayer, InputContainer>;
                        Debug.Log(t);
                        t.Item1.SynInput(t.Item2 as InputContainer);
                    }, new Tuple<NetPlayer, InputContainer>(player, dataList[i].inputContainer));
                }
            }
        }

        public void OnPlayerJoinRoom(ulong roomID, ulong netID, bool isLocal)
        {
            if (this.netPlayersMap == null) this.netPlayersMap = new Dictionary<ulong, NetPlayer>();
            this.netPlayersMap[netID] = null;
            if (isLocal) this.netID = netID;
            this.roomID = roomID;
        }

        public void OnGameStart()
        {
            CameraMgr.Instance.GenMainCamera();

            ulong[] playerIDs = this.netPlayersMap.Keys.ToArray();
            int playersNum = playerIDs.Length;
            for (int i = 0; i < playersNum; ++i)
            {
                NetPlayer player = GameHub.Instance.roleFactor.SpawnNetPlayer(netID);
                player.Preset(this.netID == playerIDs[i]);
                this.netPlayersMap[netID] = player;
            }
        }
    }
}