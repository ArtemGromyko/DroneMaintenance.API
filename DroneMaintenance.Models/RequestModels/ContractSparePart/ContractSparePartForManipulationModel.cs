using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.ContractSparePart
{
    public abstract class ContractSparePartForManipulationModel
    {
        public Guid ContractId { get; set; }
        public Guid SparePartId { get; set; }
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
