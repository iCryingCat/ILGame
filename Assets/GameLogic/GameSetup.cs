using GameLogic.UI;

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
        UICanvas.Setup();
        UIMgr.New<UILogin, ModelLogin>();
    }

    private void OnApplicationQuit()
    {
        RpcAgent.Instance.Dispose();
    }
}
