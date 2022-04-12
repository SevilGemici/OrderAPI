using Microsoft.EntityFrameworkCore;
using OrderAPI.Models;

namespace OrderAPI.Data
{
    public class APIContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public APIContext(DbContextOptions<APIContext> options) : base(options) { }
    }
}
