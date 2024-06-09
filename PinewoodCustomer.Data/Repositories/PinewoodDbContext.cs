using Microsoft.EntityFrameworkCore;
using PinewoodCustomer.Shared.Models;

namespace PinewoodCustomer.Data.Repositories
{
    public class PinewoodDbContext : DbContext
    {
        public PinewoodDbContext(DbContextOptions<PinewoodDbContext> options) : base(options) { }

        public DbSet<Customer> customers{ get; set; }
    }
}
