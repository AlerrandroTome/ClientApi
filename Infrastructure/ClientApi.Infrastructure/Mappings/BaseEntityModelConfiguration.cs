using ClientApi.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientApi.Infrastructure.Mappings
{
    public static class BaseEntityModelConfiguration
    {
        public static void AddBaseMapping<T>(this EntityTypeBuilder<T> builder) where T : EntityBase
        {
            _ = builder.HasKey(k => k.Id);

            _ = builder.Property(w => w.InclusionDate)
                   .IsRequired();

            _ = builder.Property(w => w.LastChangeDate);
        }
    }
}
