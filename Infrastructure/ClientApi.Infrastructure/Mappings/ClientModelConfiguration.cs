using ClientApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientApi.Infrastructure.Mappings
{
    public class ClientModelConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.AddBaseMapping();

            _ = builder.Property(p => p.Name).IsRequired();
            _ = builder.Property(p => p.Gender).IsRequired();
            _ = builder.Property(p => p.Age).IsRequired();
            _ = builder.Property(p => p.BirthDate).IsRequired();

            _ = builder.HasOne(o => o.City)
                       .WithMany(m => m.Clients)
                       .HasForeignKey(fk => fk.CityId)
                       .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
