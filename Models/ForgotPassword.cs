using System.ComponentModel.DataAnnotations;

namespace RegisterLogin.Models
{
    public class ForgotPassword
    {
        public int Id { get; set; }
        [Required,EmailAddress,Display(Name = "Registered email address")]
        public string Email { get; set; }
        public bool EmailSent { get; set; }
    }
}
