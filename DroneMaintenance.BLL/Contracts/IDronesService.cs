using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IDronesService
    {
        Task<Drone> TryGetDroneEntityByIdAsync(Guid id);

        Task<DroneModel> GetDroneAsync(Guid id);

        Task<List<DroneModel>> GetDronesAsync();

        Task<DroneModel> CreateDroneAsync(DroneForCreationModel droneForCreationModel);

        Task DeleteDroneAsync(Guid id);
       
        Task<DroneModel> UpdateDroneAsync(Guid id, DroneForUpdateModel droneForUpdateModel);

        Task<DroneModel> UpdateDroneAsync(Drone droneEntity, DroneForUpdateModel droneForUpdateModel);

        Task<(DroneForUpdateModel droneForUpdateModel, Drone droneEntity)> GetDroneToPatch(Guid id);

        Task<List<ServiceRequestModel>> GetRequestsForDroneAsync(Guid droneId);

        Task<ServiceRequestModel> GetRequestsForDroneAsync(Guid droneId, Guid id);
    }
}
