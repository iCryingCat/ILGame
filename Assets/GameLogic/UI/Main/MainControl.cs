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
        public BindableProperty<string> playerNum = new BindableProperty<string>();

        public void OnMatch()
        {
            int port = NetTool.GetAvailablePort();
            IPAddress iPAddress = NetTool.GetLocalHost();
            ulong netID = NetTool.GenNetID(new IPEndPoint(iPAddress, port));
            RpcAgent.Instance.hallRpc.ToMatch(new MatchReq(netID, port), (resp) =>
            {
                MatchResp matchResp = resp as MatchResp;
                if (matchResp == null) return;
                this.playerNum.Value = matchResp.playerNum.ToString();
                // SceneManager.LoadScene("battle", LoadSceneMode.Additive);
                // GameHub.Instance.roleFactor.SpawnNetPlayer(matchResp.netID, true);
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