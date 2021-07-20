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

        public async Task<ContractSparePart> GetContractSparePartAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateContractSparePartAsync(ContractSparePart contractSparePart) =>
            CreateAsync(contractSparePart);

        public Task UpdateContractSparePartAsync(ContractSparePart contractSparePart) =>
            UpdateAsync(contractSparePart);

        public Task DeleteContractSparePartAsync(ContractSparePart contractSparePart) =>
            DeleteAsync(contractSparePart);
    }
}

