using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.SparePart;
using DroneMaintenance.Models.ResponseModels.SparePart;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface ISparePartsService
    {
        Task CheckSparePartExistenceAsync(Guid id);
        Task<SparePart> TryGetSparePartEntityByIdAsync(Guid id);

        Task<SparePartModel> GetSparePartAsync(Guid id);

        Task<List<SparePartModel>> GetSparePartsAsync();

        Task<SparePartModel> CreateSparePartAsync(SparePartForCreationModel partForCreationModel);

        Task DeleteSparePartAsync(Guid id);

        Task<SparePartModel> UpdateSparePartAsync(Guid id, SparePartForUpdateModel partForUpdateModel);
    }
}
