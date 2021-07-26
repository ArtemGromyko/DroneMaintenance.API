using DroneMaintenance.API.Filters.ActionFilters;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Client;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;
        private readonly ILoggerManager _logger;

        public ClientsController(IClientsService clientsService, ILoggerManager logger)
        {
            _clientsService = clientsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientsAsync()
        {
            var clientModels = await _clientsService.GetClientsAsync();

            return Ok(clientModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            var clientModel = await _clientsService.GetClientAsync(id);

            return Ok(clientModel);
        }

        [HttpPost]
        [ServiceFilter(typeof(NullArgumentFilterAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateClientAsync([FromBody]ClientForCreationModel client)
        {
            var clientModel = await _clientsService.CreateClientAsync(client);

            return Created("api/clients/"+clientModel.Id, clientModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientAsync(Guid id)
        {
            await _clientsService.DeleteClientAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NullArgumentFilterAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePersonAsync(Guid id, [FromBody]ClientForUpdateModel client)
        {
            var clientEntity = await _clientsService.TryGetClientEntityByIdAsync(id);

            await _clientsService.UpdateClientAsync(clientEntity, client);

            return NoContent();
        }

        [HttpPatch("{id}")]
        [ServiceFilter(typeof(NullArgumentFilterAttribute))]
        public async Task<IActionResult> PartiallyUpdateClientAsync(Guid id, [FromBody]JsonPatchDocument<ClientForUpdateModel> patchDoc)
        {
            var clientEntity = await _clientsService.TryGetClientEntityByIdAsync(id);
            var clientToPatch = _clientsService.GetClientToPatch(clientEntity);

            patchDoc.ApplyTo(clientToPatch, ModelState);
            TryValidateModel(clientToPatch);
            if(!ModelState.IsValid)
            {
                _logger.LogError($"Invalid model state for the patch document. Controller: {HttpContext.GetRouteValue("controller")} " +
                    $"action: {HttpContext.GetRouteValue("action")}");
                return BadRequest(ModelState);
            }

            await _clientsService.UpdateClientAsync(clientEntity, clientToPatch);

            return NoContent();
        }
    }
}
