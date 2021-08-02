using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Contract;
using DroneMaintenance.Models.RequestModels.ContractSparePart;
using DroneMaintenance.Models.ResponseModels.Contract;
using DroneMaintenance.Models.ResponseModels.ContractSparePart;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/contracts")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly IContractsService _contractsService;

        public ContractsController(IContractsService contractsService)
        {
            _contractsService = contractsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContractModel>>> GetContractsAsync() =>
           await _contractsService.GetContractsAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ContractModel>> GetContractAsync(Guid id)
        {
            var contractModel = await _contractsService.GetContractAsync(id);

            return contractModel;
        }

        [HttpPost]
        public async Task<ActionResult<ContractModel>> CreateContractAsync([FromBody]ContractForCreationModel contract)
        {
            var contractModel = await _contractsService.CreateContractAsync(contract);

            return Created("api/contracts/" + contractModel.Id, contractModel);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContractModel>> DeleteContractAsync(Guid id)
        {
            await _contractsService.DeleteContractAsync(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ContractModel>> UpdateContractAsync(Guid id, [FromBody] ContractForUpdateModel contractForUpdateModel)
        {
            var contractModel = await _contractsService.UpdateContractAsync(id, contractForUpdateModel);

            return contractModel;
        }

        [HttpGet("{contractId}/parts")]
        public async Task<ActionResult<IEnumerable<ContractSparePartModel>>> GetPartsForContractAsync(Guid contractId)
        {
            var contractPartModels = await _contractsService.GetSparePartsForContractAsync(contractId);

            return contractPartModels;
        }

        [HttpGet("{contractId}/parts/{partId}")]
        public async Task<ActionResult<ContractSparePartModel>> GetPartsForContractAsync(Guid contractId, Guid partId)
        {
            var contractPartModel = await _contractsService.GetSparePartForContractAsync(contractId, partId);

            return contractPartModel;
        }

        [HttpPost("{contractId}/parts")]
        public async Task<ActionResult<ContractSparePartModel>> AddPartForContractAsync(Guid contractId, 
        [FromBody]ContractSparePartForCreationModel contractPartForUpdateModel)
        {
            var contractPartModel = await _contractsService.CreateSparePartForContractAsync(contractId, contractPartForUpdateModel);

            return contractPartModel;
        }

        [HttpPut("{contractId}/parts/{partId}")]
        public async Task<ActionResult<ContractSparePartModel>> UpdatePartForContractAsync(Guid contractId, Guid partId,
        [FromBody]ContractSparePartForUpdateModel contractPartForUpdateModel)
        {
            var contractPartModel = await _contractsService.UpdateSparePartForContractAsync(contractId, partId, contractPartForUpdateModel);

            return contractPartModel;
        }

        [HttpDelete("{contractId}/parts/{partId}")]
        public async Task<ActionResult<ContractSparePartModel>> UpdatePartForContractAsync(Guid contractId, Guid partId)
        {
            await _contractsService.DeleteSparePartForContractAsync(contractId, partId);

            return NoContent();
        }
    }
}
