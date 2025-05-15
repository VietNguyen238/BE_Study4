using be_study4.Data;
using be_study4.Dtos.ExamSection;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1/exam-section")]
    [ApiController]
    public class ExamSectionController : ControllerBase
    {
        private readonly IExamSectionRepository _examSectionRepo;
        public ExamSectionController(IExamSectionRepository examSectionRepo)
        {
            _examSectionRepo = examSectionRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examSections = await _examSectionRepo.GetAllAsync();

            if (examSections == null) return NotFound();

            var examSectionDto = examSections.Select(x => x.ToExamSectionDto());

            return Ok(examSectionDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examSection = await _examSectionRepo.GetByIdAsync(id);

            if (examSection == null) return NotFound();

            return Ok(examSection.ToExamSectionDto());
        }

        [HttpPost("add/{examTopicId:int}")]
        public async Task<IActionResult> Create([FromRoute] int examTopicId, [FromBody] CreateExamSectionDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examSection = createDto.ToCreateExamSectionDto(examTopicId);
            await _examSectionRepo.CreateAsync(examSection);

            return CreatedAtAction(nameof(GetById), new { id = examSection.Id }, examSection.ToExamSectionDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateExamSectionDto updateExamSectionDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examSection = await _examSectionRepo.UpdateAsync(id, updateExamSectionDto);
            if (examSection == null) return NotFound();

            return Ok(examSection.ToExamSectionDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var examSection = await _examSectionRepo.DeleteAsync(id);
            if (examSection == null) return NotFound();

            return NoContent();
        }
    }
}