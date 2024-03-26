using Microsoft.AspNetCore.Identity;
using projectsem3.Models.User;

namespace projectsem3.Repositories
{
    public interface IAccountRepostitory 
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SignInAsync(SignInModel model); 
    }
}
