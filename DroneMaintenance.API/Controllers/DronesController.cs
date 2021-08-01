using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/drones")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly IDronesService _dronesService;

        public DronesController(IDronesService dronesService)
        {
            _dronesService = dronesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DroneModel>>> GetDronesAsync() =>
            await _dronesService.GetDronesAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<DroneModel>> GetDroneAsync(Guid id)
        {
            var droneModel = await _dronesService.GetDroneAsync(id);

            return droneModel;
        }

        [HttpPost]
        public async Task<ActionResult<DroneModel>> CreateDroneAsync([FromBody] DroneForCreationModel drone)
        {
            var droneModel = await _dronesService.CreateDroneAsync(drone);

            return Created("api/drones/" + droneModel.Id, droneModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DroneModel>> DeleteDroneAsync(Guid id)
        {
            await _dronesService.DeleteDroneAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DroneModel>> UpdateDroneAsync(Guid id, [FromBody]DroneForUpdateModel droneForUpdateModel)
        {
            var droneModel = await _dronesService.UpdateDroneAsync(id, droneForUpdateModel);

            return droneModel;
        }

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

        [HttpGet("{droneId}/requests")]
        public async Task<ActionResult<IEnumerable<ServiceRequestModel>>> GetRequestsForDroneAsync(Guid droneId)
        {
            var requestModels = await _dronesService.GetRequestsForDroneAsync(droneId);

            return requestModels;
        }

        [HttpGet("{droneId}/requests/{id}")]
        public async Task<ActionResult<ServiceRequestModel>> GetRequestForModelAsync(Guid droneId, Guid id)
        {
            var requestModel = await _dronesService.GetRequestsForDroneAsync(droneId, id);

            return requestModel; 
        }
    }
}
