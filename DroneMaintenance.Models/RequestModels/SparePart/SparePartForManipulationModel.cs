using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.SparePart
{
    public abstract class SparePartForManipulationModel
    {
        [Required]
        [MaxLength(60)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
