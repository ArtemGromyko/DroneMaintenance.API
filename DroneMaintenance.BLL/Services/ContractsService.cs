using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.BLL.Exceptions;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.DTO;
using DroneMaintenance.Models.RequestModels.Contract;
using DroneMaintenance.Models.RequestModels.ContractSparePart;
using DroneMaintenance.Models.ResponseModels.Contract;
using DroneMaintenance.Models.ResponseModels.ContractSparePart;
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
        private readonly ISparePartRepository _partRepository;
        private readonly ISparePartsService _partsService;
        private readonly IOrderSparePartService _orderSparePartService;

        public ContractsService(IContractRepository contractRepository, IServiceRequestRepository requestRepository, IMapper mapper,
        IContractSparePartRepository contractPartRepository, ISparePartsService partsService, 
        ISparePartRepository partRepository, IOrderSparePartService orderSparePartService)
        {
            _contractRepository = contractRepository;
            _requestRepository = requestRepository;
            _mapper = mapper;
            _contractPartRepository = contractPartRepository;
            _partsService = partsService;
            _partRepository = partRepository;
            _orderSparePartService = orderSparePartService;
        }

        public async Task<ContractSparePart> TryGetContractSparePartByIdAsync(Guid contractId, Guid partId)
        {
            var conntractPartEntity = await _contractPartRepository.GetContractSparePartByContractIdAndPartId(contractId, partId);
            CheckEntityExistence(contractId, partId, conntractPartEntity, nameof(ContractSparePart));

            return conntractPartEntity;
        }       

        public async Task SetWorkInProgressStatus(ServiceRequest request)
        {
            if(request.RequestStatus != RequestStatus.WorkInProgress)
            {
                request.RequestStatus = RequestStatus.WorkInProgress;
                await _requestRepository.UpdateServiceRequestAsync(request);
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
            if (requestEntity.RequestStatus == RequestStatus.WorkFinished)
            {
                throw new ForbiddenActionException("Unnable to create a contract for the request " +
                    "with staus equal \"Work Finished\"");
            }

            await SetWorkInProgressStatus(requestEntity);

            var contrctEntity = _mapper.Map<Contract>(contractForCreationModel);
            await _contractRepository.CreateContractAsync(contrctEntity);

            return _mapper.Map<ContractModel>(contrctEntity);
        }

        public async Task DeleteContractAsync(Guid id)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);

            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractEntity.ServiceRequestId);
            CheckEntityExistence(requestEntity.Id, requestEntity, nameof(ServiceRequest));
            if (requestEntity.RequestStatus != RequestStatus.WorkFinished)
            {
                throw new ForbiddenActionException("Unable to delete contract for request with status not equal to \"Work finished\"");
            }

            await _contractRepository.DeleteContractAsync(contractEntity);

            var contract = await _contractRepository.CheckContractExistenceForRequestAsync(contractEntity.ServiceRequestId);
            if (contract == null && requestEntity.RequestStatus != RequestStatus.WorkFinished)
            {
                requestEntity.RequestStatus = RequestStatus.WorkFinished;
                await _requestRepository.UpdateServiceRequestAsync(requestEntity);
            }
        }

        public async Task<ContractModel> UpdateContractAsync(Guid id, ContractForUpdateModel contractForUpdateModel)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(id);

            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractEntity.ServiceRequestId);
            CheckEntityExistence(contractEntity.ServiceRequestId, requestEntity, nameof(ServiceRequest));
            if(requestEntity.RequestStatus == RequestStatus.WorkFinished)
            {
                throw new ForbiddenActionException("Unable to update contract for request with status equal to \"Work finished\"");
            }    

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

        public async Task AddSparePartForContractAsync(Guid contractId, 
        ContractSparePartForCreationModel contractPartForCreationModel)
        {
            var contractEntity = await TryGetContractEntityByIdAsync(contractId);
            var sparePartEntity = await _partsService.TryGetSparePartEntityByIdAsync(contractPartForCreationModel.SparePartId);
            var requestEntity = await _requestRepository.GetServiceRequestByIdAsync(contractEntity.ServiceRequestId);
            CheckEntityExistence(contractEntity.ServiceRequestId, requestEntity, nameof(ServiceRequest));

            var contractSparePartEntity = await _contractPartRepository
                .GetContractSparePartByContractIdAndPartId(contractId, contractPartForCreationModel.SparePartId);

            if(contractSparePartEntity != null)
            {
                throw new ForbiddenActionException("Unnable to add an already added spare part.");
            }

            contractPartForCreationModel.ContractId = contractId;
            var contractPartEntity = _mapper.Map<ContractSparePart>(contractPartForCreationModel);
            await _contractPartRepository.CreateContractSparePartAsync(contractPartEntity);

            var sparePartDto = _mapper.Map<SparePartDto>(sparePartEntity);
            _orderSparePartService.PostSparePartOrder(sparePartDto);

            requestEntity.RequestStatus = RequestStatus.SparePartsOnTheWay;
            await _requestRepository.UpdateServiceRequestAsync(requestEntity);
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
            contractPartForUpdateModel.ContractId = contractId;
            contractPartForUpdateModel.SparePartId = partId;

            var contractPartEntity = await TryGetContractSparePartByIdAsync(contractId, partId);
            _mapper.Map(contractPartForUpdateModel, contractPartEntity);

            await _contractPartRepository.UpdateContractSparePartAsync(contractPartEntity);

            return _mapper.Map<ContractSparePartModel>(contractPartEntity);
        }
    }
}
