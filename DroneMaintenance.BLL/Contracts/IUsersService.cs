using DroneMaintenance.Models.RequestModels.User;
using DroneMaintenance.Models.ResponseModels.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface IUsersService
    {
        Task<UserModel> AuthenticateAsync(AuthenticationModel authenticationModel);
        Task<List<UserModel>> GetUsersAsync();
        Task<UserModel> GetUserAsync(Guid id);
        Task<UserModel> RegisterAsync(RegistrationModel registrationModel);
        Task UpdateToken(Guid id, string token);
    }
}
