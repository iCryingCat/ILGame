using GFramework.Network;

namespace GFramework.Network
{
    public class TickService : IScene2Battle
    {
        private AChannel channel;

        public TickService(AChannel channel)
        {
            this.channel = channel;
        }

        public void ToHandleInput(InputContainer inputData)
        {
            var data = ProtoBufNetSerializer.Encode<InputContainer>(inputData);
            this.channel.Send(ProtoDefine.C2S_Tick_Input, data);
        }
    }
}