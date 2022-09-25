using GFramework.UI;
namespace GameLogic.UI
{
    public class ModelPlayerInfo : BaseViewModel
    {
        private BindableProperty<string> playerName = new BindableProperty<string>();

        public void Init(UserData userData)
        {
            this.playerName.Value = userData.nickName;
        }
    }
}