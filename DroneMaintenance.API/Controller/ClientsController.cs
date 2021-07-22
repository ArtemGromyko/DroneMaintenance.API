using DroneMaintenance.API.Contracts;
using DroneMaintenance.Models.RequestModels.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controller
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientsAsync()
        {
            var clientModelsResult = await _clientsService.GetClientsAsync();

            return clientModelsResult;
        }

        [HttpGet("{id}", Name = "GetClient")]
        public async Task<IActionResult> GetClientAsync(Guid id)
        {
            var clientModelResult = await _clientsService.GetClientAsync(id);

            return clientModelResult;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClientAsync([FromBody]ClientForCreationModel client)
        {
            var clientModel = await _clientsService.CreateClientAsync(client);

            return CreatedAtRoute("GetClient", new { id = clientModel.Id }, clientModel);
        }
    }
}
