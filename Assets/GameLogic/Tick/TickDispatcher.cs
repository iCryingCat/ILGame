using Google.Protobuf;

namespace GFramework.Network
{
    public class TickDispatcher : ADispatcher
    {
        public override void DecodeForm(ProtoDefine define, byte[] data)
        {
            switch (define)
            {
                case ProtoDefine.S2C_Tick_Update:
                    InputContainer inputData = ProtoBufNetSerializer.Decode<InputContainer>(data);
                    TickAgent.Instance.OnSynInput(0, inputData);
                    break;
            }
        }

        public override void RegisterMsg(RpcCallBack response)
        {

        }
    }
}