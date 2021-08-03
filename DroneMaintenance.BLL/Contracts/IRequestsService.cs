using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IRequestsService
    {
        Task<ServiceRequest> TryGetRequestByIdAsync(Guid id);
        Task<ServiceRequestModel> GetRequestAsync(Guid id);

        Task<List<ServiceRequestModel>> GetRequestsAsync();

        Task<ServiceRequestModel> CreateRequestAsync(ServiceRequestForCreationModel requestForCreationModel);

        Task DeleteRequestAsync(Guid id);

        Task<ServiceRequestModel> UpdateRequestAsync(Guid id, ServiceRequestForUpdateModel requestForUpdateModel);

        //For PATCH
        //Task<ServiceRequestModel> UpdateRequestAsync(ServiceRequest requestEntity, ServiceRequestForUpdateModel requestForUpdateModel);

        //Task<(ServiceRequestForUpdateModel requestForUpdateModel, ServiceRequest requestEntity)> GetRequestToPatch(Guid id);
    }
}
