using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class ClientRepository : RepositoryBase<Client>, IClientRepository
    {
        public ClientRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<Client>> GetAllClientsAsync() =>
            await FindAll().ToListAsync();

        public async Task<Client> GetClientAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateClientAsync(Client client) =>
            CreateAsync(client);

        public Task UpdateClientAsync(Client client) =>
            UpdateAsync(client);

        public Task DeleteClientAsync(Client client) =>
            DeleteAsync(client);
    }
}
