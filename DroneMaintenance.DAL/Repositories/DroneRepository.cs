using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class DroneRepository : RepositoryBase<Drone>, IDroneRepository
    {
        public DroneRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<Drone>> GetAllDronesAsync() =>
            await FindAll().ToListAsync();

        public async Task<Drone> GetDroneAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public Task CreateDroneAsync(Drone drone) =>
            CreateAsync(drone);

        public Task UpdateDroneAsync(Drone drone) =>
            UpdateAsync(drone);

        public Task DeleteDroneAsync(Drone drone) =>
            DeleteAsync(drone);
    }
}

