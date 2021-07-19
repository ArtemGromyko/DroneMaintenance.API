using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
        public Guid DroneId { get; set; }
        public Drone Drone { get; set; }
    }
}
