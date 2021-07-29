using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.ResponseModels.Drone;
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

        private ActionResult<DroneModel> ReturnNotFound(Guid id) => NotFound($"Drone with id: {id} doesn't exist in the database.");

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DroneModel>>> GetDronesAsync() =>
            await _dronesService.GetDronesAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<DroneModel>> GetDroneAsync(Guid id)
        {
            var droneModel = await _dronesService.GetDroneByIdAsync(id);
            if(droneModel == null)
            {
                return ReturnNotFound(id);
            }

            return droneModel;
        }

        [HttpPost]
        public async Task<ActionResult<DroneModel>> CreateDroneAsync([FromBody] DroneForCreationModel drone) =>
            await _dronesService.CreateDroneAsync(drone);

        [HttpDelete("{id}")]
        public async Task<ActionResult<DroneModel>> DeleteDroneAsync(Guid id)
        {
            var result = await _dronesService.DeleteDroneAsync(id);
            if(result == null)
            {
                return ReturnNotFound(id);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DroneModel>> UpdateDroneAsync(Guid id, [FromBody]DroneForUpdateModel droneForUpdateModel)
        {
            var droneModel = await _dronesService.UpdateDroneAsync(id, droneForUpdateModel);
            if(droneModel == null)
            {
                return ReturnNotFound(id);
            }

            return droneModel;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DroneModel>> PartiallyUpdateDroneAsync(Guid id, [FromBody]JsonPatchDocument<DroneForUpdateModel> patchDoc)
        {
            var (droneToPatch, droneEntity) = await _dronesService.GetDroneToPatch(id);
            if(droneEntity == null)
            {
                return ReturnNotFound(id);
            }
            patchDoc.ApplyTo(droneToPatch, ModelState);
            TryValidateModel(droneToPatch);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var droneModel = await _dronesService.UpdateDroneAsync(droneEntity, droneToPatch);

            return droneModel;
        }
    }
}
