﻿using MagicOnionSever.Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace MagicOnionSever.Model.Context
{
    public class GameDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }  //テーブル追加(エンティティ追加)したらここにつかしていく

        readonly string connectionString =
            "server=localhost;database=realtime_game;user=jobi;password=jobi";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8,0)));
        }
    }
}
