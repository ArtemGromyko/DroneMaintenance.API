using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class ContractSparePartRepository : RepositoryBase<ContractSparePart>, IContractSparePartRepository
    {
        public ContractSparePartRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<ContractSparePart>> GetAllContractSparePartsAsync() =>
            await FindAll().ToListAsync();

        public async Task<ContractSparePart> GetContractSparePartByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateContractSparePartAsync(ContractSparePart contractSparePart) =>
            await CreateAsync(contractSparePart);

        public async Task UpdateContractSparePartAsync(ContractSparePart contractSparePart) =>
            await UpdateAsync(contractSparePart);

        public async Task DeleteContractSparePartAsync(ContractSparePart contractSparePart) =>
            await DeleteAsync(contractSparePart);
    }
}

