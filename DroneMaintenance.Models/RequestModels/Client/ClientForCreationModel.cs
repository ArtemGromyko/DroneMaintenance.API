using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.Client
{
    public class ClientForCreationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
