using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.SparePart;
using DroneMaintenance.Models.ResponseModels.SparePart;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class SparePartsService : ServiceBase, ISparePartsService
    {
        private readonly IMapper _mapper;
        private readonly ISparePartRepository _partRepository;

        public SparePartsService(IMapper mapper, ISparePartRepository partRepository)
        {
            _mapper = mapper;
            _partRepository = partRepository;
        }

        public async Task CheckSparePartExistenceAsync(Guid id)
        {
            var partEntity = await _partRepository.GetSparePartByIdAsync(id);
            CheckEntityExistence(id, partEntity, nameof(SparePart));
        }

        public async Task<SparePart> TryGetSparePartEntityByIdAsync(Guid id)
        {
            var partEntity = await _partRepository.GetSparePartByIdAsync(id);
            CheckEntityExistence(id, partEntity, nameof(SparePart));

            return partEntity;
        }

        public async Task<List<SparePartModel>> GetSparePartsAsync()
        {
            var partEntities = await _partRepository.GetAllSparePartsAsync();

            return _mapper.Map<List<SparePartModel>>(partEntities);
        }

        public async Task<SparePartModel> GetSparePartAsync(Guid id)
        {
            var partEntity = await TryGetSparePartEntityByIdAsync(id);

            return _mapper.Map<SparePartModel>(partEntity);
        }

        public async Task<SparePartModel> CreateSparePartAsync(SparePartForCreationModel partForCreationModel)
        {
            var partEntity = _mapper.Map<SparePart>(partForCreationModel);

            await _partRepository.UpdateSparePartAsync(partEntity);

            return _mapper.Map<SparePartModel>(partEntity);
        }

        public async Task DeleteSparePartAsync(Guid id)
        {
            var partEntity = await TryGetSparePartEntityByIdAsync(id);

            await _partRepository.DeleteSparePartAsync(partEntity);
        }

        public async Task<SparePartModel> UpdateSparePartAsync(Guid id, SparePartForUpdateModel partForUpdateModel)
        {
            var partEntity = await TryGetSparePartEntityByIdAsync(id);

            _mapper.Map(partForUpdateModel, partEntity);

            await _partRepository.UpdateSparePartAsync(partEntity);

            return _mapper.Map<SparePartModel>(partEntity);
        }
    }
}
