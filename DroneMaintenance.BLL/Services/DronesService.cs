using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class DronesService : ServiceBase, IDronesService
    {
        private readonly IMapper _mapper;
        private readonly IDroneRepository _droneRepository;
        private readonly IServiceRequestRepository _requestRepository;

        public DronesService(IMapper mapper, IDroneRepository droneRepository, IServiceRequestRepository requestRepository)
        {
            _mapper = mapper;
            _droneRepository = droneRepository;
            _requestRepository = requestRepository;
        }

        public async Task CheckDroneExistence(Guid id)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            CheckEntityExistence(id, droneEntity, nameof(Drone));
        }

        public async Task<Drone> TryGetDroneEntityByIdAsync(Guid id)
        {
            var droneEntity = await _droneRepository.GetDroneByIdAsync(id);
            CheckEntityExistence(id, droneEntity, nameof(Drone));

            return droneEntity;
        }

        public async Task<DroneModel> GetDroneAsync(Guid id)
        {
            var droneEntity = await TryGetDroneEntityByIdAsync(id);

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
            var droneEntity = await TryGetDroneEntityByIdAsync(id);

            _mapper.Map(droneForUpdateModel, droneEntity);

            await _droneRepository.UpdateDroneAsync(droneEntity);

            return _mapper.Map<DroneModel>(droneEntity);
        }

        public async Task DeleteDroneAsync(Guid id)
        {
            var droneEntity = await TryGetDroneEntityByIdAsync(id);

            await _droneRepository.DeleteDroneAsync(droneEntity);
        }

        public async Task<(DroneForUpdateModel droneForUpdateModel, Drone droneEntity)> GetDroneToPatch(Guid id)
        {
            var droneEntity = await TryGetDroneEntityByIdAsync(id);

            var droneForUpdateModel = _mapper.Map<DroneForUpdateModel>(droneEntity);

            return (droneForUpdateModel, droneEntity);
        }

        public async Task<DroneModel> UpdateDroneAsync(Drone droneEntity, DroneForUpdateModel droneForUpdateModel)
        {
            _mapper.Map(droneForUpdateModel, droneEntity);

            await _droneRepository.UpdateDroneAsync(droneEntity);

            return _mapper.Map<DroneModel>(droneEntity);
        }

        public async Task<List<ServiceRequestModel>> GetRequestsForDroneAsync(Guid droneId)
        {
            await CheckDroneExistence(droneId);

            var requestEntities = await _requestRepository.GetAllServiceRequestsForDroneAsync(droneId);

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> GetRequestsForDroneAsync(Guid droneId, Guid id)
        {
            await CheckDroneExistence(droneId);

            var requestEntity = await _requestRepository.GetServiceRequestForDroneAsync(droneId, id);
            CheckEntityExistence(droneId, id, requestEntity, nameof(ServiceRequest), nameof(Drone));

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }
    }
}
