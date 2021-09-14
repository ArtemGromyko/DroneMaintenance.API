using System;

namespace DroneMaintenance.Models.ResponseModels.ContractSparePart
{
    public class ContractSparePartModel
    {
        public Guid Id { get; set; }
        public Guid ContractId { get; set; }
        public Guid SparePartId { get; set; }
        public string SparePartName { get; set; }
        public int Quantity { get; set; }
    }
}
