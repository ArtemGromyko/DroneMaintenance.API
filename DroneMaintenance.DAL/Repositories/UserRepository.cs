using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
        public async Task<List<User>> GetAllUsersAsync() =>
           await FindAll().Include(u => u.Role).ToListAsync();

        public async Task<User> GetUserByIdAsync(Guid id) =>
            await FindByCondition(u => u.Id.Equals(id)).Include(u => u.Role).SingleOrDefaultAsync();

        public async Task UpdateUserAsync(User user) =>
            await UpdateAsync(user);

        public async Task CreateUserAsync(User user) =>
            await CreateAsync(user);

        public async Task DeleteUserAsync(User user) =>
            await DeleteAsync(user);

        public async Task<User> GetUserByEmailAsync(string email) =>
            await FindByCondition(u => u.Email.Equals(email)).Include(u => u.Role).SingleOrDefaultAsync();
    }
}
