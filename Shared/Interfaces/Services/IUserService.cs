using System;
using MagicOnion;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace Shared.Interfaces.Services
{
    /// <summary>
    /// ユーザー登録
    /// </summary>
    public interface IUserService : IService<IUserService>
    {
        /// <summary>
        /// ユーザー登録API
        /// </summary>
        /// <param name="name">ユーザー名</param>
        /// <returns>ユーザー名</returns>
        UnaryResult<int> RegistUserAsync(string name);
    }

    [MessagePackObject]
    public class Name
    {
        [Key(0)]
        public string name;
    }
}
