using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using DroneMaintenance.BLL.Contracts;
using System.Collections.Generic;
using System;
using DroneMaintenance.Models.RequestModels.ServiceRequest;

namespace ServiceRequestMaintenance.API.Controllers
{
    [Route("api/requests")]
    [ApiController]
    public class ServiceRequestsController : ControllerBase
    {
        private readonly IRequestsService _requestsService;

        public ServiceRequestsController(IRequestsService requestsService)
        {
            _requestsService = requestsService;
        }

         private ActionResult<ServiceRequestModel> ReturnNotFound(Guid id) => NotFound($"ServiceRequest with id: {id} doesn't exist in the database.");

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceRequestModel>>> GetServiceRequestsAsync() =>
            await _requestsService.GetRequestsAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> GetServiceRequestAsync(Guid id)
        {
            var requestModel = await _requestsService.GetRequestByIdAsync(id);
            if(requestModel == null)
            {
                return ReturnNotFound(id);
            }

            return requestModel;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceRequestModel>> CreateServiceRequestAsync([FromBody] ServiceRequestForCreationModel request) =>
            await _requestsService.CreateRequestAsync(request);

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> DeleteServiceRequestAsync(Guid id)
        {
            var result = await _requestsService.DeleteRequestAsync(id);
            if(result == null)
            {
                return ReturnNotFound(id);
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceRequestModel>> UpdateServiceRequestAsync(Guid id, [FromBody]ServiceRequestForUpdateModel requestForUpdateModel)
        {
            var requestModel = await _requestsService.UpdateRequestAsync(id, requestForUpdateModel);
            if(requestModel == null)
            {
                return ReturnNotFound(id);
            }

            return requestModel;
        }
    }
}
