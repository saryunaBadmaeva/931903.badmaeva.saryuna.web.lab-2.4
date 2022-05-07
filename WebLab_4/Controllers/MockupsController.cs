using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using WebLab_4.Models;


namespace WebLab_4.Controllers
{
    public class MockupsController : Controller
    {
        private static List<User> _listUsers = new List<User>();
        private static User _user = new User();
        private static string _code = ""; 
        public IActionResult Index(string Action)
        {
            if (Action == "Verify") ViewData["Reset"] = "Instructions has been sent on your email. Check and follow it!";
            else ViewData["Reset"] = "";
            return View();
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            ViewData["FirstForm"] = true;

            return View();
        }

        [HttpPost]
        public IActionResult SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                ViewData["FirstForm"] = true;
                
                return View();
            }

            _user.FirstName = user.FirstName;
            _user.LastName = user.LastName;
            _user.Day = user.Day;
            _user.Month = user.Month;
            _user.Year = user.Year;
            _user.Gender = user.Gender;

            ViewData["FirstForm"] = false;

            return View();
        }
        public IActionResult SignUpCredentials(User user)
        {
            _user.Email = user.Email;
            _user.Password = user.Password;
            _user.ConfirmPassword = user.ConfirmPassword;
            _user.Remember = user.Remember;

            _listUsers.Add(_user);

            return View(_user);
        }

        [HttpGet]
        public IActionResult Reset()
        {
            ViewData["KnownEmail"] = false;
            return View();
        }

        [HttpPost]
        public IActionResult Reset(string email, string action)
        {
            ViewData["KnownEmail"] = true;
            if (action == "Send me a code")
            {
                var rand = new Random();
                var code = rand.Next(0, 10).ToString() + rand.Next(0, 10).ToString()
                                                       + rand.Next(0, 10).ToString()
                                                       + rand.Next(0, 10).ToString();
                ViewData["Code"] = code;
                _code = code;
            }
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email)
        {
            return Json(!_listUsers.Select(s => s.Email).Contains(email));
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckResetEmail(string resetEmail)
        {
            return Json(_listUsers.Select(s => s.Email).Contains(resetEmail));
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckCode(string code)
        {
            return Json(code == _code);
        }
    }
}