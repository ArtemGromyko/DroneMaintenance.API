using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.ResponseModels.Client;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Contracts
{
    /// <summary>
    /// Service to manage clients
    /// </summary>
    public interface IClientsService
    {
        Task<IActionResult> GetClientsAsync();
        Task<IActionResult> GetClientAsync(Guid id);
        Task<ClientModel> CreateClientAsync(ClientForCreationModel client);
    }
}
