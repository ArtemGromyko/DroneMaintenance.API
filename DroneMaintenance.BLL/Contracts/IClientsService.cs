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
        /// <summary>
        /// Tries to get a client entity
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>The client with provided id</returns>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
        Task<Client> TryGetClientEntityByIdAsync(Guid id);

        /// <summary>
        /// Gets a list of clients
        /// </summary>
        /// <returns>The list of clients</returns>
        Task<List<ClientModel>> GetClientsAsync();

        /// <summary>
        /// Gets a client 
        /// </summary>
        /// <param name="id">Client id</param>
        /// <returns>The client with provided id</returns>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
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
        /// <param name="id">Client id</param>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
        Task DeleteClientAsync(Guid id);

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="clientEntity">Client to update</param>
        /// <param name="clientForUpdateModel">Client update model for the request</param>
        Task UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel);

        /// <summary>
        /// Maps from the clientEntity to the clientForUpdateModel
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns>The client update model for the request</returns>
        ClientForUpdateModel GetClientToPatch(Client clientEntity);
    }
}
