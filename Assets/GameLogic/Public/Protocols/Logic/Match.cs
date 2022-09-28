using System.Net;
using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MatchReq
    {
        public ulong netID;
        public int port;

        public MatchReq()
        {
        }

        public MatchReq(ulong netID, int port)
        {
            this.netID = netID;
            this.port = port;
        }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class MatchResp
    {
        public int ok = 1;
        public ulong roomID;
        public ulong netID;
        public int playerNum;

        public MatchResp()
        {
        }

        public MatchResp(int ok, ulong roomID, ulong netID, int playerNum)
        {
            this.ok = ok;
            this.roomID = roomID;
            this.netID = netID;
            this.playerNum = playerNum;
        }
    }
}