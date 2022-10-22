using GFramework.Network;
using Share.Protocols;

namespace GFramework.Network
{
    public class TickService : IScene2Battle
    {
        GLogger logger = new GLogger("TickService");
        public readonly AChannel channel;

        public TickService(AChannel channel)
        {
            this.channel = channel;
        }

        public void ToHandleInput(InputContainer inputData)
        {
            TickUpdateData tickUpdateData = new TickUpdateData();
            tickUpdateData.frameID = TickAgent.Instance.currFrameID;
            tickUpdateData.roomID = TickAgent.Instance.roomID;
            tickUpdateData.netID = TickAgent.Instance.netID;
            tickUpdateData.inputContainer = inputData;
            var data = ProtoBufNetSerializer.Encode<TickUpdateData>(tickUpdateData);
            this.channel.Send(ProtoDefine.C2S_Tick_Input, data);
            logger.P($"向{this.channel.iPEndPoint}发送帧数据！！！");
        }
    }
}