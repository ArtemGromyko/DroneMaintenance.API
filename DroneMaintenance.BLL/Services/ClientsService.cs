using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
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

        public ClientsService(IMapper mapper, IClientRepository clientRepository, IServiceRequestRepository requestRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
            _requestRepository = requestRepository;
        }

        public async Task<Client> GetClientEntityByIdAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientByIdAsync(id);

            return clientEntity;
        }

        public async Task<List<ClientModel>> GetClientsAsync()
        {
            var clientEntities = await _clientRepository.GetAllClientsAsync();

            var clientModels = _mapper.Map<List<ClientModel>>(clientEntities);

            return clientModels;
        }

        public async Task<ClientModel> GetClientByIdAsync(Guid id)
        {
            var clientEntity = await GetClientEntityByIdAsync(id);
            if (clientEntity == null)
            {
                return null;
            }

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }

        public async Task<ClientModel> CreateClientAsync(ClientForCreationModel clientForCreationModel)
        {
            var clientEntity = _mapper.Map<Client>(clientForCreationModel);

            await _clientRepository.CreateClientAsync(clientEntity);

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }

        public async Task DeleteClientAsync(Client clientEntity)
        {
            await _clientRepository.DeleteClientAsync(clientEntity);
        }

        public async Task<ClientModel> UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel)
        {
            _mapper.Map(clientForUpdateModel, clientEntity);

            await _clientRepository.UpdateClientAsync(clientEntity);

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }

        public ClientForUpdateModel GetClientToPatch(Client clientEntity)
        {
            var reviewToPatch = _mapper.Map<ClientForUpdateModel>(clientEntity);

            return reviewToPatch;
        }

        public async Task<List<ServiceRequestModel>> GetRequestsForClientAsync(Guid clientId)
        { 
            var requestEntities = await _requestRepository.GetAllServiceRequestsForClientAsync(clientId);

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> GetServiceRequestForClient(Guid clientId, Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestForClientAsync(clientId, id);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }
    }
}
