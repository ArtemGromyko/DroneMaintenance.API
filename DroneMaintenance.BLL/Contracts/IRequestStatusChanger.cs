using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IRequestStatusChanger
    {
        Task UpdateRequestStatusAsync();
    }
}
