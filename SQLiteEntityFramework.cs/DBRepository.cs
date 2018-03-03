using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SSFR_Events.Models;
using SSFR_Events.Services;

namespace SQLiteEntityFramework.cs
{
    public class DBRepository : IDBRepository
    {
        DatabaseContext dbContext;

        public DBRepository(string path)
        {
            dbContext = new DatabaseContext(path);
        }

        //*                  ADDS                   *\\

        public async Task<bool> AddDoorman(Doorman doorman)
        {
            var obj = await dbContext.Doormans.AddAsync(doorman);

            await dbContext.SaveChangesAsync();

            var added = obj.State == EntityState.Added;

            return added;

        }

        public async Task<bool> AddEvent(Events @event)
        {
            var obj = await dbContext.Events.AddAsync(@event);

            await dbContext.SaveChangesAsync();

            var added = obj.State == EntityState.Added;

            return added;
        }

        public async Task<bool> AddGuest(Guest guest)
        {
            var obj = await dbContext.Guests.AddAsync(guest);

            await dbContext.SaveChangesAsync();

            var added = obj.State == EntityState.Added;

            return added;
        }

        public async Task<bool> AddUser(User user)
        {
            var obj = await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var added = obj.State == EntityState.Added;

            return added;
        }

        public async Task<bool> DeleteDoorman(Doorman doorman)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteEvent(Events @event)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DoormanExist(Doorman doorman)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> EventExists(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Doorman> GetDoorman(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Doorman>> GetDoormans()
        {
            throw new NotImplementedException();
        }

        public async Task<Events> GetEvent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {
            throw new NotImplementedException();
        }

        public async Task<Guest> GetGuest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Guest>> GetGuests()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> GuestExits(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateDoorman(Doorman doorman)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateEvent(Events @event)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateGuest(Guest guest)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UserExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}
