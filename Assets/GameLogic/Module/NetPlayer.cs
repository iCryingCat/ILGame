using System.Collections;
using GFramework;
using GFramework.Network;
using Lockstep.Math;
using UnityEngine;

namespace GameLogic
{
    public class NetPlayer : MonoBehaviour
    {
        private bool isLocal = true;
        private InputContainer inputContainer = new InputContainer();

        public void Init(bool isLocal)
        {
            this.isLocal = isLocal;
            MonoLoop.Instance.AddUpdateListener(OnUpdate);
            if (Solution.netMode == NetMode.Server && this.isLocal)
            {
                MonoLoop.Instance.StartCoroutine(OnTick());
            }
        }

        void OnUpdate()
        {
            if (isLocal)
            {
                Move();
                return;
            }
        }

        IEnumerator OnTick()
        {
            while (true)
            {
                // 帧结束发送输入信息给服务器
                yield return new WaitForEndOfFrame();
                TickAgent.Instance.tickService.ToHandleInput(inputContainer);
            }
        }

        public void SynInput(InputContainer container)
        {
            this.inputContainer = container;
        }

        public void Move()
        {
            LFloat forward = InputHandler.Forward.ToLFloat();
            LFloat right = InputHandler.Right.ToLFloat();
            inputContainer.floatInput[InputCode.Forward] = forward;
            inputContainer.floatInput[InputCode.Right] = right;
            if (Solution.netMode == NetMode.Local) DoMove(forward, right);
        }

        private void DoMove(LFloat forward, LFloat right)
        {
            this.transform.position += transform.forward * forward.ToFloat() + transform.right * right.ToFloat();
        }
    }
}