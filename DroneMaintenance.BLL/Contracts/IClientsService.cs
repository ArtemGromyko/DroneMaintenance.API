using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using DroneMaintenance.Models.ResponseModels.ServiceRequest;
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
        /// <summary>
        /// Tries to get a client entity
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>The client entity with provided id or null</returns>
        Task<Client> GetClientEntityByIdAsync(Guid id);

        /// <summary>
        /// Gets a list of clients
        /// </summary>
        /// <returns>The list of clients</returns>
        Task<List<ClientModel>> GetClientsAsync();

        /// <summary>
        /// Gets a client 
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>The client with provided id or null</returns>
        Task<ClientModel> GetClientByIdAsync(Guid id);

        /// <summary>
        /// Creates a client
        /// </summary>
        /// <param name="clientForCreationModel">Client request model for creation</param>
        /// <returns>The client model created for the response</returns>
        Task<ClientModel> CreateClientAsync(ClientForCreationModel clientForCreationModel);

        /// <summary>
        /// Deletes a client with provided id
        /// </summary>
        /// <param name="clientEntity"></param>
        Task DeleteClientAsync(Client clientEntity);

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="clientEntity">Client to update</param>
        /// <param name="clientForUpdateModel">Client update model</param>
        Task<ClientModel> UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel);

        /// <summary>
        /// Maps from the clientEntity to the clientForUpdateModel
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns>The client update model</returns>
        ClientForUpdateModel GetClientToPatch(Client clientEntity);

        Task<List<ServiceRequestModel>> GetRequestsForClientAsync(Guid clientId);

        Task<ServiceRequestModel> GetServiceRequestForClient(Guid clientId, Guid id);
    }
}
