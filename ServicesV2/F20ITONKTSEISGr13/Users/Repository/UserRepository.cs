using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Data;
using Users.Models;

namespace Users.Repository
{
    public class UserRepository : IUserRepository
    {
        private UsersContext _context;

        public UserRepository(UsersContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetListOfUsers()
        {
            return _context.User.ToList();
        }

        public User GetUserByEmail(string email)
        {
            return _context.User.SingleOrDefault(user => user.Email == email);
        }

        public User GetUserById(int id)
        {
            return id != 0 ? _context.User.Find(id) : null;
        }

        public void AddUser(User user)
        {
            if (user != null)
            {
                _context.User.Add(user);
                Save();
            }
        }

        public void RemoveUser(int id)
        {
            var currentUser = _context.User.Find(id);
            _context.User.Remove(currentUser);
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }        
    }
}
