using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.DAL.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(RepositoryContext repositoryContext) : base(repositoryContext) {}

        public async Task<List<Comment>> GetAllCommentsAsync() =>
            await FindAll().ToListAsync();

        public async Task<Comment> GetCommentByIdAsync(Guid id) =>
            await FindByCondition(c => c.Id.Equals(id)).SingleOrDefaultAsync();

        public async Task UpdateCommentAsync(Comment comment) =>
            await UpdateAsync(comment);

        public async Task CreateCommentAsync(Comment comment) =>
            await CreateAsync(comment);

        public async Task DeleteCommentAsync(Comment comment) =>
            await DeleteAsync(comment);
    }
}
