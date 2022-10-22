using GameLogic;
using GameLogic.UI;
using GFramework;
using GFramework.Network;
using GFramework.UI;

using Share.Network;
using Share.Protocols;

using UnityEngine;

public class GameSetup : MonoBehaviour
{
    /// <summary>
    /// 游戏启动
    /// </summary>
    void Awake()
    {
        DontDestroyOnLoad(this);
        RpcAgent.Instance.Setup();
        TickAgent.Instance.Setup();
        CameraMgr.Instance.GenUICamera();
        UICanvas.Setup();
        UIMgr.ShowUI<UILogin, LoginControl>().BindingContext.Init(new UserData("xzj", "南山北海"));
    }

    private void OnApplicationQuit()
    {
        RpcAgent.Instance.Dispose();
    }
}
