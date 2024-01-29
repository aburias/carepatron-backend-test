using domain.Clients.Repositories;
using infrastructure.Persistence;
using infrastructure.Persistence.Repositories;

namespace api.ServiceExtensions
{
    public static class ClientServices
    {
        public static IServiceCollection AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<DataSeeder>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IDocumentRepository, DocumentRepository>();

            return services;
        }
    }
}
