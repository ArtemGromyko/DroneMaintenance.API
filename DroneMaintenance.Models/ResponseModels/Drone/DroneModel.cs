using System;

namespace DroneMaintenance.Models.ResponseModels.Drone
{
    public class DroneModel : BaseResponseModel
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
    }
}
