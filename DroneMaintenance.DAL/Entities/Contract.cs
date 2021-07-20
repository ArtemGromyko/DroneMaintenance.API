using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        [Required]
        public DateTime WorkStart { get; set; }
        public DateTime WorkEnd { get; set; }

        public Guid ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; }

        public List<ContractSparePart> ContractSpareParts { get; set; }
    }
}
