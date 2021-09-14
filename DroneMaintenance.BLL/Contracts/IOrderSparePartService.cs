using DroneMaintenance.DTO;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IOrderSparePartService
    {
        void PostSparePartOrder(SparePartDto sparePartDto);
    }
}
