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
    }
}
