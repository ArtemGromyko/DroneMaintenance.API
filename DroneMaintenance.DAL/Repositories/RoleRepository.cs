using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<Role> GetRoleByIdAsync(Guid id) =>
            await FindByCondition(r => r.Id.Equals(id)).SingleOrDefaultAsync();
    }
}
