using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class ClientsService : ServiceBase, IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRequestRepository _requestRepository;
        private readonly IDroneRepository _droneRepository;

        public ClientsService(IMapper mapper, IClientRepository clientRepository, IServiceRequestRepository requestRepository,
        IDroneRepository droneRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _requestRepository = requestRepository;
            _droneRepository = droneRepository;
        }

        public void CheckRequestStatus(RequestStatus status)
        {
            if (status != RequestStatus.Recived)
            {
                throw new ForbiddenActionException($"Unnable to change/delete service request with a status not equal RequestStatus.Recived");
            }
        }

        public async Task CheckClientExistence(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientByIdAsync(id);
            CheckEntityExistence(id, clientEntity, nameof(Client));
        }

        public async Task<Client> TryGetClientEntityByIdAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientByIdAsync(id);
            CheckEntityExistence(id, clientEntity, nameof(Client));

            return clientEntity;
        }

        public async Task<ServiceRequest> TryGetRequestForClientAsync(Guid clientId, Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestForClientAsync(clientId, id);
            CheckEntityExistence(clientId, id, requestEntity, nameof(ServiceRequest), nameof(Client));

            return requestEntity;
        }

        public async Task<List<ClientModel>> GetClientsAsync()
        {
            var clientEntities = await _clientRepository.GetAllClientsAsync();

            return _mapper.Map<List<ClientModel>>(clientEntities);
        }

        public async Task<ClientModel> GetClientAsync(Guid id)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

            return _mapper.Map<ClientModel>(clientEntity);
        }

        public async Task<ClientModel> CreateClientAsync(ClientForCreationModel clientForCreationModel)
        {
            var clientEntity = _mapper.Map<Client>(clientForCreationModel);
            await _clientRepository.CreateClientAsync(clientEntity);

            return _mapper.Map<ClientModel>(clientEntity);
        }

        public async Task DeleteClientAsync(Guid id)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

            await _clientRepository.DeleteClientAsync(clientEntity);
        }

        public async Task<ClientModel> UpdateClientAsync(Guid id, ClientForUpdateModel clientForUpdateModel)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

            _mapper.Map(clientForUpdateModel, clientEntity);

            await _clientRepository.UpdateClientAsync(clientEntity);

            return _mapper.Map<ClientModel>(clientEntity);
        }

        public async Task<ClientModel> UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel)
        {
            _mapper.Map(clientForUpdateModel, clientEntity);

            await _clientRepository.UpdateClientAsync(clientEntity);

            return _mapper.Map<ClientModel>(clientEntity);
        }

        public async Task<(ClientForUpdateModel clientForUpdateModel, Client clientEntity)> GetClientToPatch(Guid id)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

            var clientForUpdateModel = _mapper.Map<ClientForUpdateModel>(clientEntity);

            return (clientForUpdateModel, clientEntity);
        }

        public async Task<List<ServiceRequestModel>> GetRequestsForClientAsync(Guid clientId)
        {
            await CheckClientExistence(clientId);

            var requestEntities = await _requestRepository.GetAllServiceRequestsForClientAsync(clientId);

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> GetRequestForClientAsync(Guid clientId, Guid id)
        {
            await CheckClientExistence(clientId);

            var requestEntity = await TryGetRequestForClientAsync(clientId, id);
        
            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task DeleteRequestForClientAsync(Guid clientId, Guid id)
        {
            await CheckClientExistence(clientId);

            var requestEntity = await TryGetRequestForClientAsync(clientId, id);
            CheckRequestStatus(requestEntity.RequestStatus);

            await _requestRepository.DeleteServiceRequestAsync(requestEntity);
        }

        public async Task<ServiceRequestModel> CreateRequestForClientAsyn(Guid clientId, ServiceRequestForCreationModel requestForCreationModel)
        {
            await CheckClientExistence(clientId);

            var droneEntity = await _droneRepository.GetDroneByIdAsync(requestForCreationModel.DroneId);
            CheckEntityExistence(droneEntity.Id, droneEntity, nameof(Drone));
            
            requestForCreationModel.ClientId = clientId;
            var requestEntity = _mapper.Map<ServiceRequest>(requestForCreationModel);
            await _requestRepository.CreateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task<ServiceRequestModel> UpdateRequestForClientAsync(Guid clientId, Guid id, ServiceRequestForUpdateModel requestForUpdateModel)
        {
            await CheckClientExistence(clientId);

            var droneEntity = await _droneRepository.GetDroneByIdAsync(requestForUpdateModel.DroneId);
            CheckEntityExistence(requestForUpdateModel.DroneId, droneEntity, nameof(Drone));

            var requestEntity = await TryGetRequestForClientAsync(clientId, id);
            _mapper.Map(requestForUpdateModel, requestEntity);
            CheckRequestStatus(requestEntity.RequestStatus);
            requestEntity.ClientId = clientId;

            await _requestRepository.UpdateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }
    }
}
