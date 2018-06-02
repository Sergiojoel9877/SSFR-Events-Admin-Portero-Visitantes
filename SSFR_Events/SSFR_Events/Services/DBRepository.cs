using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSFR_Events.Services
{
    public class DBRepository : IDBRepository
    {

        private readonly DBContext dbContext = new DBContext();


        //*                  ADDS METHODS                   *\\

        //public async Task<bool> AddDoorman(Doorman doorman)
        //{
        //    var obj = await dbContext.Doormans.AddAsync(doorman);

        //    await dbContext.SaveChangesAsync();

        //    var added = obj.State == EntityState.Added;

        //    return added;

        //}

        public async Task<bool> AddEvent(Events @event)
        {
            var obj = await dbContext.Events.AddAsync(@event);

            await dbContext.SaveChangesAsync();

            var added = @event.Id == obj.Entity.Id;

            return added;
        }

        public async Task<bool> AddGuest(Guest guest)
        {
            var obj = await dbContext.Guests.AddAsync(guest);

            await dbContext.SaveChangesAsync();

            var added = guest.Id == obj.Entity.Id;

            return added;
        }

        public async Task<bool> AddUser(User user)
        {
            var obj = await dbContext.Users.AddAsync(user);

            await dbContext.SaveChangesAsync();

            var added = user.Id == obj.Entity.Id;

            return added;
        }

        //*                 DELETES METHODS                *\\

        //public async Task<bool> DeleteDoorman(Doorman doorman)
        //{
        //    var rem = dbContext.Doormans.Remove(doorman);

        //    await dbContext.SaveChangesAsync();

        //    var removed = doorman.Id == rem.Entity.Id;

        //    return removed;
        //}

        public async Task<bool> DeleteEvent(Events @event)
        {
            var rem = dbContext.Events.Remove(@event);

            await dbContext.SaveChangesAsync();

            var removed = @event.Id == rem.Entity.Id;

            return removed;
        }

        public async Task<bool> DeleteGuest(Guest guest)
        {
            var rem = dbContext.Guests.Remove(guest);

            await dbContext.SaveChangesAsync();

            var removed = guest.Id == rem.Entity.Id;

            return removed;
        }

        public async Task<bool> DeleteUser(User user)
        {
            var rem = dbContext.Users.Remove(user);

            await dbContext.SaveChangesAsync();

            var removed = user.Id == rem.Entity.Id;

            return removed;
        }

        //*                 GETTERS BY ID METHODS                   *\\

        //public async Task<Doorman> GetDoorman(int id) => await dbContext.Doormans.FindAsync(id) ?? null;

        public async Task<Events> GetEvent(int id) => await dbContext.Events.FindAsync(id) ?? null;

        public async Task<Guest> GetGuest(int id) => await dbContext.Guests.FindAsync(id) ?? null;

        public async Task<User> GetUser(int id) => await dbContext.Users.FindAsync(id) ?? null;


        //*                 GETTERS                 *\\

        //public async Task<IEnumerable<Doorman>> GetDoormans() => await dbContext.Doormans.AsNoTracking().ToListAsync() ?? null;

        public async Task<IEnumerable<Events>> GetEvents() => await dbContext.Events.AsNoTracking().ToListAsync() ?? null;

        public async Task<IEnumerable<Guest>> GetGuests() => await dbContext.Guests.AsNoTracking().ToListAsync() ?? null;

        public async Task<IEnumerable<User>> GetUsers() => await dbContext.Users.AsNoTracking().ToListAsync() ?? null;


        //*                 UPDATES METHODS                *\\

        //public async Task<bool> UpdateDoorman(Doorman doorman)
        //{
        //    var obj = dbContext.Doormans.Update(doorman);

        //    await dbContext.SaveChangesAsync();

        //    var modied = obj.State == EntityState.Modified;

        //    return true;
        //}

        public async Task<bool> UpdateEvent(Events @event)
        {
            var obj = dbContext.Events.Update(@event);

            await dbContext.SaveChangesAsync();

            var modied = @event.Id == obj.Entity.Id;

            return true;
        }

        public async Task<bool> UpdateGuest(Guest guest)
        {
            var obj = dbContext.Guests.Update(guest);

            await dbContext.SaveChangesAsync();

            var modied = guest.Id == obj.Entity.Id;

            return true;
        }

        public async Task<bool> UpdateUser(User user)
        {
            var obj = dbContext.Users.Update(user);

            await dbContext.SaveChangesAsync();

            var modied = user.Id == obj.Entity.Id;

            return true;
        }


        //*                 EXISTENCES METHODS                  *\\

        //public async Task<bool> DoormanExist(int id)
        //{

        //    var obj = await dbContext.Doormans.FindAsync(id);

        //    var all = await dbContext.Doormans.ToListAsync();

        //    foreach (Doorman D in all)
        //    {
        //        if (D.Id == obj.Id)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;

        //}

        public async Task<bool> EventExists(int id)
        {
            var obj = await dbContext.Events.FindAsync(id);

            var all = await dbContext.Events.ToListAsync();

            foreach (Events E in all)
            {
                if (E.Id == obj.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> GuestExits(int id)
        {
            var obj = await dbContext.Guests.FindAsync(id);

            var all = await dbContext.Guests.ToListAsync();

            foreach (Guest G in all)
            {
                if (G.Id == obj.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<bool> UserExist(int id)
        {
            var obj = await dbContext.Users.FindAsync(id);

            var all = await dbContext.Users.ToListAsync();

            foreach (User U in all)
            {
                if (U.Id == obj.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
