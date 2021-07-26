using AutoMapper;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;

namespace DroneMaintenance.BLL.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapsForClient();
        }

        private void CreateMapsForClient()
        {
            CreateMap<ServiceRequest, ServiceRequestModel>()
                .ForMember(srm => srm.RequestStatus, opts => opts.MapFrom(x => GetStatuses(x.RequestStatus)))
                .ForMember(srm => srm.ServiceType, opts => opts.MapFrom(x => GetServiceTypes(x.ServiceType)));
            CreateMap<Client, ClientModel>();

            CreateMap<ClientForCreationModel, Client>();

            CreateMap<ClientForUpdateModel, Client>().ReverseMap();
        }

        private string GetStatuses(RequestStatus request)
        {
            switch(request)
            {
                case RequestStatus.Recived:
                    return "Request recived";
                case RequestStatus.WorkInProgress:
                    return "Work in progress";
                case RequestStatus.WorkFinished:
                    return "Work finished";
                default:
                    return "Wrong status";
            }
        }

        private string GetServiceTypes(ServiceType serviceType)
        {
            switch(serviceType)
            {
                case ServiceType.Diagnostics:
                    return "Diagnostics";
                case ServiceType.RepairWithoutReplacement:
                    return "Repair Without Replacement";
                case ServiceType.RepairWithReplacement:
                    return "Repair with replacement";
                default:
                    return "Wrong type";
            }
        }
    }
}
