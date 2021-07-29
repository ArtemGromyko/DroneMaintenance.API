using AutoMapper;
using DroneMaintenance.BLL.Contracts;
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

        public async Task<ServiceRequestModel> GetRequestByIdAsync(Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(id);

            return requestEntity == null ? null : _mapper.Map<ServiceRequestModel>(requestEntity);
        }
        public async Task<ServiceRequestModel> CreateRequestAsync(ServiceRequestForCreationModel requestForCreationModel)
        {
            var requestEntity = _mapper.Map<ServiceRequest>(requestForCreationModel);

            await _requestRepository.CreateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public async Task<ServiceRequest> DeleteRequestAsync(Guid id)
        {
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(id);
            if(requestEntity == null)
            {
                return null;
            }

            await _requestRepository.DeleteServiceRequestAsync(requestEntity);

            return requestEntity;
        }

        public Task<(ServiceRequestForUpdateModel requestForUpdateModel, ServiceRequest requestEntity)> GetDroneToPatch(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ServiceRequestModel>> GetRequestsAsync()
        {
            var requestEntities = await _requestRepository.GetAllServiceRequestsAsync();

            return _mapper.Map<List<ServiceRequestModel>>(requestEntities);
        }

        public async Task<ServiceRequestModel> UpdateRequestAsync(Guid id, ServiceRequestForUpdateModel requestForUpdateModel)
        {
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(id);
            if(requestEntity == null)
            {
                return null;
            }

            await _requestRepository.UpdateServiceRequestAsync(requestEntity);

            return _mapper.Map<ServiceRequestModel>(requestEntity);
        }

        public Task<ServiceRequestModel> UpdateRequestAsync(ServiceRequest requestEntity, ServiceRequestForUpdateModel requestForUpdateModel)
        {
            throw new NotImplementedException();
        }
    }
}
