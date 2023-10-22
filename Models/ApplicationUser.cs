using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System;
using Xunit.Abstractions;

namespace RegisterLogin.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
