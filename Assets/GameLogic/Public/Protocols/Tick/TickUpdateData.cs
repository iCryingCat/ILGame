using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GFramework.Network;
using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class TickUpdateData
    {
        public ulong frameID;
        public ulong roomID;
        public IPEndPoint iPEndPoint;
        public InputContainer inputContainer;

        public TickUpdateData() { }

        public TickUpdateData(ulong frameID, ulong roomID, IPEndPoint iPEndPoint, InputContainer inputContainer)
        {
            this.frameID = frameID;
            this.roomID = roomID;
            this.iPEndPoint = iPEndPoint;
            this.inputContainer = inputContainer;
        }
    }
}