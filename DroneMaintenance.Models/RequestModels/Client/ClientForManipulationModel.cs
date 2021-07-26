using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.Client
{
    public abstract class ClientForManipulationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
