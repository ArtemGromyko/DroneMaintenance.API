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

        public async Task<ServiceRequest> GetServiceRequestAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateServiceRequestAsync(ServiceRequest serviceRequest) =>
            CreateAsync(serviceRequest);

        public Task UpdateServiceRequestAsync(ServiceRequest serviceRequest) =>
            UpdateAsync(serviceRequest);

        public Task DeleteServiceRequestAsync(ServiceRequest serviceRequest) =>
            DeleteAsync(serviceRequest);
    }
}
