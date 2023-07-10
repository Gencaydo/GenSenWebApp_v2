using GenSenApps.IdentityServer.Dtos;
using GenSenApps.IdentityServer.Models;
using GenSenWebApps.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GenSenApps.IdentityServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignupDto signupDto)
        {
            var User = new ApplicationUser
            {
                UserName = signupDto.UserName,
                Email = signupDto.Email,
            };
            var result = await _userManager.CreateAsync(User, signupDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(ResponseDto<NoContentDto>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));
            }

            return Ok(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
