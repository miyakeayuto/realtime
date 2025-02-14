using Cysharp.Net.Http;
using Cysharp.Threading.Tasks;
using Grpc.Net.Client;
using MagicOnion.Client;
using Shared.Interfaces.StreamingHubs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class RoomModel : BaseModel, IRoomHubReceiver
{
    private GrpcChannel channel;
    private IRoomHub roomHub;

    //接続ID
    public Guid ConnectionId { get; set; }
    //ユーザー接続通知
    public Action<JoinedUser> OnJoinedUser { get; set; }

    //MagicOnion接続処理
    public async UniTask ConnectAsync()
    {
        var handler = new YetAnotherHttpHandler() { Http2Only = true };
        var channel = GrpcChannel.ForAddress(
            ServerUrl, new GrpcChannelOptions() { HttpHandler = handler });
        roomHub = await StreamingHubClient.
                                ConnectAsync<IRoomHub, IRoomHubReceiver>(channel, this);
    }

    //MagicOnion切断処理
    public async UniTask DisconnectAsync()
    {
        if(roomHub != null) await roomHub.DisposeAsync();
        if(channel != null) await channel.ShutdownAsync();
        roomHub = null; channel = null;
    }

    //破棄処理
    async void OnDestroy()
    {
        //破棄する際（アプリ終了等）に接続を切る
        DisconnectAsync();
    }

    //入室
    public async UniTask JoinAsync(string roomName, int userId)
    {
        JoinedUser[] users = await roomHub.JoinAsync(roomName, userId);
        foreach(var user in users)
        {
            if (user.UserData.Id == userId) this.ConnectionId = user.ConnectionID;
            OnJoinedUser(user);
        }
    }

    //入室通知(IRoomHubReceiverインターフェースの実装)
    public void OnJoin(JoinedUser user)
    {
        OnJoinedUser(user);
    }

    //位置・回転を送信する


    //位置・回転の通知

}
