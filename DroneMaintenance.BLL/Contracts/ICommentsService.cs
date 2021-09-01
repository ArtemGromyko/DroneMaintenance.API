using DroneMaintenance.DAL.Entities;
using System.Threading.Tasks;
using System;
using DroneMaintenance.Models.ResponseModels.Client;
using System.Collections.Generic;
using DroneMaintenance.Models.RequestModels.Client;
using DroneMaintenance.Models.RequestModels.Comment;

namespace DroneMaintenance.BLL.Contracts
{
    public interface ICommentsService
    {
        Task<Client> TryGetCommentEntityByIdAsync(Guid id);
        Task<ClientModel> GetCommentAsync(Guid id);
        Task<List<ClientModel>> GetCommentsAsync();
        Task<ClientModel> CreateCommentAsync(CommentForCreationModel commentForCreationModel);
        Task DeleteCommentAsync(Guid id);
        Task<ClientModel> UpdateCommentAsync(Guid id, CommentForUpdateModel commentForUpdateModel);
    }
}
