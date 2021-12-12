using ClientApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClientApi.Infrastructure.Context
{
    public class ClientContext : DbContext
    {
        public ClientContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ClientContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
