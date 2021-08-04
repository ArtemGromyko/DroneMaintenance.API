using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.User
{
    public class AuthenticationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
