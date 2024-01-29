using application.Abstractions;
using application.Clients.Notifications.ClientCreated;
using application.Clients.Notifications.ClientEmailUpdated;
using domain.Clients.Entities;
using domain.Clients.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Persistence.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext dataContext;
        private readonly IMediator mediatr;

        public ClientRepository(DataContext dataContext, IMediator mediatr)
        {
            this.dataContext = dataContext;
            this.mediatr = mediatr;
        }

        public async Task<string> Create(Client client)
        {
            await dataContext.AddAsync(client);
            await dataContext.SaveChangesAsync();

            // Publish and ignore...maybe a bad idea :D 
            _ = this.mediatr.Publish(new ClientCreatedNotification(client.Email.Value));

            return client.Id.Value;
        }

        public Task<Client[]> Get()
        {
            return dataContext.Clients.ToArrayAsync();
        }

        public async Task Update(Client client)
        {
            var existingClient = await dataContext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);

            if (existingClient == null)
                return;

            if (existingClient.Email != client.Email)
                _ = this.mediatr.Publish(new ClientEmailUpdatedNotification(client.Email.Value)); // Have some checks for failing maybe...

            existingClient.Name = client.Name;
            existingClient.Email = client.Email;
            existingClient.PhoneNumber = client.PhoneNumber;

            await dataContext.SaveChangesAsync();
        }
    }
}

