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
    public class ClientsService : IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRequestRepository _requestRepository;
        private readonly IDronesService _donesService;

        public ClientsService(IMapper mapper, IClientRepository clientRepository, IServiceRequestRepository requestRepository, 
        IDronesService donesService)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _requestRepository = requestRepository;
            _donesService = donesService;
        }

        public async Task<Client> TryGetClientEntityByIdAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientByIdAsync(id);
            if (clientEntity == null)
                throw new EntityNotFoundException($"Client with id: {id} doesn't exist in the database.");

            return clientEntity;
        }

        public async Task<ServiceRequest> TryGetRequestForClientAsync(Guid clientId, Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestForClientAsync(clientId, id);
            if (requestEntity == null)
            {
                throw new EntityNotFoundException($"Service request with id: {id} doesn't exist in the database.");
            }

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
            await TryGetClientEntityByIdAsync(clientId);

            var requestEntities = await _requestRepository.GetAllServiceRequestsForClientAsync(clientId);

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> GetRequestForClientAsync(Guid clientId, Guid id)
        {
            await TryGetClientEntityByIdAsync(clientId);

            var requestEntity = await TryGetRequestForClientAsync(clientId, id);
        
            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task DeleteRequestForClientAsync(Guid clientId, Guid id)
        {
            await TryGetClientEntityByIdAsync(clientId);

            var requestEntity = await TryGetRequestForClientAsync(clientId, id);
            if (requestEntity.RequestStatus != RequestStatus.Recived)
            {
                throw new ForbiddenActionException($"Unnable to delete service request with a status not equal RequestStatus.Recived");
            }

            await _requestRepository.DeleteServiceRequestAsync(requestEntity);
        }

        public async Task<ServiceRequestModel> CreateRequestForClientAsyn(Guid clientId, ServiceRequestForCreationModel requestForCreationModel)
        {
            await TryGetClientEntityByIdAsync(clientId);

            await _donesService.TryGetDroneEntityByIdAsync(requestForCreationModel.DroneId);

            requestForCreationModel.ClientId = clientId;
            var requestEntity = _mapper.Map<ServiceRequest>(requestForCreationModel);
            await _requestRepository.CreateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }
    }
}
