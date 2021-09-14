using System;

namespace DroneMaintenance.DTO
{
    public class SparePartDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
