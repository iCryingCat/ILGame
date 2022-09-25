using GFramework.UI;
using UnityEngine.UI;
namespace GameLogic.UI
{
    public class UIMain : BaseView<BaseViewModel>
    {

        // ++
        public override string BindingPath()
        {
            return "Main/UIMain.prefab";
        }
        private UIContainer PlayerInfo;
        private Button btnPlay;
        protected override void BindVars()
        {
            PlayerInfo = this.GetVar<UIContainer>(0);
            btnPlay = this.GetVar<Button>(1);
        }
        // --
    }
}
