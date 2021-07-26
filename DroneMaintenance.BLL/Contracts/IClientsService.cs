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
        /// Tries to get a client
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <returns>The client with provided id</returns>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
        Task<Client> TryGetClientEntityByIdAsync(Guid id);

        /// <summary>
        /// Gets the list of clients
        /// </summary>
        /// <returns>The list of clients</returns>
        Task<List<ClientModel>> GetClientsAsync();

        /// <summary>
        /// Gets a client 
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <returns>Client with provided id</returns>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
        Task<ClientModel> GetClientAsync(Guid id);

        /// <summary>
        /// Creates a client
        /// </summary>
        /// <param name="clientForCreationModel">Client request model for creation</param>
        /// <returns>Client response model</returns>
        Task<ClientModel> CreateClientAsync(ClientForCreationModel clientForCreationModel);

        /// <summary>
        /// Deletes a client with provided id
        /// </summary>
        /// <param name="id">Client's id</param>
        /// <returns></returns>
        /// <exception cref="DroneMaintenance.BLL.Exceptions.EntityNotFoundException">Throws if a client with provided id doesn't exist in the database</exception>
        Task DeleteClientAsync(Guid id);

        /// <summary>
        /// Updates a client
        /// </summary>
        /// <param name="clientEntity">Client to update</param>
        /// <param name="clientForUpdateModel">Client response model for update</param>
        /// <returns></returns>
        Task UpdateClientAsync(Client clientEntity, ClientForUpdateModel clientForUpdateModel);

        /// <summary>
        /// Maps from the clientEntity to the clientForUpdateModel
        /// </summary>
        /// <param name="clientEntity"></param>
        /// <returns>Client request model for update</returns>
        ClientForUpdateModel GetClientToPatch(Client clientEntity);
    }
}
