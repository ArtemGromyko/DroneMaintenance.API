using DroneMaintenance.Models.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IUsersService
    {
        Task<UserModel> AuthenticateAsync(string username, string password);
        List<UserModel> GetUsersAsync();
        Task<UserModel> GetUser(Guid id);
    }
}
