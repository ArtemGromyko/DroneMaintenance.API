using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class DronesService : IDronesService
    {
        private readonly IMapper _mapper;
        private readonly IDroneRepository _droneRepository;

        public DronesService(IMapper mapper, IDroneRepository droneRepository)
        {
            _mapper = mapper;
            _droneRepository = droneRepository;
        }

        public async Task<DroneModel> GetDroneByIdAsync(Guid id)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            if (droneEntity == null)
            {
                return null;
            }
                
            return _mapper.Map<DroneModel>(droneEntity);
        }

        public async Task<List<DroneModel>> GetDronesAsync()
        {
            var droneEntities = await _droneRepository.GetAllDronesAsync();

            return _mapper.Map<List<DroneModel>>(droneEntities);
        }

        public async Task<DroneModel> CreateDroneAsync(DroneForCreationModel droneForCreationModel)
        {
            var droneEntity = _mapper.Map<Drone>(droneForCreationModel);

            await _droneRepository.CreateDroneAsync(droneEntity);

            return _mapper.Map<DroneModel>(droneEntity);
        }

        public async Task<DroneModel> UpdateDroneAsync(Guid id, DroneForUpdateModel droneForUpdateModel)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            if (droneEntity == null)
            {
                return null;
            }

            _mapper.Map(droneForUpdateModel, droneEntity);

            await _droneRepository.UpdateDroneAsync(droneEntity);

            return _mapper.Map<DroneModel>(droneEntity);
        }

        public async Task<Drone> DeleteDroneAsync(Guid id)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            if (droneEntity == null)
            {
                return null;
            }

            await _droneRepository.DeleteDroneAsync(droneEntity);

            return droneEntity;
        }

        public async Task<(DroneForUpdateModel droneForUpdateModel, Drone droneEntity)> GetDroneToPatch(Guid id)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            if (droneEntity == null)
            {
                return (null, null);
            }

            var droneForUpdateModel = _mapper.Map<DroneForUpdateModel>(droneEntity);

            return (droneForUpdateModel, droneEntity);
        }

        public async Task<DroneModel> UpdateDroneAsync(Drone droneEntity, DroneForUpdateModel droneForUpdateModel)
        {
            _mapper.Map(droneForUpdateModel, droneEntity);

            await _droneRepository.UpdateDroneAsync(droneEntity);

            return _mapper.Map<DroneModel>(droneEntity);
        }
    }
}
