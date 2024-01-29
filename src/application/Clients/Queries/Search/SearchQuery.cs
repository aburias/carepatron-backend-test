using application.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Queries.Search
{
    public record SearchQuery(string query) : IRequest<Response<List<ClientDto>>>;
}
