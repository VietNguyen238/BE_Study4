using System.Threading.Tasks;
using be_study4.Data;
using be_study4.Dtos.User;
using be_study4.Interfaces;
using be_study4.Mappers;
using be_study4.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace be_study4.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        public UserController(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var users = await _userRepo.GetAllAsync();
            var userDto = users.Select(s => s.ToUserDto());
            if (users == null) return NotFound();

            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user.ToUserDto());
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateUserDto updateUserDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.UpdateAsync(id, updateUserDto);
            if (user == null) return NotFound();

            return Ok(user.ToUserDto());
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.DeleteAsync(id);
            if (user == null) return NotFound();

            return NoContent();
        }
    }
}