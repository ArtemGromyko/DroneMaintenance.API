using System;
using System.Collections.Generic;
using System.Text;

namespace DroneMaintenance.Models.RequestModels.Contract
{
    public abstract class ContractForManipulationModel
    {
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }

        public Guid ServiceRequestId { get; set; }
    }
}
