using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Clients.ValueObjects;

namespace domain.Clients.Entities
{
    public class Client
    {
        public required ClientId Id { get; set; }
        public required Name Name { get; set; }
        public required Email Email { get; set; }
        public required PhoneNumber PhoneNumber { get; set; }

        //public Client(string id, string firstName, string lastName, string email, string phoneNumber)
        //{
        //    Id = new ClientId(id);
        //    Name = new Name(firstName, lastName);
        //    Email = new Email(email);
        //    PhoneNumber = new PhoneNumber(phoneNumber);
        //}
    }
}
