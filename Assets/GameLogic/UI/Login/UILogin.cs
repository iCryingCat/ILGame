using GFramework;
using GFramework.UI;

using Share.Network;
using UnityEngine.UI;

namespace GameLogic.UI
{
    public class UILogin : BaseView<LoginControl>
    {
        GLogger logger = new GLogger("UILogin");

        protected override void BindEvents()
        {
            base.BindEvents();
            this.inputName.onValueChanged.AddListener((text) => this.BindingContext.userName.Value = text);
            this.inputPwd.onValueChanged.AddListener((text) => this.BindingContext.password.Value = text);
            this.btnLogin.onClick.AddListener((this.BindingContext.OnLogin));
        }

        private void OnUpdateName(string oldValue, string newValue)
        {
            if (oldValue == newValue) return;
            this.inputName.text = newValue;
        }

        private void OnUpdatePwd(string oldValue, string newValue)
        {
            if (oldValue == newValue) return;
            this.inputPwd.text = newValue;
        }

        public override void BindProperty()
        {
            base.BindProperty();
            this.propertyBinder.Add<string>("userName", OnUpdateName);
            this.propertyBinder.Add<string>("password", OnUpdatePwd);
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
            this.inputName = this.GetVar<InputField>(0);
            this.inputPwd = this.GetVar<InputField>(1);
            this.btnLogin = this.GetVar<Button>(2);
        }
        // --
    }
}
