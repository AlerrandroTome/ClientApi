using ClientApi.Core.Enums;
using System;

namespace ClientApi.Core.Dtos.Clients
{
    public class CreateClientDto
    {
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid CityId { get; set; }
    }
}
