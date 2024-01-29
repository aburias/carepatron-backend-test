using domain.Clients.Repositories;
using infrastructure.Persistence.Repositories;

namespace api.ServiceExtensions
{
    public static class ClientServices
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            return services;
        }
    }
}
