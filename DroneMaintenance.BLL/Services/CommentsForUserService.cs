using AutoMapper;
using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.DAL.Entities;
using DroneMaintenance.DAL.Repositories;
using DroneMaintenance.Models.RequestModels.Comment;
using DroneMaintenance.Models.ResponseModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneMaintenance.BLL.Services
{
    public class CommentsForUserService : ServiceBase, ICommentsForUserService
    {
        private readonly UserRepository _userRepository;
        private readonly CommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentsForUserService(UserRepository userRepository, CommentRepository commentRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task CheckUserExistenceAsync(Guid userId)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            CheckEntityExistence(userId, userEntity, nameof(User));
        }

        public async Task<Comment> TryGetCommentEntityForUserAsync(Guid userId, Guid id)
        {
            var userEntity = await _userRepository.GetUserByIdAsync(userId);
            CheckEntityExistence(userId, userEntity, nameof(User));

            var commentEntity = await _commentRepository.GetCommentForUserAsync(userId, id);
            CheckEntityExistence(userId, id, commentEntity, nameof(Comment), nameof(User));

            return commentEntity;
        }

        public async Task<List<CommentModel>> GetCommentsForUserAsync(Guid userId)
        {
            await CheckUserExistenceAsync(userId);

            var commentEntities = await _commentRepository.GetAllCommentsForUserAsync(userId);

            return _mapper.Map<List<CommentModel>>(commentEntities);
        }

        public async Task<CommentModel> GetCommentForUserAsync(Guid userId, Guid id)
        {
            var commentEntity = await TryGetCommentEntityForUserAsync(userId, id);

            return _mapper.Map<CommentModel>(commentEntity);
        }

        public async Task<CommentModel> CreateCommentForUserAsync(Guid userId, CommentForCreationModel commentForCreationModel)
        {
            await CheckUserExistenceAsync(userId);

            var commentEntity = _mapper.Map<Comment>(commentForCreationModel);
            await _commentRepository.CreateCommentAsync(commentEntity);

            return _mapper.Map<CommentModel>(commentEntity);
        }

        public async Task DeleteCommentForUserAsyn(Guid userId, Guid id)
        {
            var commentEntity = await TryGetCommentEntityForUserAsync(userId, id);
            await _commentRepository.DeleteCommentAsync(commentEntity);
        }

        public async Task<CommentModel> UpdateCommentForUserAsync(Guid userId, Guid id, CommentForUpdateModel commentForUpdateModel)
        {
            var commentEntity = await TryGetCommentEntityForUserAsync(userId, id);
            _mapper.Map(commentForUpdateModel, commentEntity);
            await _commentRepository.UpdateCommentAsync(commentEntity);

            return _mapper.Map<CommentModel>(commentEntity);
        }
    }
}
