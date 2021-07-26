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

        public async Task<Drone> GetDroneByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();
        public async Task CreateDroneAsync(Drone drone) =>
            await CreateAsync (drone);

        public async Task UpdateDroneAsync(Drone drone) =>
            await UpdateAsync(drone);

        public async Task DeleteDroneAsync(Drone drone) =>
            await DeleteAsync(drone);
    }
}

