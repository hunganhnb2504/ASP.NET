using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using projectsem3.Data;
using projectsem3.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace projectsem3.Repositories
{
    public class AccountRepository : IAccountRepostitory
    {
        private readonly UserManager<ApplicationsUser> userManager;
        private readonly SignInManager<ApplicationsUser> signInManager;
        private readonly IConfiguration configuration;
        //private readonly RoleManager<IdentityRole> roleManager;

        public AccountRepository(UserManager<ApplicationsUser> userManager, SignInManager<ApplicationsUser> signInManager, IConfiguration configuration/*,RoleManager<IdentityRole> roleManager*/)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            //this.roleManager = roleManager;

        }

        public async Task<string> SignInAsync(SignInModel model)
        {
            if (model.Email == null)
            {
               
                return string.Empty;
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null || model.Password == null)
            {
              
                return string.Empty; // hoặc trả về một giá trị không thành công khác
            }
            var passwordValid = await userManager.CheckPasswordAsync(user, model.Password);
            if (user == null || !passwordValid)
            {
                return string.Empty;
            }
            var auth = new List<Claim>
            {
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var userRole = await userManager.GetRolesAsync(user);
            foreach (var role in userRole)
            {
                auth.Add(new Claim(ClaimTypes.Role, role.ToString()));
            }
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: configuration["JWT:ValidateIssuer"],
                audience: configuration["JWT:ValidateAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: auth,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel model)
        {
            if (model.Password == null)
            {
                // Xử lý trường hợp model.Password là null ở đây.
                // Có thể ném một ngoại lệ hoặc trả về một giá trị không thành công khác.
                return IdentityResult.Failed(new IdentityError { Description = "Password cannot be null." });
            }
            var user = new ApplicationsUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            var result = await userManager.CreateAsync(user, model.Password);
            //if (!result.Succeeded)
            //{
            //    if (!await roleManager.RoleExistsAsync(AppRole.Admin))
            //    {
            //        await roleManager.CreateAsync(new IdentityRole(AppRole.Admin));

            //    }
            //    await userManager.AddToRoleAsync(user, AppRole.Admin);
            //}

            return result;
        }
    }
}

