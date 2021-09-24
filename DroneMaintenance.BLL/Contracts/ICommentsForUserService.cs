using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Comment;
using DroneMaintenance.Models.ResponseModels.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Contracts
{
    public interface ICommentsForUserService
    {
        Task<Comment> TryGetCommentEntityForUserAsync(Guid userId, Guid id);
        Task<List<CommentModel>> GetCommentsForUserAsync(Guid userId);
        Task<CommentModel> GetCommentForUserAsync(Guid userId, Guid id);
        Task<CommentModel> CreateCommentForUserAsync(Guid userId, CommentForCreationModel commentForCreationModel);
        Task<CommentModel> UpdateCommentForUserAsync(Guid userId, Guid id, CommentForUpdateModel commentForUpdateModel);
        Task DeleteCommentForUserAsyn(Guid userId, Guid id);
    }
}
