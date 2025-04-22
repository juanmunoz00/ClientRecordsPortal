using Microsoft.EntityFrameworkCore;
using ClientRecordsAPI.Models; // ensure this is correct

namespace ClientRecordsAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
