using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientsService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        public async Task<Client> TryGetClientEntityByIdAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientAsync(id);
            if(clientEntity == null)
            {
                throw new EntityNotFoundException($"Client with id: {id} doesn't exist in the database.");
            }

            return clientEntity;
        }

        public async Task<List<ClientModel>> GetClientsAsync()
        {
            List<Client> clientEntities = await _clientRepository.GetAllClientsAsync();

            var clientModels = _mapper.Map<List<ClientModel>>(clientEntities);

            return clientModels;
        }

        public async Task<ClientModel> GetClientAsync(Guid id)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

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

        public async Task DeleteClientAsync(Guid id)
        {
            var clientEntity = await TryGetClientEntityByIdAsync(id);

            await _clientRepository.DeleteClientAsync(clientEntity);
        }

        public async Task UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel)
        {
            _mapper.Map(clientForUpdateModel, clientEntity);

            await _clientRepository.UpdateClientAsync(clientEntity);
        }

        public ClientForUpdateModel GetClientToPatch(Client clientEntity)
        {
            var reviewToPatch = _mapper.Map<ClientForUpdateModel>(clientEntity);

            return reviewToPatch;
        }
    }
}
