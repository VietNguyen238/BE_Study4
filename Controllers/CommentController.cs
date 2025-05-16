using be_study4.Data;
using be_study4.Dtos.Comment;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comments = await _commentRepo.GetAllAsync();

            if (comments == null) return NotFound();

            var commentDto = comments.Select(x => x.ToCommentDto());

            return Ok(commentDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.GetByIdAsync(id);

            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpPost("add/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Create([FromRoute] int userId, [FromRoute] int examTopicId, [FromBody] CreateCommentDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = createDto.ToCreateCommentDto(userId, examTopicId);
            await _commentRepo.CreateAsync(comment);

            return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDto());
        }

        [HttpPut("update/{id:int}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCommentDto updateCommentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.UpdateAsync(id, updateCommentDto);
            if (comment == null) return NotFound();

            return Ok(comment.ToCommentDto());
        }

        [HttpDelete("{id:int}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var comment = await _commentRepo.DeleteAsync(id);
            if (comment == null) return NotFound();

            return NoContent();
        }
    }
}