using System;
using System.ComponentModel.DataAnnotations;

namespace DroneMaintenance.DAL.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string Header {  get; set; }
        [Required]
        public string Text {  get; set; }
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }  
    }
}
