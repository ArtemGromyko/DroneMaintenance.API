using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.SparePart;
using DroneMaintenance.Models.ResponseModels.SparePart;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/parts")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        private readonly ISparePartsService _partsService;

        public SparePartsController(ISparePartsService partsService)
        {
            _partsService = partsService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartModel>>> GetSparePartsAsync() =>
           await _partsService.GetSparePartsAsync();

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartModel>> GetSparePartAsync(Guid id)
        {
            var partModel = await _partsService.GetSparePartAsync(id);

            return partModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<SparePartModel>> CreateSparePartAsync([FromBody] SparePartForCreationModel part)
        {
            var partModel = await _partsService.CreateSparePartAsync(part);

            return Created("api/contracts/" + partModel.Id, partModel);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartModel>> DeleteSparePartAsync(Guid id)
        {
            await _partsService.DeleteSparePartAsync(id);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<SparePartModel>> UpdateSparePartAsync(Guid id, [FromBody]SparePartForUpdateModel partForUpdateModel)
        {
            var partModel = await _partsService.UpdateSparePartAsync(id, partForUpdateModel);

            return partModel;
        }
    }
}
