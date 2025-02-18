﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MagicOnion;

namespace Shared.Interfaces.StreamingHubs
{
    public interface IRoomHub : IStreamingHub<IRoomHub, IRoomHubReceiver>
    {
        //[ここにクライアント側からサーバー側を呼び出す関数を定義]

        //ユーザー入室
        Task<JoinedUser[]> JoinAsync(string roomName, int userId);

        //ユーザー退室


        //自動マッチング
        //Task<JoinedUser[]> JoinLobbyAsync(int userId);

        //位置・回転をサーバーに送信する
        //Task MoveAsync(位置,回転);
    }
}
