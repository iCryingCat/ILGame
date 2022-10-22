using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TickUpdateData
    {
        public ulong frameID;
        public ulong roomID;
        public ulong netID;
        public InputContainer inputContainer;

        public TickUpdateData() { }

        public TickUpdateData(ulong frameID, ulong roomID, ulong netID, InputContainer inputContainer)
        {
            this.frameID = frameID;
            this.roomID = roomID;
            this.netID = netID;
            this.inputContainer = inputContainer;
        }
    }
}