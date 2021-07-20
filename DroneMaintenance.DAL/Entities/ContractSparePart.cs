using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class ContractSparePart
    {
        public Guid Id { get; set; }

        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }

        public Guid SparePartId { get; set; }
        public SparePart SparePart { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    }
}
