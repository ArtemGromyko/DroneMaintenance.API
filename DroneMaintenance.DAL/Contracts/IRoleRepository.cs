using DroneMaintenance.DAL.Entities;
using System;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface IRoleRepository
    {
        Task<Role> GetRoleByIdAsync(Guid id);
    }
}
