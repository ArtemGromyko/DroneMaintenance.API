using DroneMaintenance.DTO;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IOrdersProducerService
    {
        void PostSparePartOrder(OrderDto sparePartDto);
    }
}
