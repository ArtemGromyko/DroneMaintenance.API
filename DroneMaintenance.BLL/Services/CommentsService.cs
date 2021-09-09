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

            return commentModel;
        }

        public async Task<List<CommentModel>> GetCommentsAsync()
        {
            var commentEntities = await _commentRepository.GetAllCommentsAsync();
            var commentModels = _mapper.Map<List<CommentModel>>(commentEntities);  

            return commentModels;
        }

        public async Task<CommentModel> UpdateCommentAsync(Guid id, CommentForUpdateModel commentForUpdateModel)
        {
            var commentEntity = await TryGetCommentEntityByIdAsync(id);
            var commentModel = _mapper.Map<CommentModel>(commentEntity);

            return commentModel;
        }

        public async Task<CommentModel> CreateCommentAsync(CommentForCreationModel commentForCreationModel)
        {
            var commentEntity = _mapper.Map<Comment>(commentForCreationModel);
            await _commentRepository.CreateCommentAsync(commentEntity);

            return _mapper.Map<CommentModel>(commentEntity);
        }

        public async Task DeleteCommentAsync(Guid id)
        {
            var commentEntity = await TryGetCommentEntityByIdAsync(id);

            await _commentRepository.DeleteCommentAsync(commentEntity);
        }
    }
}
