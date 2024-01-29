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

namespace application.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<bool>>
    {
        private readonly IClientRepository repo;
        private readonly IMapper mapper;

        public UpdateClientCommandHandler(IClientRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = this.mapper.Map<Client>(request);
                await this.repo.Update(client);
                return new Response<bool>
                {
                    Data = true,
                    ErrorMessage = string.Empty,
                    IsSuccessful = true
                };
            }
            catch (Exception ex)
            {
                // TODO: might need to improve error handling and retries with parrot...
                return new Response<bool>
                {
                    Data = false,
                    IsSuccessful = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
