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
        // public DbSet<Skills> GetSkills { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Skillss>().HasNoKey();
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder
        //        .Entity<Skills>(
        //            eb =>
        //            {
        //                eb.HasNoKey();
        //               // eb.ToView("View_BlogPostCounts");
        //               // eb.Property(v => v.Name).HasColumnName("Name");
        //            });
        //}
    }
}
