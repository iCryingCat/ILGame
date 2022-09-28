using GFramework.UI;

using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.UI
{
    public class UIPlayerInfo : BaseView<PlayerInfoControl>
    {
        public override void BindProperty()
        {
            base.BindProperty();
            this.propertyBinder.Add<string>("userName", this.UpdateUserName);
        }

        protected override void BindEvents()
        {
            base.BindEvents();
        }

        public void UpdateUserName(string oldValue, string newValue)
        {
            this.txtName.text = newValue;
        }

        // ++
        public override string BindingPath()
        {
            return "Main/PlayerInfo.prefab";
        }
        private Text txtName;
        private Image imgHead;
        protected override void BindVars()
        {
            this.txtName = this.GetVar<Text>(0);
            this.imgHead = this.GetVar<Image>(1);
        }
        // --
    }
}
