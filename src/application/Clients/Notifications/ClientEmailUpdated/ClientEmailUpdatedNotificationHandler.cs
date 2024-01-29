using application.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Clients.Notifications.ClientEmailUpdated
{
    public class ClientEmailUpdatedNotificationHandler : INotificationHandler<ClientEmailUpdatedNotification>
    {
        private readonly IClientService clientService;
        public ClientEmailUpdatedNotificationHandler(IClientService clientService)
        {
            this.clientService = clientService;
        }

        public async Task Handle(ClientEmailUpdatedNotification notification, CancellationToken cancellationToken)
        {
            // TODO: could be better implemented with Message Queue or Pubsub in Service bus
            await this.clientService.NotifyClient(notification.Email);
        }
    }
}
