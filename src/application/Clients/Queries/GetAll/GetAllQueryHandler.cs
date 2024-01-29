using application.Common;
using AutoMapper;
using domain.Clients.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, Response<List<ClientDto>>>
    {
        private readonly IMapper mapper;

        public GetAllQueryHandler(IClientRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public IClientRepository repo { get; }

        public async Task<Response<List<ClientDto>>> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var allClients = await this.repo.Get();
                var clients = this.mapper.Map<List<ClientDto>>(allClients);
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
