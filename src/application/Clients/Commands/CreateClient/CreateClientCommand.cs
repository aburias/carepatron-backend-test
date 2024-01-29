using application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Commands.CreateClient
{
    public record class CreateClientCommand(string Id, string FirstName, string LastName, string Email, string PhoneNumber) : IRequest<Response<string>>;
}
