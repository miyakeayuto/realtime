using System;
using MagicOnion;
using System.Collections.Generic;
using System.Text;
using MessagePack;

namespace Shared.Interfaces.Services
{
    /// <summary>
    /// はじめてのRPCサービス
    /// </summary>
    public interface IMyFirstService : IService<IMyFirstService>
    {
        /// <summary>
        /// 足し算処理を行う
        /// </summary>
        /// <param name="x">足す数</param>
        /// <param name="y">足される数</param>
        /// <returns>xとyの合計値</returns>
        UnaryResult<int> SumAsync(int x, int y);
    }

    [MessagePackObject]
    public class Number
    {
        [Key(0)]
        public float x;
        [Key(1)]
        public float y;
    }
}
