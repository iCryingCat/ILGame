using GFramework;
using GFramework.UI;

using Share.Protocols;

namespace GameLogic.UI
{
    public class ModelLogin : BaseViewModel
    {
        GLogger logger = new GLogger("ModelLogin");

        public BindableProperty<string> userName;
        public BindableProperty<string> password;

        public void JoinOtherRoom(object resp)
        {
            JoinRoomResp joinRoomResp = resp as JoinRoomResp;
            logger.P(joinRoomResp.userName);
            GameHub.Instance.roleFactor.SpawnNetPlayer(0, true);
            this.bindingView.Close();
        }
    }
}