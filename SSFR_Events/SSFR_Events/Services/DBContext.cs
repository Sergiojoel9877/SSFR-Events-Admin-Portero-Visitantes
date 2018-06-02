using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace SSFR_Events.Services
{
    public class DBContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Events> Events { get; set; }

        //public DbSet<Doorman> Doormans { get; set; }

        public DbSet<Guest> Guests { get; set; }

        string dbName = "SSFRDB.s3db";
        
        public DBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            string path = "";

            switch (Device.RuntimePlatform)
            {

                case Device.iOS:

                    SQLitePCL.Batteries_V2.Init();

                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", dbName);

                    break;

                case Device.Android:

                    path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), dbName);

                    break;

                default:
                    throw new NotImplementedException("Platform not supported");

            }

            dbContextOptionsBuilder.UseSqlite($"FileName={path}");
        }
    }
}
