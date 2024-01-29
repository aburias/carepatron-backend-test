using application.Common;
using AutoMapper;
using domain.Clients.Entities;
using domain.Clients.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<string>>
    {
        private readonly IClientRepository repo;
        private readonly IMapper mapper;

        public CreateClientCommandHandler(IClientRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<Response<string>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = this.mapper.Map<Client>(request);
                var clientId = await this.repo.Create(client);
                return new Response<string>
                {
                    Data = clientId,
                    ErrorMessage = string.Empty,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                // TODO: might need to improve error handling and retries with parrot...
                return new Response<string>
                {
                    Data = null,
                    IsSuccessful = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
