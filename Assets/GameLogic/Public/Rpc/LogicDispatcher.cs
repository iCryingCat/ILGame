using System;
using System.Collections.Generic;

using GameLogic;
using GFramework;
using GFramework.Network;

using Share.Protocols;

using UnityEngine.SceneManagement;

namespace Share.Network
{
    // 逻辑服协议解析器
    public class LogicDispatcher : ADispatcher
    {
        GLogger logger = new GLogger("LogicDispatcher");

        private Queue<RpcCallBack> responseQueue = new Queue<RpcCallBack>();
        private Queue<Object> receivedDataQueue = new Queue<object>();

        public LogicDispatcher()
        {
            MonoLoop.Instance.AddUpdateListener(OnUpdate);
        }

        private void OnUpdate()
        {
            if (receivedDataQueue == null) return;
            if (receivedDataQueue.Count > 0)
            {
                lock (this.receivedDataQueue)
                {
                    Object data = this.receivedDataQueue.Dequeue();
                    lock (this.responseQueue)
                    {
                        RpcCallBack resp = this.responseQueue.Dequeue();
                        logger.P($"分发 {resp} {data}");
                        resp.Invoke(data);
                    }
                }
            }
        }

        public override void DecodeForm(ProtoDefine define, byte[] data)
        {
            logger.P($"反序列化{define}类型消息");
            switch (define)
            {
                case ProtoDefine.C2S_Login:
                    Dispatch(ProtoBufNetSerializer.Decode<LoginResp>(data));
                    break;
                case ProtoDefine.C2S_Match:
                    Dispatch(ProtoBufNetSerializer.Decode<MatchResp>(data));
                    break;
                case ProtoDefine.S2C_OtherJoinRoom:
                    DealWithOtherJoinRoom(ProtoBufNetSerializer.Decode<JoinRoomResp>(data));
                    break;
                case ProtoDefine.S2C_Game_Start:
                    DealWithOtherGameStart(ProtoBufNetSerializer.Decode<AckResp>(data));
                    break;
                default:
                    throw new Exception($"没有找到协议--{define}--的定义！！！");
            }
        }

        public override void RegisterMsg(RpcCallBack response)
        {
            if (responseQueue == null) responseQueue = new Queue<RpcCallBack>();
            lock (this.responseQueue)
            {
                this.responseQueue.Enqueue(response);
            }
        }

        private void Dispatch<T>(T msg) where T : new()
        {
            if (this.receivedDataQueue == null) this.receivedDataQueue = new Queue<object>();
            lock (this.receivedDataQueue)
            {
                this.receivedDataQueue.Enqueue(msg);
            }
        }

        private void DealWithOtherJoinRoom(JoinRoomResp joinRoomResp)
        {
            logger.P("处理其他玩家加入房间消息");
            TickAgent.Instance.OnPlayerJoinRoom(joinRoomResp.roomID, joinRoomResp.netID, false);
            EventHub.Call(EventDefine.PlayerJoinRoom);
        }

        private void DealWithOtherGameStart(AckResp ackResp)
        {
            if (ackResp.ok == 0) return;
            logger.P("处理游戏开始消息");
            byte[] ack = ProtoBufNetSerializer.Encode<AckResp>(new AckResp(1));
            this.channel.Send(ProtoDefine.S2C_Game_Start, ack);
            Loom.QueueOnMainThread((arg) =>
            {
                TickAgent.Instance.OnGameStart();
                SceneManager.LoadScene("battle", LoadSceneMode.Additive);
                UIMgr.PopUI();
            }, null);
        }
    }
}