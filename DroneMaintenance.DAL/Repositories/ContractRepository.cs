using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<Contract>> GetAllContractsAsync() =>
            await FindAll().ToListAsync();

        public async Task<Contract> GetContractByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateContractAsync(Contract contract) =>
            await CreateAsync(contract);

        public async Task UpdateContractAsync(Contract contract) =>
            await UpdateAsync(contract);

        public async Task DeleteContractAsync(Contract contract) =>
            await DeleteAsync(contract);
    }
}
