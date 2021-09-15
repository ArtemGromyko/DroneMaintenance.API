using DroneMaintenance.DTO;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IOrdersProducerService
    {
        void PostSparePartOrder(SparePartDto sparePartDto);
    }
}
