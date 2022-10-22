using System;
using Google.Protobuf;
using Share.Protocols;

namespace GFramework.Network
{
    public class TickDispatcher : ADispatcher
    {
        GLogger logger = new GLogger("TickDispatcher");

        public override void DecodeForm(ProtoDefine define, byte[] data)
        {
            logger.P($"反序列化{define}类型消息");
            switch (define)
            {
                case ProtoDefine.S2C_Tick_Update: DealWithTickUpdate(ProtoBufNetSerializer.Decode<TickUpdateDataList>(data)); break;
                default:
                    throw new Exception($"没有找到协议--{define}--的定义！！！");
            }
        }

        private void DealWithTickUpdate(TickUpdateDataList tickUpdateDataList)
        {
            TickAgent.Instance.OnSynInput(tickUpdateDataList);
            logger.P("同步帧消息！！！");
        }

        public override void RegisterMsg(RpcCallBack response)
        {

        }
    }
}