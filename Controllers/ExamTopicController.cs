using be_study4.Data;
using be_study4.Dtos.ExamTopic;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1/exam-topic")]
    [ApiController]
    public class ExamTopicController : ControllerBase
    {
        private readonly IExamTopicRepository _examTopicRepo;
        public ExamTopicController(IExamTopicRepository examTopicRepo)
        {
            _examTopicRepo = examTopicRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examTopics = await _examTopicRepo.GetAllAsync();

            if (examTopics == null) return NotFound();

            var examTopicDto = examTopics.Select(x => x.ToExamTopicDto());

            return Ok(examTopicDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examTopic = await _examTopicRepo.GetByIdAsync(id);

            if (examTopic == null) return NotFound();

            return Ok(examTopic.ToExamTopicDto());
        }

        [HttpPost("add/{userId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userId, [FromBody] CreateExamTopicDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examTopic = createDto.ToCreateExamTopicDto(userId);
            await _examTopicRepo.CreateAsync(examTopic);

            return CreatedAtAction(nameof(GetById), new { id = examTopic.Id }, examTopic.ToExamTopicDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateExamTopicDto updateExamTopicDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examTopic = await _examTopicRepo.UpdateAsync(id, updateExamTopicDto);
            if (examTopic == null) return NotFound();

            return Ok(examTopic.ToExamTopicDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examTopic = await _examTopicRepo.DeleteAsync(id);
            if (examTopic == null) return NotFound();

            return NoContent();
        }
    }
}