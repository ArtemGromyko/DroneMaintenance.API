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

        public async Task<Client> GetClientByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateClientAsync(Client client) =>
            await CreateAsync(client);

        public async Task UpdateClientAsync(Client client) =>
            await UpdateAsync(client);

        public async Task DeleteClientAsync(Client client) =>
            await DeleteAsync(client);
    }
}
