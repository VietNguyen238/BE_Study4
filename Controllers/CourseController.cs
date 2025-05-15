using be_study4.Data;
using be_study4.Dtos.Course;
using be_study4.Helpers;
using be_study4.Interfaces;
using be_study4.Mappers;
using be_study4.Repository;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository _courseRepo;
        private readonly IUploadImageRepository _uploadImageRepo;

        public CourseController(ICourseRepository courseRepo, IUploadImageRepository uploadImageRepo)
        {
            _courseRepo = courseRepo;
            _uploadImageRepo = uploadImageRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CourseQueryObject courseQuery)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var courses = await _courseRepo.GetAllAsync(courseQuery);

            if (courses == null) return NotFound();

            var courseDto = courses.Select(x => x.ToCourseDto());

            return Ok(courseDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseRepo.GetByIdAsync(id);

            if (course == null) return NotFound();

            return Ok(course.ToCourseDto());
        }

        [HttpPost("add/{userId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userId, [FromForm] CreateCourseDto createDto, IFormFile FileImage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (FileImage == null || FileImage.Length == 0)
                return BadRequest("FileImage is not selected");

            try
            {
                var image = await _uploadImageRepo.Upload(FileImage);
                if (image.StartsWith("Extention is not valid") || image.StartsWith("Maximum size can be"))
                {
                    return BadRequest(image);
                }

                var course = createDto.ToCreateCourseDto(userId, image);
                await _courseRepo.CreateAsync(course);

                return CreatedAtAction(nameof(GetById), new { id = course.Id }, course.ToCourseDto());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateCourseDto updateCourseDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseRepo.UpdateAsync(id, updateCourseDto);
            if (course == null) return NotFound();

            return Ok(course.ToCourseDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var course = await _courseRepo.DeleteAsync(id);
            if (course == null) return NotFound();

            return NoContent();
        }
    }
}