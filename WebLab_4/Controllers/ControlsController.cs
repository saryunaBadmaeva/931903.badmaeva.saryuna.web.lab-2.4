using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLab_4.Controllers
{
    public class ControlsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TextBox()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TextBox(string result)
        {
            ViewBag.NameControl = "Text Box";
            ViewBag.Object = "Text";
            ViewBag.Result = result;
            return View("Result");
        }

        public IActionResult TextArea()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TextArea(string result)
        {
            ViewBag.NameControl = "Text Area";
            ViewBag.Object = "Text";
            ViewBag.Result = result;
            return View("Result");
        }

        public IActionResult CheckBox()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckBox(bool result)
        {
            ViewBag.NameControl = "Check Box";
            ViewBag.Object = "IsSelected";
            ViewBag.Result = result.ToString();
            return View("Result");
        }

        public IActionResult Radio()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Radio(string result)
        {
            ViewBag.NameControl = "Radio";
            ViewBag.Object = "Month";
            ViewBag.Result = result;
            return View("Result");
        }

        public IActionResult DropDownList()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DropDownList(string result)
        {
            ViewBag.NameControl = "Drop-down List";
            ViewBag.Object = "Month";
            ViewBag.Result = result;
            return View("Result");
        }

        public IActionResult ListBox()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ListBox(string[] result)
        {
            ViewBag.NameControl = "List Box";
            ViewBag.Object = "Months";
            ViewBag.Result = result;
            return View("Result");
        }
    }
}
