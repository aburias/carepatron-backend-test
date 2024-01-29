using application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Commands.UpdateClient
{
    public record UpdateClientCommand(string Id, string FirstName, string LastName, string Email, string PhoneNumber) : IRequest<Response<bool>>;
}
