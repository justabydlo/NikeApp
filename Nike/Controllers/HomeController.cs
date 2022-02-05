using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nike.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nike.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserRepository data;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            data = new UserRepository();
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            User model = new User();
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if(!data.IsModelCorrect(model))
            {
                data.GetValidationErrors(this.ControllerContext, model);
                return View(model);
            }
            return RedirectPermanent(Url.Action("Store", "Home"));
        }
        public IActionResult Store()
        {
            return View();
        }
    }
}
