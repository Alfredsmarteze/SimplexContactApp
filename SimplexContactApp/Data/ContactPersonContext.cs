using Microsoft.EntityFrameworkCore;
using SimplexContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimplexContactApp.Data
{
    public class ContactPersonContext : DbContext
    {
        public ContactPersonContext(DbContextOptions options) : base(options) { }

        public DbSet<ContactModel> Contact { get; set; }
    }
}
