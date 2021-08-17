﻿using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.Models.RequestModels.User
{
    public class RegistrationModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
