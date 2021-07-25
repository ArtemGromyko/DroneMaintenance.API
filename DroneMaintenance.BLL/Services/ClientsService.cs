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
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;

        public ClientsService(ILoggerManager logger, IMapper mapper, IClientRepository clientRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _clientRepository = clientRepository;
        }

        private async Task<Client> TryGetClientByIdAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientAsync(id);
            if(clientEntity == null)
            {
                string message = $"Client with id: {id} doesn't exist in the database.";
                _logger.LogInfo(message);
                throw new EntityNotFoundException(message);
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
            var clientEntity = await TryGetClientByIdAsync(id);

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }

        public async Task<ClientModel> CreateClientAsync(ClientForCreationModel client)
        {
            var clientEntity = _mapper.Map<Client>(client);

            await _clientRepository.CreateClientAsync(clientEntity);

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }
    }
}
