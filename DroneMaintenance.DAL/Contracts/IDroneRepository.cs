using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface IDroneRepository
    {
        Task<List<Drone>> GetAllDronesAsync();
        Task<Drone> GetDroneAsync(Guid id);
        Task CreateDroneAsync(Drone drone);
        Task UpdateDroneAsync(Drone drone);
        Task DeleteDroneAsync(Drone drone);
    }
}
