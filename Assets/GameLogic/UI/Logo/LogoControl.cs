using GFramework.UI;
namespace GameLogic.UI
{
    public class LogoControl : BaseViewModel
    {
        public void OnLogoPlayOver()
        {
            UIMgr.ShowUI<UILogin, LoginControl>();
            this.bindingView.Close();
        }
    }
}