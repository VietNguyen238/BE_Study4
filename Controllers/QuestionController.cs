using System.Threading.Tasks;
using be_study4.Data;
using be_study4.Dtos.Question;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Controllers
{
    [Route("api/v1/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepo;
        public QuestionController(IQuestionRepository questionRepo)
        {
            _questionRepo = questionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestion()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var questions = await _questionRepo.GetAllAsync();
            if (questions == null) return NotFound();
            var questionDto = questions.Select(s => s.ToQuestionDto());
            return Ok(questionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var questions = await _questionRepo.GetByIdAsync(id);
            if (questions == null) return NotFound();
            return Ok(questions.ToQuestionDto());
        }

        [HttpPost("add/{examSectionId:int}")]
        public async Task<IActionResult> Create([FromRoute] int examSectionId, [FromBody] CreateQuestionDto questionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var questionModel = questionDto.ToCreateQuestionDto(examSectionId);
            await _questionRepo.CreateAsync(questionModel);
            return CreatedAtAction(nameof(GetById), new { id = questionModel.Id }, questionModel.ToQuestionDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateQuestionDto updateQuestionDtoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = await _questionRepo.UpdateAsync(id, updateQuestionDtoDto);
            if (question == null) return NotFound();

            return Ok(question.ToQuestionDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = await _questionRepo.DeleteAsync(id);
            if (question == null) return NotFound();

            return NoContent();
        }
    }
}