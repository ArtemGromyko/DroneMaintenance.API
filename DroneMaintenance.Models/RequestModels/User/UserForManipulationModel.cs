using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.User
{
    public abstract class UserForManipulationModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid RoleId { get; set; }
    }
}
