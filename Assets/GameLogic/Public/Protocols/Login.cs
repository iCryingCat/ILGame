using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract]
    public class LoginReq
    {
        [ProtoMember(0)]
        public string userName;
        [ProtoMember(1)]
        public string password;
    }

    [ProtoContract]
    public class LoginResp
    {

    }
}
