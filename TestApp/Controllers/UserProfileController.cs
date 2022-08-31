using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestApp.Data;
using TestApp.Models;
using Microsoft.Extensions.Configuration;

namespace TestApp.Controllers
{
    public class UserProfileController : Controller
    {
        private IUserRepository _userRepository;
        private IConfiguration _configuration;

        public UserProfileController(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Users()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Users(UserViewModel newuser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserProfile user = new UserProfile
                    {
                        FirstName = newuser.FirstName,
                        LastName = newuser.LastName
                    };
                    await _userRepository.SaveUser(user);
                    ViewData["Message"] = "Success";
                    ViewBag.Messge = "Success";
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Messge = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Download()
        {
            return Content(await _userRepository.GetRawUsers());
        }
    }
}
