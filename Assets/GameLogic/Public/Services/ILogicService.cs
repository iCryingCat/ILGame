using System.Net;
using GFramework.Network;
using Share.Protocols;

namespace Share.Services
{
    // 逻辑服务器请求消息协议
    public interface IHall2Logic : ICaller
    {
        void ToLogin(LoginReq req, RpcCallBack callback);
        void ToJoinOtherRoom(JoinRoomReq req, RpcCallBack callback);
        void ToMatch(MatchReq req, RpcCallBack callback);
    }

    // 逻辑服务器下发消息协议
    public interface ILogic2Hall : ICallee
    {
        void OnOtherJoinRoom(IPEndPoint iPEndPoint, ulong roomID);
    }
}