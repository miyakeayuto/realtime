using MagicOnion;
using MagicOnion.Server;
using Shared.Interfaces.Services;

namespace MagicOnionSever.Services
{
    public class MyFirstService : ServiceBase<IMyFirstService>, IMyFirstService
    {
        public async UnaryResult<int> SumAsync(int x, int y)
        {
            Console.WriteLine("Received:" + x + "," + y);
            return x + y;
        }
    }
}
