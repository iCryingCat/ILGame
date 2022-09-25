using System.Net;
using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract]
    public class JoinRoomReq
    {
        [ProtoMember(1)]
        public int port;
    }

    [ProtoContract]
    public class JoinRoomResp
    {
        [ProtoMember(1)]
        public int netID;
        [ProtoMember(2)]
        public string userName;
    }
}