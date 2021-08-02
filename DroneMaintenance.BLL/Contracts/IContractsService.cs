using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Contract;
using DroneMaintenance.Models.RequestModels.ContractSparePart;
using DroneMaintenance.Models.ResponseModels.Contract;
using DroneMaintenance.Models.ResponseModels.ContractSparePart;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IContractsService
    {
        Task<Contract> TryGetContractEntityByIdAsync(Guid id);

        Task<ContractModel> GetContractAsync(Guid id);

        Task<List<ContractModel>> GetContractsAsync();

        Task<ContractModel> CreateContractAsync(ContractForCreationModel contractForCreationModel);

        Task DeleteContractAsync(Guid id);

        Task<ContractModel> UpdateContractAsync(Guid id, ContractForUpdateModel contractForUpdateModel);
        Task<ContractSparePartModel> GetSparePartForContractAsync(Guid contractId, Guid partId);
        Task<List<ContractSparePartModel>> GetSparePartsForContractAsync(Guid contractId);
        Task<ContractSparePartModel> CreateSparePartForContractAsync(Guid contractId, ContractSparePartForCreationModel contractPartForCreationModel);
        Task DeleteSparePartForContractAsync(Guid contractId, Guid partId);
        Task<ContractSparePartModel> UpdateSparePartForContractAsync(Guid contractId, Guid partId, ContractSparePartForUpdateModel contractPartForUpdateModel);
    }
}
