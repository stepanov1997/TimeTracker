using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTracker.Domain;

namespace TimeTracker.Models
{
    public class ClientModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        private ClientModel() { }
        public static ClientModel FromUser(Client client)
        {
            return new ClientModel()
            {
                Id = client.Id,
                Name = client.Name
            };
        }
    }
}
