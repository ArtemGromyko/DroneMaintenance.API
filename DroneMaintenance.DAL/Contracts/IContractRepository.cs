using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface IContractRepository
    {
        Task<List<Contract>> GetAllContractsAsync();
        Task<Contract> GetContractByIdAsync(Guid id);
        Task<List<Contract>> GetAllContractsForRequestAsync(Guid requestId);
        Task<Contract> CheckContractExistenceForRequestAsync(Guid requestId);
        Task CreateContractAsync(Contract contract);
        Task UpdateContractAsync(Contract contract);
        Task DeleteContractAsync(Contract contract);
    }
}
