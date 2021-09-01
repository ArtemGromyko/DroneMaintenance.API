using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.RequestModels.ServiceRequest;
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
        Task<Client> TryGetClientEntityByIdAsync(Guid id);

        Task<ServiceRequest> TryGetRequestForClientAsync(Guid clientId, Guid id);

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
        Task<ClientModel> GetClientAsync(Guid id);

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
        Task DeleteClientAsync(Guid id);

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="clientEntity">Client to update</param>
        /// <param name="clientForUpdateModel">Client update model</param>
        Task<ClientModel> UpdateClientAsync(Guid id, CommentForUpdateModel clientForUpdateModel);

        Task<ClientModel> UpdateClientAsync(Client clientEntity, CommentForUpdateModel clientForUpdateModel);

        /// <summary>
        /// Maps from the clientEntity to the clientForUpdateModel
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns>The client update model</returns>
        Task <(CommentForUpdateModel clientForUpdateModel, Client clientEntity)>GetClientToPatch(Guid id);

        Task<List<ServiceRequestModel>> GetRequestsForClientAsync(Guid clientId);

        Task<ServiceRequestModel> GetRequestForClientAsync(Guid clientId, Guid id);

        Task<ServiceRequestModel> CreateRequestForClientAsyn(Guid clientId, ServiceRequestForCreationModel requestForCreationModel);

        Task<ServiceRequestModel> UpdateRequestForClientAsync(Guid clientId, Guid id, ServiceRequestForUpdateModel requestForUpdateModel);

        Task DeleteRequestForClientAsync(Guid clientId, Guid id);
    }
}
