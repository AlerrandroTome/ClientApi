using System;

namespace ClientApi.Core.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime InclusionDate { get; set; } = DateTime.Now;
        public DateTime? LastChangeDate { get; set; }
    }
}
