using System;

namespace DroneMaintenance.DAL.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public DateTime WorkDate { get; set; }
        public Guid ServiceRequestId { get; set; }
        public ServiceRequest ServiceRequest { get; set; }

    }
}
