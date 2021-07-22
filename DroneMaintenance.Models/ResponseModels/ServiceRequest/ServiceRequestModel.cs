using System;

namespace DroneMaintenance.Models.ResponseModels.ServiceRequest
{
    public class ServiceRequestModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string ServiceType { get; set; }
        public string RequestStatus { get; set; }
        public DateTime Date { get; set; }
    }
}
