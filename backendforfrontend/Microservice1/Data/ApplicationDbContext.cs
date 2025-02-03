using Microsoft.EntityFrameworkCore;
using Microservice1.Models;

/// <summary>
/// Represents the database context for the application.
/// </summary>
namespace Microservice1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DataItems in the database.
        /// </summary>
        public DbSet<DataItem> DataItems { get; set; }
    }
}