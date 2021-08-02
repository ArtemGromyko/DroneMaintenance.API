using System;
using System.Collections.Generic;
using System.Text;

namespace DroneMaintenance.Models.ResponseModels.ContractSparePart
{
    public class ContractSparePartModel
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public Guid SparePartId { get; set; }
        public int Quantity { get; set; }
    }
}
