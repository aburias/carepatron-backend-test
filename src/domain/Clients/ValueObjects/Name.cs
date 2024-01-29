using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.Clients.ValueObjects
{
    // TODO: maybe add more validations here for inserting...
    public record Name(string FirstName, string LastName);
}
