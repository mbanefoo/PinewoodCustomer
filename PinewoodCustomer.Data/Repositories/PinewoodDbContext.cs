using Microsoft.EntityFrameworkCore;
using PinewoodCustomer.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodCustomer.Data.Repositories
{
    public class PinewoodDbContext : DbContext
    {
        public PinewoodDbContext(DbContextOptions<PinewoodDbContext> options) : base(options) { }

        public DbSet<Customer> customers{ get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{

        //    optionsBuilder.uses
        //    base.OnConfiguring(optionsBuilder);

        //}
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<Customer>().(nameof(Customer));
        //}
    }
}
