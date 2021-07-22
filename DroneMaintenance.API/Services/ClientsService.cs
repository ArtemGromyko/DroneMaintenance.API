using AutoMapper;
using DroneMaintenance.API.Contracts;
using DroneMaintenance.API.Filters.ActionFilters;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Services
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

        public async Task<IActionResult> GetClientsAsync()
        {
            var clientEntities = await  _clientRepository.GetAllClientsAsync();

            var clientsModels = _mapper.Map<List<ClientModel>>(clientEntities);

            return new OkObjectResult(clientsModels);
        }

        public async Task<IActionResult> GetClientAsync(Guid id)
        {
            var clientEntity = await _clientRepository.GetClientAsync(id);
            if (clientEntity == null)
            {
                _logger.LogInfo($"Client with id: {id} doesn't exists in the database.");
                return new NotFoundObjectResult(clientEntity);
            }

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return new OkObjectResult(clientModel);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ClientModel> CreateClientAsync(ClientForCreationModel client)
        {
            var clientEntity = _mapper.Map<Client>(client);

            await _clientRepository.CreateClientAsync(clientEntity);

            var clientModel = _mapper.Map<ClientModel>(clientEntity);

            return clientModel;
        }
    }
}
