using DroneMaintenance.API.Filters.ActionFilters;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientsController(IClientsService clientsService, ILoggerManager logger)
        {
            _clientsService = clientsService;
        }

        /// <summary>
        /// Gets a client list
        /// </summary>
        /// <response code="200">The client list recived successfully</response>
        /// <response code="500">Internal server error</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientsAsync()
        {
            var clientModels = await _clientsService.GetClientsAsync();

            return Ok(clientModels);
        }

        /// <summary>
        /// Gets a client by provided id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <response code="200">The client recived successfully</response>
        /// <response code="404">The client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientByIdAsync(Guid id)
        {
            var clientModel = await _clientsService.GetClientAsync(id);

            return Ok(clientModel);
        }

        /// <summary>
        /// Creates new client
        /// </summary>
        /// <param name="client">The client request model for creation</param>
        /// <response code="201">The client created successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateClientAsync([FromBody]ClientForCreationModel client)
        {
            var clientModel = await _clientsService.CreateClientAsync(client);

            return Created("api/clients/"+clientModel.Id, clientModel);
        }

        /// <summary>
        /// Deletes a client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <response code="204">The client deleted successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">The client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClientAsync(Guid id)
        {
            await _clientsService.DeleteClientAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Updates a client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <param name="client">Client request model for update</param>
        /// <response code="204">Client updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [HttpPut("{id}")]
        [ServiceFilter(typeof(NullArgumentFilterAttribute))]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdatePersonAsync(Guid id, [FromBody]ClientForUpdateModel client)
        {
            var clientEntity = await _clientsService.TryGetClientEntityByIdAsync(id);

            await _clientsService.UpdateClientAsync(clientEntity, client);

            return NoContent();
        }

        /// <summary>
        /// Partially updates client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <param name="patchDoc"></param>
        /// <response code="204">The client updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">The client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateClientAsync(Guid id, [FromBody]JsonPatchDocument<ClientForUpdateModel> patchDoc)
        {
            var clientEntity = await _clientsService.TryGetClientEntityByIdAsync(id);
            var clientToPatch = _clientsService.GetClientToPatch(clientEntity);

            patchDoc.ApplyTo(clientToPatch, ModelState);
            TryValidateModel(clientToPatch);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientsService.UpdateClientAsync(clientEntity, clientToPatch);

            return NoContent();
        }
    }
}
