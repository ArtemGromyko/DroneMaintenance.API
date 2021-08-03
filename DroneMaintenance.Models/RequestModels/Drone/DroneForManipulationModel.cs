using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.Drone
{
    public abstract class DroneForManipulationModel
    {
        [Required]
        [MaxLength(60)]
        public string Model { get; set; }
        [MaxLength(60)]
        public string Manufacturer { get; set; }
    }
}
