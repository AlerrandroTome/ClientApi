using ClientApi.Core.Enums;
using ClientApi.Core.Interfaces;
using System;

namespace ClientApi.Core.Entities
{
    public class Client : EntityBase, IODataEntity
    {
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
    }
}
