using System;
using Microsoft.EntityFrameworkCore;
using SSFR_Events.Services;

namespace SQLiteEntityFramework.cs
{
    public class DBRepository : IDBRepository
    {
        private readonly DatabaseContext dbContext;

        public DBRepository(string path)
        {
            dbContext = new DatabaseContext(path);
        }


    }
}
