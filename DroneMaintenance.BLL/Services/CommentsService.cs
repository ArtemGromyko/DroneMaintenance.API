using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.Models.RequestModels.Comment;
using DroneMaintenance.Models.ResponseModels.Comment;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class CommentsService : ServiceBase, ICommentsService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;
        private readonly IUserRepository _userRepository;

        public CommentsService(IMapper mapper, ICommentRepository commentRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
            _userRepository = userRepository;
        }

        public async Task<Comment> TryGetCommentEntityByIdAsync(Guid id)
        {
            var commentEntity = await _commentRepository.GetCommentByIdAsync(id);
            CheckEntityExistence(id, commentEntity, nameof(Comment));

            return commentEntity;  
        }

        public async Task<CommentModel> GetCommentAsync(Guid id)
        {
            var commentEntity = await TryGetCommentEntityByIdAsync(id);
            var userEntity = await _userRepository.GetUserByIdAsync(commentEntity.UserId);
            CheckEntityExistence(id, userEntity, nameof(User));

            var commentModel = _mapper.Map<CommentModel>(commentEntity);
            commentModel.UserName = userEntity.Name;

            return commentModel;
        }

        public Task<List<CommentModel>> GetCommentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CommentModel> UpdateCommentAsync(Guid id, CommentForUpdateModel commentForUpdateModel)
        {
            throw new NotImplementedException();
        }

        public Task<CommentModel> CreateCommentAsync(CommentForCreationModel commentForCreationModel)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCommentAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
