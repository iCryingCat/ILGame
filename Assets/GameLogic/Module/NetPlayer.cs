using GFramework.Network;
using Lockstep.Math;
using UnityEngine;

namespace GameLogic
{
    public class NetPlayer : MonoBehaviour
    {
        private bool isLocal = false;

        public void Init(bool isLocal)
        {
            this.isLocal = isLocal;
            MonoLoop.Instance.AddUpdateListener(OnUpdate);
        }

        void OnUpdate()
        {
            if (isLocal)
            {

            }
        }

        public void SynInput(InputData data)
        {
            LFloat vertical = InputHandler.Forward.ToLFloat();
            LFloat horizontal = InputHandler.Right.ToLFloat();
        }

        private void Move(LFloat forward, LFloat right)
        {
            this.transform.position += transform.forward * forward + transform.right * right;
        }
    }
}