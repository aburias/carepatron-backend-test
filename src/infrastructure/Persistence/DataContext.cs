using domain.Clients.Entities;
using infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ClientConfiguration());
            //new ClientConfiguration().Configure(builder.Entity<Client>());
        }
    }
}

