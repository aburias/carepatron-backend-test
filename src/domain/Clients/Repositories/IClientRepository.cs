using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.Clients.Entities;

namespace domain.Clients.Repositories
{
    public interface IClientRepository
    {
        Task<Client[]> Get();
        Task<string> Create(Client client);
        Task Update(Client client);
        Task<List<Client>> Search(string query);
    }
}
