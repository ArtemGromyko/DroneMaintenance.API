using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IDronesService
    {
        Task<DroneModel> GetDroneByIdAsync(Guid id);

        Task<List<DroneModel>> GetDronesAsync();

        Task<DroneModel> CreateDroneAsync(DroneForCreationModel droneForCreationModel);

        Task<Drone> DeleteDroneAsync(Guid id);
       
        Task<DroneModel> UpdateDroneAsync(Guid id, DroneForUpdateModel droneForUpdateModel);

        Task<(DroneForUpdateModel droneForUpdateModel, Drone droneEntity)> GetDroneToPatch(Guid id);
    }
}
