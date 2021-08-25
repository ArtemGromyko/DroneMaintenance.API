using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class ServiceRequest
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        [Required]
        [Range(0, 3)]
        public ServiceType ServiceType { get; set; }
        [Range(0, 3)]
        public RequestStatus RequestStatus { get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid DroneId { get; set; }
        public Drone Drone { get; set; }

        public List<Contract> Contracts { get; set; }
    }
}
