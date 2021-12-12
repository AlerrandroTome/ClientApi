using ClientApi.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientApi.Infrastructure.Mappings
{
    public class CityModelConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            _ = builder.ToTable("City");

            builder.AddBaseMapping();

            _ = builder.Property(p => p.Name).IsRequired();
            _ = builder.Property(p => p.State).IsRequired();

            _ = builder.HasMany(o => o.Clients)
                   .WithOne(o => o.City)
                   .HasForeignKey(fk => fk.CityId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
