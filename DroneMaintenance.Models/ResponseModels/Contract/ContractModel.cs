using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DroneMaintenance.Models.ResponseModels.Contract
{
    public class ContractModel
    {
        public Guid Id { get; set; }
        public DateTime WorkStartDate { get; set; }
        public DateTime WorkEndDate { get; set; }

        public Guid ServiceRequestId { get; set; }
    }
}
