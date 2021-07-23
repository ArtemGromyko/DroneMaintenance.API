using DroneMaintenance.API.Filters.ActionFilters;
using DroneMaintenance.BLL.Contracts;
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
            var clientModels = await _clientsService.GetClientsAsync();

            return Ok(clientModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientAsync(Guid id)
        {
            var clientModel = await _clientsService.GetClientAsync(id);

            return Ok(clientModel);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateClientAsync([FromBody] ClientForCreationModel client)
        {
            var clientModel = await _clientsService.CreateClientAsync(client);

            return Created("api/clients/"+clientModel.Id, clientModel);
        }
    }
}
