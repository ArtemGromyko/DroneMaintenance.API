using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class Drone
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Model { get; set; }
        [MaxLength(60)]
        public string Manufacturer { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }
    }
}
