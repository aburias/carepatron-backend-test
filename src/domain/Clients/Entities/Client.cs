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
        public ClientId Id { get; set; }
        public Name Name { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public Client(string id, string firstName, string lastName, string email, string phoneNumber)
        {
            Id = new ClientId(id);
            Name = new Name(firstName, lastName);
            Email = new Email(email);
            PhoneNumber = new PhoneNumber(phoneNumber);
        }
    }
}
