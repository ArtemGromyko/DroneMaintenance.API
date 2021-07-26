using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface ISparePartRepository
    {
        Task<List<SparePart>> GetAllSparePartsAsync();
        Task<SparePart> GetSparePartByIdAsync(Guid id);
        Task CreateSparePartAsync(SparePart sparePart);
        Task UpdateSparePartAsync(SparePart sparePart);
        Task DeleteSparePartAsync(SparePart sparePart);
    }
}
