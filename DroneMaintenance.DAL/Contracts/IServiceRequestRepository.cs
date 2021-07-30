using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface IServiceRequestRepository
    {
        Task<List<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<List<ServiceRequest>> GetAllServiceRequestsForClientAsync(Guid clientId);
        Task<ServiceRequest> GetServiceRequestForClientAsync(Guid clientId, Guid id);
        Task<ServiceRequest> GetServiceRequestByIdAsync(Guid id);
        Task CreateServiceRequestAsync(ServiceRequest serviceRequest);
        Task UpdateServiceRequestAsync(ServiceRequest serviceRequest);
        Task DeleteServiceRequestAsync(ServiceRequest serviceRequest);
    }
}
