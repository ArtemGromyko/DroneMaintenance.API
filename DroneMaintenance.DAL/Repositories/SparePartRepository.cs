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

        public async Task<SparePart> GetSparePartAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateSparePartAsync(SparePart sparePart) =>
            CreateAsync(sparePart);

        public Task UpdateSparePartAsync(SparePart sparePart) =>
            UpdateAsync(sparePart);

        public Task DeleteSparePartAsync(SparePart sparePart) =>
            DeleteAsync(sparePart);
    }
}
