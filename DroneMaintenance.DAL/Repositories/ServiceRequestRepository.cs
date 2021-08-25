using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class ServiceRequestRepository : RepositoryBase<ServiceRequest>, IServiceRequestRepository
    {
        public ServiceRequestRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<ServiceRequest>> GetAllServiceRequestsAsync() =>
            await FindAll().ToListAsync();

        public async Task<ServiceRequest> GetServiceRequestByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateServiceRequestAsync(ServiceRequest serviceRequest) =>
            await CreateAsync(serviceRequest);

        public async Task UpdateServiceRequestAsync(ServiceRequest serviceRequest) =>
            await UpdateAsync(serviceRequest);

        public async Task DeleteServiceRequestAsync(ServiceRequest serviceRequest) =>
            await DeleteAsync(serviceRequest);

        public async Task<List<ServiceRequest>> GetAllServiceRequestsForClientAsync(Guid clientId) =>
            await FindByCondition(s => s.UserId.Equals(clientId)).ToListAsync();

        public async Task<ServiceRequest> GetServiceRequestForClientAsync(Guid clientId, Guid id) =>
            await FindByCondition(s => s.UserId.Equals(clientId) && s.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task<List<ServiceRequest>> GetAllServiceRequestsForDroneAsync(Guid droneId) =>
            await FindByCondition(s => s.DroneId.Equals(droneId)).ToListAsync();

        public async Task<ServiceRequest> GetServiceRequestForDroneAsync(Guid droneId, Guid id) =>
            await FindByCondition(s => s.Id.Equals(id) && s.DroneId.Equals(droneId)).SingleOrDefaultAsync();
    }
}
