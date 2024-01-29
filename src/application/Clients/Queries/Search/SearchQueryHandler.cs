using application.Common;
using AutoMapper;
using domain.Clients.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Queries.Search
{
    public class SearchQueryHandler : IRequestHandler<SearchQuery, Response<List<ClientDto>>>
    {
        private readonly IClientRepository repo;
        private readonly IMapper mapper;

        public SearchQueryHandler(IClientRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<Response<List<ClientDto>>> Handle(SearchQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allClients = await this.repo.Search(request.query);
                var clients = new List<ClientDto>();

                // TODO: could have done better with the mapping...
                foreach (var client in allClients)
                    clients.Add(this.mapper.Map<ClientDto>(client));

                return new Response<List<ClientDto>>()
                {
                    Data = clients,
                    ErrorMessage = string.Empty,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                // Could have better way to handle exceptions with custom exceptions and handlers...
                return new Response<List<ClientDto>>()
                {
                    Data = null,
                    ErrorMessage = ex.Message,
                    IsSuccessful = false
                };
            }
        }
    }
}
