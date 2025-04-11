using Microsoft.EntityFrameworkCore;
using UserRestAPI.Models;

namespace UserRestAPI.DataAcess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
