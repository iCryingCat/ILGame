using GFramework.Network;

using Share.Protocols;
using Share.Services;
using UnityEngine;

namespace Share.Network
{
    public class HallService : IHall2Logic
    {
        public TcpClientProxy channel { get; }
        public HallService(TcpClientProxy channel)
        {
            this.channel = channel;
        }

        public void ToJoinOtherRoom(JoinRoomReq req, RpcCallBack callback)
        {
            this.channel.dispatcher.RegisterMsg(callback);
            byte[] data = ProtoBufNetSerializer.Encode<JoinRoomReq>(req);
            this.channel.Send(ProtoDefine.C2S_JoinOtherRoom, data);
        }

        public void ToLogin(LoginReq req, RpcCallBack callback)
        {
            this.channel.dispatcher.RegisterMsg(callback);
            this.channel.Send(ProtoDefine.C2S_Login, ProtoBufNetSerializer.Encode<LoginReq>(req));
        }

        public void ToMatch(MatchReq req, RpcCallBack callback)
        {
            this.channel.dispatcher.RegisterMsg(callback);
            this.channel.Send(ProtoDefine.C2S_Match, ProtoBufNetSerializer.Encode<MatchReq>(req));
        }
    }
}