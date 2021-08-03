using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientModel>>> GetClientsAsync() =>
            await _clientsService.GetClientsAsync();

        /// <summary>
        /// Gets a client by provided id
        /// </summary>
        /// <param name="id">Client id</param>
        /// <response code="200">The client recived successfully</response>
        /// <response code="404">The client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientModel>> GetClientAsync(Guid id)
        {
            var clientModel = await _clientsService.GetClientAsync(id);

            return clientModel;
        }

        /// <summary>
        /// Creates new client
        /// </summary>
        /// <param name="client">The client request model for creation</param>
        /// <response code="201">The client created successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ClientModel>> CreateClientAsync([FromBody] ClientForCreationModel client)
        {
            var clientModel = await _clientsService.CreateClientAsync(client);

            return Created("api/clients/" + clientModel.Id, clientModel);
        }

        /// <summary>
        /// Deletes a client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <response code="204">The client deleted successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">The client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ClientModel>> DeleteClientAsync(Guid id)
        {
            await _clientsService.DeleteClientAsync(id);

            return NoContent();
        }

        /// <summary>
        /// Updates a client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <param name="client">Client request model for update</param>
        /// <response code="200">Client updated successfully</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Client with provided id doesn't exist in the database</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ClientModel>> UpdatePersonAsync(Guid id, [FromBody] ClientForUpdateModel client)
        {
            var clientModel = await _clientsService.UpdateClientAsync(id, client);

            return clientModel;
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> PartiallyUpdateClientAsync(Guid id, [FromBody] JsonPatchDocument<ClientForUpdateModel> patchDoc)
        {
            var (clientToPatch, clientEntity) = await _clientsService.GetClientToPatch(id);

            patchDoc.ApplyTo(clientToPatch, ModelState);
            TryValidateModel(clientToPatch);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _clientsService.UpdateClientAsync(clientEntity, clientToPatch);

            return NoContent();
        }

        [HttpGet("{clientId}/requests")]
        public async Task<ActionResult<IEnumerable<ServiceRequestModel>>> GetRequestsForClientAsync(Guid clientId) =>
            await _clientsService.GetRequestsForClientAsync(clientId);

        [HttpGet("{clientId}/requests/{id}")]
        public async Task<ActionResult<ServiceRequestModel>> GetRequestForClientAsync(Guid clientId, Guid id)
        {
            var requestModel = await _clientsService.GetRequestForClientAsync(clientId, id);

            return requestModel;
        }

        [HttpPost("{clientId}/requests")]
        public async Task<ActionResult<ServiceRequestModel>> CreateRequestForClientAsync(Guid clientId, 
        [FromBody]ServiceRequestForCreationModel request)
        {
            var requestModel = await _clientsService.CreateRequestForClientAsyn(clientId, request);

            return requestModel;
        }

        [HttpPut("{clientId}/requests/{id}")]
        public async Task<ActionResult<ServiceRequestModel>> UpdateRequestForClientAsync(Guid clientId, Guid id, 
        [FromBody]ServiceRequestForUpdateModel request)
        {
            var requestModel = await _clientsService.UpdateRequestForClientAsync(clientId, id, request);

            return requestModel;
        }

        [HttpDelete("{clientId}/requests/{id}")]
        public async Task<ActionResult<ServiceRequestModel>> DeleteRequestForClientAsync(Guid clientId, Guid id)
        {
            await _clientsService.DeleteRequestForClientAsync(clientId, id);

            return NoContent();
        }
    }
}
