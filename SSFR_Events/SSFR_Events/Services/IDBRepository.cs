using SSFR_Events.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SSFR_Events.Services
{
    public interface IDBRepository
    {

        //CRUD Users
        Task<bool> AddUser(User user);
        Task<User> GetUser(int id);
        Task<IEnumerable<User>> GetUsers();
        Task<bool> UserExist(int id);
        Task<bool> UpdateUser(User user);
        Task<bool> DeleteUser(User user);

        //CRUD Guests
        Task<bool> AddGuest(Guest guest);
        Task<Guest> GetGuest(int id);
        Task<IEnumerable<Guest>> GetGuests();
        Task<bool> GuestExits(int id);
        Task<bool> UpdateGuest(Guest guest);
        Task<bool> DeleteGuest(Guest guest);

        //CRUD Events
        Task<bool> AddEvent(Events @event);
        Task<Events> GetEvent(int id);
        Task<IEnumerable<Events>> GetEvents();
        Task<bool> EventExists(int id);
        Task<bool> UpdateEvent(Events @event);
        Task<bool> DeleteEvent(Events @event);

        //CRUD Doormans
        Task<bool> AddDoorman(Doorman doorman);
        Task<Doorman> GetDoorman(int id);
        Task<IEnumerable<Doorman>> GetDoormans();
        Task<bool> DoormanExist(int id);
        Task<bool> UpdateDoorman(Doorman doorman);
        Task<bool> DeleteDoorman(Doorman doorman);
        
    }
}
