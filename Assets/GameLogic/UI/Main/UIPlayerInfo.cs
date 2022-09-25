using System;
using GFramework.UI;
using UnityEngine.UI;
namespace GameLogic.UI
{
    public class UIPlayerInfo : BaseView<ModelPlayerInfo>
    {
        protected override void BindEvents()
        {
            base.BindEvents();
            this.propertyBinder.Add<string>("playerName", UpdatePlayerName);
        }

        private void UpdatePlayerName(string oldValue, string newValue)
        {
            this.txtName.text = newValue;
        }

        // ++
        public override string BindingPath()
        {
            return "Main/PlayerInfo.prefab";
        }
        private Image imgHead;
        private Text txtName;
        protected override void BindVars()
        {
            imgHead = this.GetVar<Image>(0);
            txtName = this.GetVar<Text>(1);
        }
        // --
    }
}
