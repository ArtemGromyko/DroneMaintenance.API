using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface IServiceRequestRepository
    {
        Task<List<ServiceRequest>> GetAllServiceRequestsAsync();
        Task<ServiceRequest> GetServiceRequestByIdAsync(Guid id);
        Task<List<ServiceRequest>> GetAllServiceRequestsForDroneAsync(Guid droneId);
        Task<ServiceRequest> GetServiceRequestForDroneAsync(Guid droneId, Guid id);
        Task CreateServiceRequestAsync(ServiceRequest serviceRequest);
        Task UpdateServiceRequestAsync(ServiceRequest serviceRequest);
        Task DeleteServiceRequestAsync(ServiceRequest serviceRequest);
        Task<List<ServiceRequest>> GetAllServiceRequestsForUserAsync(Guid userId);
        Task<ServiceRequest> GetServiceRequestForUserAsync(Guid userId, Guid id);
    }
}
