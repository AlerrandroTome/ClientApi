using ClientApi.Core.Interfaces;
using System.Collections.Generic;

namespace ClientApi.Core.Entities
{
    public class City : EntityBase, IODataEntity
    {
        public string Name { get; set; }
        public string State { get; set; }
        public ICollection<Client> Clients { get; set; } = new List<Client>();
    }
}
