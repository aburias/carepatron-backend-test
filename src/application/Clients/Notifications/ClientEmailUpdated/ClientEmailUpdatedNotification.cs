using MediatR;

namespace application.Clients.Notifications.ClientEmailUpdated
{
    public record ClientEmailUpdatedNotification(string Email) : INotification;
}
