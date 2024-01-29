using application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Queries.GetAll
{
    public record GetAllQuery() : IRequest<Response<List<ClientDto>>>;
}
