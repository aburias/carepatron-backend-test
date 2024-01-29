using application.Abstractions;
using MediatR;

namespace application.Clients.Notifications.ClientCreated
{
    public class ClientCreatedNotificationHandler : INotificationHandler<ClientCreatedNotification>
    {
        private readonly IClientService clientService;

        public ClientCreatedNotificationHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task Handle(ClientCreatedNotification notification, CancellationToken cancellationToken)
        {
            // TODO: could be better implemented with Message Queue or Pubsub in Service bus
            await this.clientService.NotifyClient(notification.Email);
        }
    }
}
