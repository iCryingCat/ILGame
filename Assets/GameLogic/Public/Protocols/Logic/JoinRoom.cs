using System.Net;
using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class JoinRoomReq
    {
        public int port;

        public JoinRoomReq() { }

        public JoinRoomReq(int port)
        {
            this.port = port;
        }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class JoinRoomResp
    {
        public ulong roomID;
        public ulong netID;

        public JoinRoomResp() { }

        public JoinRoomResp(ulong roomID, ulong netID)
        {
            this.roomID = roomID;
            this.netID = netID;
        }
    }
}