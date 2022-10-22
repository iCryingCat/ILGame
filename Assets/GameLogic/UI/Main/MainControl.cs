using System.Net;
using GFramework;
using GFramework.Network;
using GFramework.UI;
using Share.Network;
using Share.Protocols;
using UnityEngine.SceneManagement;

namespace GameLogic.UI
{
    public class MainControl : BaseViewModel
    {
        public BindableProperty<UserData> uiPlayerInfo = new BindableProperty<UserData>();
        public BindableProperty<int> playerNum = new BindableProperty<int>();

        public MainControl()
        {
            EventHub.AddListener(EventDefine.PlayerJoinRoom, () =>
            {
                this.playerNum.Value++;
            });
        }

        public void OnMatch()
        {
            IPEndPoint localIP = TickAgent.Instance.handlerIP;
            ulong netID = NetTool.GenNetID(localIP);
            RpcAgent.Instance.hallRpc.ToMatch(new MatchReq(netID, localIP.Port), (resp) =>
            {
                MatchResp matchResp = resp as MatchResp;
                if (matchResp == null) return;
                this.playerNum.Value = matchResp.playerNum;
                TickAgent.Instance.OnPlayerJoinRoom(matchResp.roomID, matchResp.netID, true);
            });
        }

        public override void Init<T>(T data)
        {
            base.Init(data);
            UserData userData = data as UserData;
            this.uiPlayerInfo.Value = userData;
        }
    }
}