using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class CourseController : Controller
    {
        private readonly Repository repository;

        public CourseController(Repository repository)
        {
            this.repository = repository;
        }

        public IActionResult Course()
        {
            var course = repository.GetAllCourses();
            return this.View(course);
        }

        [HttpGet]
        public IActionResult Update(int id) //click onlink
        {
            ViewBag.Action = nameof(Update);

            var course = repository.GetCourse(id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Update([FromForm] Course course) //click onbutton
        {
            if (course.Name?.Length>0 && course.EndDate!=null && 
                course.StartDate != null && course.PassCredits!=null )
            {
                repository.UpdateCourse(course);
            }
            
            return RedirectToAction("Course");
        }

        [HttpGet]
        public IActionResult Create() //click onlink
        {
            Course course = new Course();
            ViewBag.Action = "Create";
            return View("Update", course);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Course course) //click onbutton
        {
            if (course.Name?.Length > 0 && course.EndDate != null &&
               course.StartDate != null && course.PassCredits != null)
            {
                repository.CreateCourse(course);
            }
                
            return RedirectToAction("Course");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteCourse(id);
            return RedirectToAction("Course");
        }
        
    }
}