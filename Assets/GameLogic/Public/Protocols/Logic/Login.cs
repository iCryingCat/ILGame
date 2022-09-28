using GFramework.Network;

using ProtoBuf;

namespace Share.Protocols
{
    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LoginReq
    {
        public string userName;
        public string password;

        public LoginReq() { }

        public LoginReq(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }

    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class LoginResp
    {
        public int ok;
        public string userName;
        public string nickName;

        public LoginResp()
        {
        }

        public LoginResp(int ok, string userName, string nickName)
        {
            this.ok = ok;
            this.userName = userName;
            this.nickName = nickName;
        }
    }
}
