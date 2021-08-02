using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Contract;
using DroneMaintenance.Models.RequestModels.ContractSparePart;
using DroneMaintenance.Models.ResponseModels.Contract;
using DroneMaintenance.Models.ResponseModels.ContractSparePart;
using DroneMaintenance.Models.ResponseModels.SparePart;
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
        private readonly IContractSparePartRepository _contractPartRepository;
        private readonly ISparePartsService _partsService;

        public ContractsService(IContractRepository contractRepository, IServiceRequestRepository requestRepository, IMapper mapper,
        IContractSparePartRepository contractPartRepository, ISparePartsService partsService)
        {
            _contractRepository = contractRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _contractPartRepository = contractPartRepository;
            _partsService = partsService;
        }

        public async Task<ContractSparePart> TryGetContractSparePartByIdAsync(Guid contractId, Guid partId)
        {
            var conntractPartEntity = await _contractPartRepository.GetContractSparePartByContractIdAndPartId(contractId, partId);
            if(conntractPartEntity == null)
            {
                throw new ForbiddenActionException($"{nameof(ContractSparePart)} with contractId: {contractId} and partId: {partId} doesn't exist in the database.");
            }

            return conntractPartEntity;
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

        public async Task CheckContractExistenceAsync(Guid id)
        {
            var contractEntity = await _contractRepository.GetContractByIdAsync(id);
            CheckEntityExistence(id, contractEntity, nameof(Contract));
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

            await _contractRepository.DeleteContractAsync(contractEntity);

            var contract = await _contractRepository.CheckContractExistenceForRequestAsync(contractEntity.ServiceRequestId);
            if(contract == null && requestEntity.RequestStatus != RequestStatus.WorkFinished)
            {
                requestEntity.RequestStatus = RequestStatus.WorkFinished;
            }
        }

        public async Task<ContractModel> UpdateContractAsync(Guid id, ContractForUpdateModel contractForUpdateModel)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);

            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractEntity.ServiceRequestId);
            CheckEntityExistence(contractEntity.ServiceRequestId, requestEntity, nameof(ServiceRequest));
            CheckRequestStatus(requestEntity.RequestStatus);

            _mapper.Map(contractForUpdateModel, contractEntity);

            await _contractRepository.UpdateContractAsync(contractEntity);

            return _mapper.Map<ContractModel>(contractEntity);
        }

        public async Task<ContractSparePartModel> GetSparePartForContractAsync(Guid contractId, Guid partId)
        {
            await CheckContractExistenceAsync(contractId);
            await _partsService.CheckSparePartExistenceAsync(partId);

            var contractSparePartEntity = await TryGetContractSparePartByIdAsync(contractId, partId);

            return _mapper.Map<ContractSparePartModel>(contractSparePartEntity);
        }

        public async Task<List<ContractSparePartModel>> GetSparePartsForContractAsync(Guid contractId)
        {
            await CheckContractExistenceAsync(contractId);

            var contractSparePartEntities = await _contractPartRepository.GetAllContractSparePartForContract(contractId);

            return _mapper.Map<List<ContractSparePartModel>>(contractSparePartEntities);
        }

        public async Task<ContractSparePartModel> CreateSparePartForContractAsync(Guid contractId, ContractSparePartForCreationModel contractPartForCreationModel)
        {
            await CheckContractExistenceAsync(contractId);
            await _partsService.CheckSparePartExistenceAsync(contractPartForCreationModel.SparePartId);

            var contractSparePartEntity = await _contractPartRepository.GetContractSparePartByContractIdAndPartId(contractId, contractPartForCreationModel.SparePartId);
            if(contractSparePartEntity != null)
            {
                throw new ForbiddenActionException("Unnable to add an already added spare part.");
            }

            var contractPartEntity = _mapper.Map<ContractSparePart>(contractPartForCreationModel);

            await _contractPartRepository.UpdateContractSparePartAsync(contractPartEntity);

            return _mapper.Map<ContractSparePartModel>(contractPartEntity);
        }

        public async Task DeleteSparePartForContractAsync(Guid contractId, Guid partId)
        {
            await CheckContractExistenceAsync(contractId);
            await _partsService.CheckSparePartExistenceAsync(partId);

            var contractPartEntity = await TryGetContractSparePartByIdAsync(contractId, partId);

            await _contractPartRepository.DeleteContractSparePartAsync(contractPartEntity);
        }

        public async Task<ContractSparePartModel> UpdateSparePartForContractAsync(Guid contractId, Guid partId, ContractSparePartForUpdateModel contractPartForUpdateModel)
        {
            await CheckContractExistenceAsync(contractId);
            await _partsService.CheckSparePartExistenceAsync(partId);

            var contractPartEntity = await TryGetContractSparePartByIdAsync(contractId, partId);
            _mapper.Map(contractPartForUpdateModel, contractPartEntity);

            await _contractPartRepository.UpdateContractSparePartAsync(contractPartEntity);

            return _mapper.Map<ContractSparePartModel>(contractPartEntity);
        }
    }
}
