using MagicOnion.Server.Hubs;
using MagicOnionSever.Model.Context;
using Shared.Interfaces.StreamingHubs;

namespace MagicOnionSever.StreamingHubs
{
    public class RoomHub : StreamingHubBase<IRoomHub, IRoomHubReceiver>, IRoomHub
    {
        private IGroup room;

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
            roomStorage.Set(this.ConnectionId,roomData);

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
    }
}
