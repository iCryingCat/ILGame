using System.Collections;
using System.Collections.Generic;
using System.Net;

using GameLogic;
using UnityEngine;

namespace GFramework.Network
{
    public class TickAgent : Singleton<TickAgent>, IBattle2Scene
    {
        public TickService tickService { get; private set; }
        private Dictionary<int, NetPlayer> netPlayers = new Dictionary<int, NetPlayer>();

        public long currFrameID { get; private set; }

        public void Setup()
        {
            IPEndPoint iPEndPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), NetTool.GetAvailablePort());
            tickService = new TickService(new UdpClientProxy(iPEndPoint, new TickDispatcher(), new ProtoPacker()));
        }

        public void OnSynInput(int unitID, InputContainer data)
        {
            if (!this.netPlayers.ContainsKey(unitID)) return;
            this.netPlayers[unitID].SynInput(data);
        }
    }
}