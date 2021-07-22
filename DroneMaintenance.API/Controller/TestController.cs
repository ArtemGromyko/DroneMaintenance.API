using AutoMapper;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controller
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMapper _mapper;
        
        public TestController(IClientRepository clientRepository, IMapper mapper, IServiceRequestRepository serviceRequestRepository)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
        }

        [HttpGet]
        public async  Task<IActionResult> GetPersons()
        {
            var serviceRequests = await _serviceRequestRepository.GetAllServiceRequestsAsync();
            var serviceRequestModels = _mapper.Map<IEnumerable<ServiceRequestModel>>(serviceRequests);

            return Ok(serviceRequestModels);
        }
    }
}
