using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
{
    public class StartPageController : Controller
    {
        public IActionResult StartPage()
        {  
            return View();
        }

        public IActionResult Student()
        {
            return RedirectToAction("Student", "Student");
        }

        public IActionResult Lecture()
        {
            return RedirectToAction("Lecture", "Lecture");
        }

        public IActionResult Course()
        {
            return RedirectToAction("Course","Course");
        }
       
    }
}