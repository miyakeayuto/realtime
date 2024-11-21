using MagicOnion;
using MagicOnion.Server;
using MagicOnionSever.Model.Context;
using MagicOnionSever.Model.Entity;
using Shared.Interfaces.Services;

namespace MagicOnionSever.Services
{
    public class UserService : ServiceBase<IUserService>, IUserService
    {
        public async UnaryResult<int> RegistUserAsync(string name)
        {
            using var context = new GameDbContext();
            //バリデーションチェック
            if(context.Users.Where(user => user.Name == name).Count() > 0)
            {
                throw new ReturnStatusException(Grpc.Core.StatusCode.InvalidArgument, "");
            }

            //テーブルにレコードを追加
            User user = new User();
            user.Name = name;
            user.Token = "";
            user.Created_at = DateTime.Now;
            user.Updated_at = DateTime.Now;
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
