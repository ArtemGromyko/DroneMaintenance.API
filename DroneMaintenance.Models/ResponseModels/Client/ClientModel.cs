using System;

namespace DroneMaintenance.Models.ResponseModels.Client
{
    public class ClientModel : BaseResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
