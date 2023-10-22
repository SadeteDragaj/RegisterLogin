using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RegisterLogin.Models;
using RegisterLogin.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailService _emailService;


        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }
        public async Task<ViewResult> Index()
        {
            UserEmailOptions options = new UserEmailOptions
            {
                ToEmails = new List<string>() { "sadete.dragaj2@gmail.com" }
            };

            await _emailService.SendTestEmail(options);
            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
