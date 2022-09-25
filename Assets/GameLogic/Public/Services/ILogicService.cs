using GFramework.Network;
using Share.Protocols;

namespace Share.Services
{
    // 逻辑服务器请求消息协议
    public interface IHall2Logic : ICaller
    {
        void Login(LoginReq req, RpcCallBack callback);
        void JoinOtherRoom(JoinRoomReq req, RpcCallBack callback);
    }

    // 逻辑服务器下发消息协议
    public interface ILogic2Hall : ICallee
    {
        void OnTest();
    }
}