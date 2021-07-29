namespace DroneMaintenance.Models.ResponseModels
{
    public abstract class BaseResponseModel
    {
        public string[] ResponseMessages { get; set; }

        public BaseResponseModel() { }

        public BaseResponseModel(string[] messages)
        {
            ResponseMessages = messages;
        }
    }
}
