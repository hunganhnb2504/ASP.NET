using Microsoft.AspNetCore.Mvc;
using projectsem3.Models;
using projectsem3.Models.User;
using projectsem3.Repositories;

namespace projectsem3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountRepostitory accountRepo;

        public AccountsController(IAccountRepostitory repo)
        {
            accountRepo = repo;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp(SignUpModel signUpModel)
        {
            var result = await accountRepo.SignUpAsync(signUpModel);
            if (result.Succeeded)
            {
                return Ok("User signed up successfully.");
            }
            return Unauthorized("Failed to sign up user.");
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn(SignInModel signInModel)
        {
            var result = await accountRepo.SignInAsync(signInModel);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized("Invalid username or password.");
            }
            return Ok($"User {result} signed in successfully.");
        }
    }
}
