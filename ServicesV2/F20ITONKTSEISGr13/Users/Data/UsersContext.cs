using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext (DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public DbSet<Users.Models.User> User { get; set; }
    }
}
