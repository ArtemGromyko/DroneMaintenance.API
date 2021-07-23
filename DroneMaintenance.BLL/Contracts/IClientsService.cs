using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    /// <summary>
    /// Service to manage clients
    /// </summary>
    public interface IClientsService
    {
        Task<List<ClientModel>> GetClientsAsync();
        Task<ClientModel> GetClientAsync(Guid id);
        Task<ClientModel> CreateClientAsync(ClientForCreationModel client);
    }
}
