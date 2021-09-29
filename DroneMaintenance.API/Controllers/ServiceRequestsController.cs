using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using DroneMaintenance.BLL.Contracts;
using System.Collections.Generic;
using System;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace ServiceRequestMaintenance.API.Controllers
{
    [Authorize]
    [Route("api/requests")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IRequestsService _requestsService;

        public ServiceRequestsController(IRequestsService requestsService)
        {
            _requestsService = requestsService;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequestModel>>> GetServiceRequestsAsync()
        {
            await _requestsService.GetRequestsAsync();

            return StatusCode(500);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> GetServiceRequestAsync(Guid id)
        {
            var requestModel = await _requestsService.GetRequestAsync(id);

            return requestModel;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<ActionResult<ServiceRequestModel>> CreateServiceRequestAsync([FromBody] ServiceRequestForCreationModel request)
        {
            var requestModel = await _requestsService.CreateRequestAsync(request);

            return Created("api/requests/" + requestModel.Id, requestModel);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> DeleteServiceRequestAsync(Guid id)
        {
            await _requestsService.DeleteRequestAsync(id);

            return NoContent();
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> UpdateServiceRequestAsync(Guid id, 
        [FromBody]ServiceRequestForUpdateModel requestForUpdateModel)
        {
            var requestModel = await _requestsService.UpdateRequestAsync(id, requestForUpdateModel);

            return requestModel;
        }
    }
}
