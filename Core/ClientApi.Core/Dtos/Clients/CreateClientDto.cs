using ClientApi.Core.Dtos.Base;
using ClientApi.Core.Enums;
using System;

namespace ClientApi.Core.Dtos.Clients
{
    public class CreateClientDto
    {
        public string Name { get; set; }
        public EGender Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public Guid CityId { get; set; }
    }
}
