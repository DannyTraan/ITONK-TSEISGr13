using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PublicShareOwnerControl.Models;

namespace PublicShareOwnerControl.Data
{
    public class PublicShareOwnerControlContext : DbContext
    {
        public PublicShareOwnerControlContext (DbContextOptions<PublicShareOwnerControlContext> options)
            : base(options)
        {
        }

        public DbSet<PublicShareOwnerControl.Models.StockInformation> StockInformation { get; set; }
    }
}
