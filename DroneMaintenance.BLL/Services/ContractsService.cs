using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Contract;
using DroneMaintenance.Models.ResponseModels.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class ContractsService : ServiceBase, IContractsService
    {
        private readonly IMapper _mapper;
        private readonly IContractRepository _contractRepository;
        private readonly IServiceRequestRepository _requestRepository;

        public ContractsService(IContractRepository contractRepository, IServiceRequestRepository requestRepository, IMapper mapper)
        {
            _contractRepository = contractRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
        }

        public void CheckRequestStatus(RequestStatus status)
        {
            if (status == RequestStatus.WorkFinished)
            {
                throw new ForbiddenActionException("Unnable to create a contract for the request " +
                    "with staus equal RequestStatus.WorkFinished");
            }
        }

        public void SetWorkInProgressStatus(ServiceRequest request)
        {
            if(request.RequestStatus != RequestStatus.WorkInProgress)
            {
                request.RequestStatus = RequestStatus.WorkInProgress;
            }
        }

        public async Task<Contract> TryGetContractEntityByIdAsync(Guid id)
        {
            var contractEntity = await _contractRepository.GetContractByIdAsync(id);
            CheckEntityExistence(id, contractEntity, nameof(Contract));

            return contractEntity;
        }

        public async Task<List<ContractModel>> GetContractsAsync()
        {
            var contractEntities = await _contractRepository.GetAllContractsAsync();

            return _mapper.Map<List<ContractModel>>(contractEntities);
        }

        public async Task<ContractModel> GetContractAsync(Guid id)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);

            return _mapper.Map<ContractModel>(contractEntity);
        }
        public async Task<ContractModel> CreateContractAsync(ContractForCreationModel contractForCreationModel)
        {
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractForCreationModel.ServiceRequestId);
            CheckEntityExistence(requestEntity.Id, requestEntity, nameof(ServiceRequest));
            CheckRequestStatus(requestEntity.RequestStatus);
            SetWorkInProgressStatus(requestEntity);

            var contrctEntity = _mapper.Map<Contract>(contractForCreationModel);

            return _mapper.Map<ContractModel>(contrctEntity);
        }

        public async Task DeleteContractAsync(Guid id)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);

            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractEntity.ServiceRequestId);
            CheckEntityExistence(requestEntity.Id, requestEntity, nameof(ServiceRequest));
            CheckRequestStatus(requestEntity.RequestStatus);
            requestEntity.RequestStatus = RequestStatus.WorkFinished;

            await _contractRepository.DeleteContractAsync(contractEntity);
        }

        public async Task<ContractModel> UpdateContractAsync(Guid id, ContractForUpdateModel contractForUpdateModel)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);
            _mapper.Map(contractForUpdateModel, contractEntity);

            await _contractRepository.UpdateContractAsync(contractEntity);

            return _mapper.Map<ContractModel>(contractEntity);
        }
    }
}
