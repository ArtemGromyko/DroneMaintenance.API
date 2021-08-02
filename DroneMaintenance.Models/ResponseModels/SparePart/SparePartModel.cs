using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.ResponseModels.SparePart
{
    public class SparePartModel
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
