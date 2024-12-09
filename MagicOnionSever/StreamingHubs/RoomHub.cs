using MagicOnion.Server.Hubs;
using MagicOnionSever.Model.Context;
using Shared.Interfaces.StreamingHubs;

namespace MagicOnionSever.StreamingHubs
{
    public class RoomHub : StreamingHubBase<IRoomHub, IRoomHubReceiver>, IRoomHub
    {
        private IGroup room;

        //入室
        public async Task<JoinedUser[]> JoinAsync(string roomName, int userId)
        {
            //ルームに参加＆ルームを保持
            this.room = await this.Group.AddAsync(roomName);

            //DBからユーザー情報取得
            GameDbContext context = new GameDbContext();
            var user = context.Users.Where(user => user.Id == userId).First();

            //グループストレージにユーザーデータを格納
            var roomStorage = this.room.GetInMemoryStorage<RoomData>();
            var joinedUser = new JoinedUser() { ConnectionID = this.ConnectionId, UserData = user };
            var roomData = new RoomData() { JoinedUser = joinedUser };
            roomStorage.Set(this.ConnectionId, roomData);

            //ルーム参加者全員に、ユーザーの入室通知を送信
            this.BroadcastExceptSelf(room).OnJoin(joinedUser);

            RoomData[] roomDataList = roomStorage.AllValues.ToArray<RoomData>();
            //参加中のユーザー情報を返す
            JoinedUser[] joinedUserList = new JoinedUser[roomDataList.Length];

            //roomDataListをループしてJoinedUserフィールドをjoinedUserListに格納
            for (int i = 0;i < roomDataList.Length; i++)
            {
                joinedUserList[i] = roomDataList[i].JoinedUser;
            }

            return joinedUserList;
        }

        //退室
        public async Task LeaveAsync()
        {
            //グループデータから削除
            this.room.GetInMemoryStorage<RoomData>().Remove(this.ConnectionId);

            //ルーム内のメンバーから自分を削除
            await room.RemoveAsync(this.Context);

            //退室したことを全メンバーに通知
            //this.BroadcastExceptSelf(room).OnLeave();
        }

        //準備完了
        /*public async Task ReadyHub()
        {
            //準備完了出来たことを自分のRoomDataに保存
            var roomDataStorage = this.room.GetInMemoryStorage<RoomData>();
            var roomData = roomDataStorage.Get(this.ConnectionId);
            //roomDataにboolやintで準備完了を保存しておく


            //全員準備できたか判定
            bool isReady = false;
            var roomDataList = roomDataStorage.AllValues.ToArray<RoomData>();
            foreach (var roomData in roomDataList)
            {
                //roomDataに保存した準備完了状態を確認

            }
            //全員準備完了したら全員にゲーム開始を通知

        }*/
    }
}
