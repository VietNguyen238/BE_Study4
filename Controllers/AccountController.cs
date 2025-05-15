using be_study4.Dtos.Account;
using be_study4.Dtos.User;
using be_study4.Interfaces;
using be_study4.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace be_study4.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;
        public AccountController(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        [HttpPost("account")]
        public async Task<IActionResult> Create([FromBody] RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userRepo.FindByEmail(registerDto.Email);
            Console.Write(user);
            if (user != null)
            {
                return Ok(new NewUserDto
                {
                    Avatar = user.Avatar,
                    Name = user.Name,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user),
                });
            }
            else
            {
                var newUser = registerDto.ToRegisterDto();
                await _userRepo.RegisterAsync(newUser);
                return Ok(new NewUserDto
                {
                    Avatar = newUser.Avatar,
                    Name = newUser.Name,
                    Email = newUser.Email,
                    Token = _tokenService.CreateToken(newUser),
                });
            }
        }

    }
}