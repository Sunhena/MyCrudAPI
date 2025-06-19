using Microsoft.EntityFrameworkCore;
using MyCrudAPI.Models;

namespace MyCrudAPI.Services
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        { 
        }
        public DbSet<Items> Items { get; set; }

    }
}
