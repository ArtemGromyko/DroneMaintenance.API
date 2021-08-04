using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/drones")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IDronesService _dronesService;

        public DronesController(IDronesService dronesService)
        {
            _dronesService = dronesService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DroneModel>>> GetDronesAsync() =>
            await _dronesService.GetDronesAsync();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<DroneModel>> GetDroneAsync(Guid id)
        {
            var droneModel = await _dronesService.GetDroneAsync(id);

            return droneModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<DroneModel>> CreateDroneAsync([FromBody]DroneForCreationModel drone)
        {
            var droneModel = await _dronesService.CreateDroneAsync(drone);

            return Created("api/drones/" + droneModel.Id, droneModel);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<DroneModel>> DeleteDroneAsync(Guid id)
        {
            await _dronesService.DeleteDroneAsync(id);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<DroneModel>> UpdateDroneAsync(Guid id, [FromBody]DroneForUpdateModel droneForUpdateModel)
        {
            var droneModel = await _dronesService.UpdateDroneAsync(id, droneForUpdateModel);

            return droneModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPatch("{id}")]
        public async Task<ActionResult<DroneModel>> PartiallyUpdateDroneAsync(Guid id, [FromBody]JsonPatchDocument<DroneForUpdateModel> patchDoc)
        {
            var (droneToPatch, droneEntity) = await _dronesService.GetDroneToPatch(id);

            patchDoc.ApplyTo(droneToPatch, ModelState);
            TryValidateModel(droneToPatch);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var droneModel = await _dronesService.UpdateDroneAsync(droneEntity, droneToPatch);

            return droneModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{droneId}/requests")]
        public async Task<ActionResult<IEnumerable<ServiceRequestModel>>> GetRequestsForDroneAsync(Guid droneId)
        {
            var requestModels = await _dronesService.GetRequestsForDroneAsync(droneId);

            return requestModels;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{droneId}/requests/{id}")]
        public async Task<ActionResult<ServiceRequestModel>> GetRequestForModelAsync(Guid droneId, Guid id)
        {
            var requestModel = await _dronesService.GetRequestsForDroneAsync(droneId, id);

            return requestModel; 
        }
    }
}
