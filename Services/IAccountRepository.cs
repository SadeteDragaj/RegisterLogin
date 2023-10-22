using Microsoft.AspNetCore.Identity;
using RegisterLogin.Models;
using System.Threading.Tasks;

namespace RegisterLogin.Services
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task GenerateForgotPasswordTokenAsync(ApplicationUser user);

        Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);
    }
}