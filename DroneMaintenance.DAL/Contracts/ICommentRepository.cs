using DroneMaintenance.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Contracts
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentsAsync();
        Task<Comment> GetCommentByIdAsync(Guid id);
        Task<List<Comment>> GetAllCommentsForUserAsync(Guid userId);
        Task<Comment> GetCommentForUserAsync(Guid userId, Guid id);
        Task CreateCommentAsync(Comment comment);
        Task UpdateCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
    }
}
