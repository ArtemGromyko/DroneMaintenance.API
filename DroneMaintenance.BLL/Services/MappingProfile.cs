using AutoMapper;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.RequestModels.Drone;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.Drone;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;

namespace DroneMaintenance.BLL.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMapsForServiceRequest();
            CreateMapsForClient();
            CreateMapsForDrone();
        }

        private void CreateMapsForServiceRequest()
        {
            CreateMap<ServiceRequest, ServiceRequestModel>()
                .ForMember(srm => srm.RequestStatus, opts => opts.MapFrom(x => GetStatuses(x.RequestStatus)))
                .ForMember(srm => srm.ServiceType, opts => opts.MapFrom(x => GetServiceTypes(x.ServiceType)));
            CreateMap<ServiceRequestForCreationModel, ServiceRequest>();
            CreateMap<ServiceRequestForUpdateModel, ServiceRequest>().ReverseMap();
        }

        private void CreateMapsForClient()
        {
            CreateMap<Client, ClientModel>();
            CreateMap<ClientForCreationModel, Client>();
            CreateMap<ClientForUpdateModel, Client>().ReverseMap();
        }

        private void CreateMapsForDrone()
        {
            CreateMap<Drone, DroneModel>();
            CreateMap<DroneForCreationModel, Drone>();
            CreateMap<DroneForUpdateModel, Drone>().ReverseMap();
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
