using be_study4.Data;
using be_study4.Dtos.Advise;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1/advise")]
    [ApiController]
    public class AdviseController : ControllerBase
    {
        private readonly IAdviseRepository _adviseRepo;
        public AdviseController(IAdviseRepository adviseRepo)
        {
            _adviseRepo = adviseRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advises = await _adviseRepo.GetAllAsync();

            if (advises == null) return NotFound();

            var adviseDto = advises.Select(x => x.ToAdviseDto());

            return Ok(adviseDto);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var advise = await _adviseRepo.GetByIdAsync(id);

            if (advise == null) return NotFound();

            return Ok(advise.ToAdviseDto());
        }

        [HttpPost("add/{userId:int}")]
        public async Task<IActionResult> Create([FromRoute] int userId, [FromBody] CreateAdviseDto createDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Console.WriteLine("CreateDto Information:");
            Console.WriteLine($"Name: {createDto.Name}");
            Console.WriteLine($"Phone: {createDto.Phone}");
            Console.WriteLine($"Subject: {createDto.Subject}");

            var advise = createDto.ToCreateAdviseDto(userId);
            await _adviseRepo.CreateAsync(advise);

            return CreatedAtAction(nameof(GetById), new { id = advise.Id }, advise.ToAdviseDto());
        }
    }
}