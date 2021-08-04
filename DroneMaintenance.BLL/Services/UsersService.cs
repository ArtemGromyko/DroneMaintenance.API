using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class UsersService : IUsersService
    {

        public Task<UserModel> AuthenticateAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUser(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<UserModel> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
