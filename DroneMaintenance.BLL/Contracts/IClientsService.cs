using DroneMaintenance.DAL.Entities;
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
        Task<Client> TryGetClientEntityByIdAsync(Guid id);
        Task<List<ClientModel>> GetClientsAsync();
        Task<ClientModel> GetClientAsync(Guid id);
        Task<ClientModel> CreateClientAsync(ClientForCreationModel clientForCreationModel);
        Task DeleteClientAsync(Guid id);
        Task UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel);
        ClientForUpdateModel GetClientToPatch(Client clientEntity);
    }
}
