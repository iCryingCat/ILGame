using System.Collections;
using System.Collections.Generic;

using GFramework;
using GFramework.Network;

using Lockstep.Math;

using UnityEngine;

namespace GameLogic
{
    public class NetPlayer : MonoBehaviour
    {
        GLogger logger = new GLogger("NetPlayer");

        private bool isLocal = true;
        private InputContainer lastContainer = new InputContainer();
        private InputContainer nextContainer = new InputContainer();

        public void Preset(bool isLocal)
        {
            this.isLocal = isLocal;
            if (isLocal)
            {
                CameraMgr.SetCameraFollow(CameraMgr.Instance.mainCamera, this.transform);
            }
            MonoLoop.Instance.AddUpdateListener(OnUpdate);
            if (Solution.netMode == NetMode.Network && this.isLocal)
            {
                MonoLoop.Instance.StartCoroutine(OnTick());
            }

        }

        void OnUpdate()
        {
            if (isLocal)
            {
                Move();
            }
            Dictionary<InputCode, LFloat> floatInput = this.lastContainer.floatInput;
            LFloat forword = LFloat.zero;
            LFloat right = LFloat.zero;
            floatInput.TryGetValue(InputCode.Forward, out forword);
            floatInput.TryGetValue(InputCode.Right, out right);
            DoMove(forword, right);
        }

        IEnumerator OnTick()
        {
            while (true)
            {
                // 帧结束发送输入信息给服务器
                yield return new WaitForEndOfFrame();
                TickAgent.Instance.tickService.ToHandleInput(this.nextContainer);
            }
        }

        public void SynInput(InputContainer container)
        {
            this.lastContainer = container;
        }

        public void Move()
        {
            LFloat forward = InputHandler.Forward.ToLFloat();
            LFloat right = InputHandler.Right.ToLFloat();
            nextContainer.floatInput[InputCode.Forward] = forward;
            nextContainer.floatInput[InputCode.Right] = right;
            if (Solution.netMode == NetMode.Local) DoMove(forward, right);
        }

        private void DoMove(LFloat forward, LFloat right)
        {
            this.transform.position += transform.forward * forward.ToFloat() + transform.right * right.ToFloat();
        }
    }
}