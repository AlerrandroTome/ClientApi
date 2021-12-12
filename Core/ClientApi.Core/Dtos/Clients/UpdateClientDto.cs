using ClientApi.Core.Dtos.Base;
using ClientApi.Core.Enums;
using System;

namespace ClientApi.Core.Dtos.Clients
{
    public class UpdateClientDto : BaseUpdateDto
    {
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CityId { get; set; }
    }
}
