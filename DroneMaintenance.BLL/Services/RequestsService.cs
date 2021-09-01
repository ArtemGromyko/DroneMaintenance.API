using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class RequestsService : IRequestsService
    {
        private readonly IServiceRequestRepository _requestRepository;
        private readonly IMapper _mapper;

        public RequestsService(IServiceRequestRepository requestRepository, IMapper mapper)
        {
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public async Task<ServiceRequest> TryGetRequestByIdAsync(Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(id);
            if(requestEntity == null)
            {
                throw new EntityNotFoundException($"Service request with id: {id} doesn't exist in the database.");
            }

            return requestEntity;
        }

        public async Task<ServiceRequestModel> GetRequestAsync(Guid id)
        {
            var requestEntity = await TryGetRequestByIdAsync(id);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task<ServiceRequestModel> CreateRequestAsync(ServiceRequestForCreationModel requestForCreationModel)
        {
            var requestEntity = _mapper.Map<ServiceRequest>(requestForCreationModel);

            await _requestRepository.CreateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task DeleteRequestAsync(Guid id)
        {
            var requestEntity = await TryGetRequestByIdAsync(id);

            await _requestRepository.DeleteServiceRequestAsync(requestEntity);
        }

        public async Task<List<ServiceRequestModel>> GetRequestsAsync()
        {
            var requestEntities = await _requestRepository.GetAllServiceRequestsAsync();

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> UpdateRequestAsync(Guid id, ServiceRequestForUpdateModel requestForUpdateModel)
        {
            var requestEntity = await TryGetRequestByIdAsync(id);
            _mapper.Map(requestForUpdateModel, requestEntity);

            await _requestRepository.UpdateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

    }
}
