using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Salt { get; set; }
        public Guid RoleId { get; set; }
    }
}
