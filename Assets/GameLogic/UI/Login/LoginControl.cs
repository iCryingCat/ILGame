using GFramework;
using GFramework.UI;
using Share.Network;
using Share.Protocols;

namespace GameLogic.UI
{
    public class LoginControl : BaseViewModel
    {
        GLogger logger = new GLogger("ModelLogin");

        public BindableProperty<string> userName = new BindableProperty<string>();
        public BindableProperty<string> password = new BindableProperty<string>();

        public void Init(UserData data)
        {
            this.userName.Value = data.userName;
            this.password.Value = data.nickName;
        }

        public void OnLogin()
        {
            RpcAgent.Instance.hallRpc.ToLogin(new LoginReq(this.userName.Value, this.password.Value), (resp) =>
            {
                LoginResp loginResp = resp as LoginResp;
                if (loginResp == null) return;
                UIMgr.ShowUI<UIMain, MainControl>().BindingContext.Init(new UserData(loginResp.userName, loginResp.nickName));
                this.bindingView.Close();
            });
        }
    }
}