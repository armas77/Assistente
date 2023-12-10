namespace Assistente.Api.Data
{
    using Assistente.Api.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<EventGroup> EventGroups { get; set; }

        public DbSet<EventEntry> EventEntries { get; set; }
    }
}
