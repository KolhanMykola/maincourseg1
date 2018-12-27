using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataAccess.EF;
using Models.Models;

namespace Final.Controllers
{
    public class LectureController : Controller
    {
        private readonly Repository repository;

        public LectureController(Repository repository)
        {
            this.repository = repository;
        }

        public IActionResult Lecture()
        {
            var lecture = repository.GetAllLecturers();
            return this.View(lecture);
        }

        [HttpGet]
        public IActionResult UpdateLecture(int id) //click onlink
        {
            ViewBag.Action = nameof(UpdateLecture);
            var lecture = repository.GetLecturerById(id);
            return View(lecture);
        }

        [HttpPost]
        public IActionResult UpdateLecture([FromForm] Lecturer lecturer) //click onbutton
        {
            if (lecturer.BirthDate != DateTime.MinValue && lecturer.Name != null)
                repository.UpdateLecturer(lecturer);
            return RedirectToAction("Lecture");
        }

        [HttpGet]
        public IActionResult Create() //click onlink
        {
            Lecturer lecturer = new Lecturer();
            ViewBag.Action = nameof(Create);
            return View("UpdateLecture", lecturer);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Lecturer lecturer) //click onbutton
        {
            if (lecturer.BirthDate!=DateTime.MinValue && lecturer.Name!=null)
            {
                repository.CreateLecturer(lecturer);
            }
            return RedirectToAction("Lecture");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteLecturer(id);
            return RedirectToAction("Lecture");
        }
    }
}