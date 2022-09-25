using GFramework;
using GFramework.Network;
using GFramework.UI;

using Share.Network;
using Share.Protocols;

using UnityEngine.UI;

namespace GameLogic.UI
{
    public class UILogin : BaseView<ModelLogin>
    {
        GLogger logger = new GLogger("UILogin");

        protected override void BindEvents()
        {
            base.BindEvents();
            this.btnLogin.onClick.AddListener(this.JoinOtherRoom);
        }

        public void JoinOtherRoom()
        {
            RpcAgent.Instance.hallRpc.JoinOtherRoom(new JoinRoomReq() { port = NetTool.GetAvailablePort() }, this.BindingContext.JoinOtherRoom);
        }

        // ++
        public override string BindingPath()
        {
            return "Login/UILogin.prefab";
        }
        private InputField inputName;
        private InputField inputPwd;
        private Button btnLogin;
        protected override void BindVars()
        {
            inputName = this.GetVar<InputField>(0);
            inputPwd = this.GetVar<InputField>(1);
            btnLogin = this.GetVar<Button>(2);
        }
        // --
    }
}
