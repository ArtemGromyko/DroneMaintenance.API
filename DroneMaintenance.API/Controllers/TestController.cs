using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;
        private readonly IServiceRequestRepository _serviceRequestRepository;
        private readonly IMapper _mapper;
        private readonly IClientsService _clientsService;

        public TestController(IClientRepository clientRepository, IMapper mapper, IServiceRequestRepository serviceRequestRepository, IClientsService clientsService)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _serviceRequestRepository = serviceRequestRepository;
            _clientsService = clientsService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var clientModels = await _clientsService.GetClientsAsync();

            return Ok(clientModels);
        }
    }
}
