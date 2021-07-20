using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    interface IContractSparePartRepository
    {
        Task<List<ContractSparePart>> GetAllContractSparePartsAsync();
        Task<ContractSparePart> GetContractSparePartAsync(Guid id);
        Task CreateContractSparePartAsync(ContractSparePart contractSparePart);
        Task UpdateContractSparePartAsync(ContractSparePart contractSparePart);
        Task DeleteContractSparePartAsync(ContractSparePart contractSparePart);
    }
}
