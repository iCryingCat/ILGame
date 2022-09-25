using GFramework;
using GFramework.Backpack;

namespace GameLogic
{
    /// <summary>
    /// 游戏主流程
    /// 作为中介者，拥有各个子系统的调用接口
    /// </summary>
    public class GameHub : MonoSingleton<GameHub>
    {
        public SceneStateController sceneStateController = new SceneStateController();
        public InventorySystem inventorySystem = new InventorySystem();
        public RoleFactor roleFactor = new RoleFactor();

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            //sceneStateController.SetState(new ChatScene(sceneStateController), "Chat");
        }

        private void Update()
        {
            if (sceneStateController != null)
            {
                sceneStateController.StateUpdate();
            }
        }
    }
}