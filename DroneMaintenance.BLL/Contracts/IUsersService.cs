using DroneMaintenance.Models.RequestModels.User;
using DroneMaintenance.Models.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IUsersService
    {
        Task<string> AuthenticateAsync(AuthenticationModel authenticationModel);
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserAsync(Guid id);
    }
}
