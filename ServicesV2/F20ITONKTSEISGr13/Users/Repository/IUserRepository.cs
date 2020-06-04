using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Models;

namespace Users.Repository
{
    public interface IUserRepository
    {
        IEnumerable<User> GetListOfUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void RemoveUser(int id);
        void UpdateUser(User user);
        void Save();
    }
}
