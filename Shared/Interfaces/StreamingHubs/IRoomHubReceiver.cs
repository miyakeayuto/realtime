using System;
using System.Collections.Generic;
using System.Text;
using MagicOnion;

namespace Shared.Interfaces.StreamingHubs
{
    public interface IRoomHubReceiver
    {
        //[ここにサーバー側からクライアント側を呼び出す関数を定義]

        //ユーザーの入室通知
        void OnJoin(JoinedUser user);

        //ユーザーの退室通知
        //void OnLeave();

        //マッチング通知
        //void OnMatching(string roomName);

        //位置・回転をクライアントに送信する
        //void OnMove(接続ID,位置,回転);
    }
}
