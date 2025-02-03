using Microsoft.EntityFrameworkCore;
using Microservice2.Models;

namespace Microservice2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DataItem> DataItems { get; set; }
    }
}