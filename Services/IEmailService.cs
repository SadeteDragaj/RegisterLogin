using RegisterLogin.Models;
using System.Threading.Tasks;

namespace RegisterLogin.Services
{
    public interface IEmailService
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
        Task SendEmailForForgotPassword(UserEmailOptions userEmailOptions);
    }
}