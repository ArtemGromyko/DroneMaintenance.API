using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class SparePartRepository : RepositoryBase<SparePart>, ISparePartRepository
    {
        public SparePartRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<SparePart>> GetAllSparePartsAsync() =>
            await FindAll().ToListAsync();

        public async Task<SparePart> GetSparePartByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateSparePartAsync(SparePart sparePart) =>
            await CreateAsync(sparePart);

        public async Task UpdateSparePartAsync(SparePart sparePart) =>
            await UpdateAsync(sparePart);

        public async Task DeleteSparePartAsync(SparePart sparePart) =>
            await DeleteAsync(sparePart);
    }
}
