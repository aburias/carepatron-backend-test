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
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, string>
    {
        private readonly IClientRepository repo;
        private readonly IMapper mapper;

        public CreateClientCommandHandler(IClientRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }
        public async Task<string> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = this.mapper.Map<Client>(request);
            return await this.repo.Create(client);
        }
    }
}
