using System;

namespace ClientApi.Core.Dtos.Base
{
    public abstract class BaseUpdateDto
    {
        public Guid Id { get; set; }
        public DateTime LastChangeDate { get; } = DateTime.Now;
    }
}
