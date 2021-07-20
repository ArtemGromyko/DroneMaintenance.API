using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class ContractRepository : RepositoryBase<Contract>, IContractRepository
    {
        public ContractRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<Contract>> GetAllContractsAsync() =>
            await FindAll().ToListAsync();

        public async Task<Contract> GetContractAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateContractAsync(Contract contract) =>
            CreateAsync(contract);

        public Task UpdateContractAsync(Contract contract) =>
            UpdateAsync(contract);

        public Task DeleteContractAsync(Contract contract) =>
            DeleteAsync(contract);
    }
}
