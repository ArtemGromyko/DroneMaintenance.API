using DroneMaintenance.DAL.Entities;
using System.Threading.Tasks;
using System;
using DroneMaintenance.Models.ResponseModels.Comment;
using System.Collections.Generic;
using DroneMaintenance.Models.RequestModels.Comment;

namespace DroneMaintenance.BLL.Contracts
{
    public interface ICommentsService
    {
        Task<Comment> TryGetCommentEntityByIdAsync(Guid id);
        Task<CommentModel> GetCommentAsync(Guid id);
        Task<List<CommentModel>> GetCommentsAsync();
        Task<CommentModel> CreateCommentAsync(CommentForCreationModel commentForCreationModel);
        Task DeleteCommentAsync(Guid id);
        Task<CommentModel> UpdateCommentAsync(Guid id, CommentForUpdateModel commentForUpdateModel);
    }
}
