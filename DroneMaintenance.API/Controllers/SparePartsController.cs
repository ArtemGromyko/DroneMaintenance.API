using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.SparePart;
using DroneMaintenance.Models.ResponseModels.SparePart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/parts")]
    [ApiController]
    public class SparePartsController : ControllerBase
    {
        private readonly ISparePartsService _partsService;

        public SparePartsController(ISparePartsService partsService)
        {
            _partsService = partsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SparePartModel>>> GetSparePartsAsync() =>
           await _partsService.GetSparePartsAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<SparePartModel>> GetSparePartAsync(Guid id)
        {
            var partModel = await _partsService.GetSparePartAsync(id);

            return partModel;
        }

        [HttpPost]
        public async Task<ActionResult<SparePartModel>> CreateSparePartAsync([FromBody] SparePartForCreationModel part)
        {
            var partModel = await _partsService.CreateSparePartAsync(part);

            return Created("api/contracts/" + partModel.Id, partModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<SparePartModel>> DeleteSparePartAsync(Guid id)
        {
            await _partsService.DeleteSparePartAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SparePartModel>> UpdateSparePartAsync(Guid id, [FromBody]SparePartForUpdateModel partForUpdateModel)
        {
            var partModel = await _partsService.UpdateSparePartAsync(id, partForUpdateModel);

            return partModel;
        }
    }
}
