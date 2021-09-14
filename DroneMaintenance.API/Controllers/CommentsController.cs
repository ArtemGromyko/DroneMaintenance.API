using DroneMaintenance.BLL.Contracts;
using DroneMaintenance.Models.RequestModels.Comment;
using DroneMaintenance.Models.ResponseModels.Comment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DroneMaintenance.API.Controllers
{
    [Authorize]
    [Route("api/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentModel>>> GetCommentsAsync() =>
            await _commentsService.GetCommentsAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<CommentModel>> GetCommentAsync(Guid id) => 
            await _commentsService.GetCommentAsync(id);
        
        [HttpPost]
        public async Task<ActionResult<CommentModel>> CreateCommentAsync([FromBody]CommentForCreationModel comment) =>
            await _commentsService.CreateCommentAsync(comment);

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentModel>> UpdateCommentAsync(Guid id, [FromBody]CommentForUpdateModel comment) =>
            await _commentsService.UpdateCommentAsync(id, comment);

        [HttpDelete("{id}")]
        public async Task<ActionResult<CommentModel>> DeleteCommentAsync(Guid id)
        {
            await _commentsService.DeleteCommentAsync(id);

            return NoContent();
        }
    }
}
