using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class ServiceType
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(0)]
        public decimal Price { get; set; }
        public List<ServiceRequest> ServiceRequests { get; set; }
    }
}
