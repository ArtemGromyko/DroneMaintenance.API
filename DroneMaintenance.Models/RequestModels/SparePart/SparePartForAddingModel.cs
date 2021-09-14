using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DroneMaintenance.Models.RequestModels.SparePart
{
    public class SparePartForAddingModel
    {
        [Required]
        public string Name { get; set; }

    }
}
