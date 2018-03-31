using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SSFR_Events.Models;

namespace SQLiteEntityFramework.cs
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Events> Events { get; set; }

        //public DbSet<Doorman> Doormans { get; set; }

        public DbSet<Guest> Guests { get; set; }

        private readonly string Path;

        public DatabaseContext(string _path)
        {
            Path = _path;
            //Database.EnsureCreated();
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlite($"FileName={Path}");
        }
    }
}
