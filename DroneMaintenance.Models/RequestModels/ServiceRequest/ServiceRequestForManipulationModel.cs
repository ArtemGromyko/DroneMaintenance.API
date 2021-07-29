using DroneMaintenance.DAL.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.ServiceRequest
{
    public abstract class ServiceRequestForManipulationModel
    {
        public string Description { get; set; }
        [Required]
        [Range(0, 3)]
        public ServiceType ServiceType { get; set; }
        public Guid DroneId { get; set; }
        public Guid ClientId { get; set; }
    }
}
