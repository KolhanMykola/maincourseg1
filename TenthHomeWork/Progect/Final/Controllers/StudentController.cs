using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DataAccess.EF;
using Models.Models;

namespace Final.Controllers
{
    public class StudentController : Controller
    {
        private readonly Repository repository;

        public StudentController(Repository repository)
        {
            this.repository = repository;
        }

        public IActionResult Student()
        {
            var student = repository.GetAllStudents();
            return this.View(student);
        }

        [HttpGet]
        public IActionResult UpdateStudent(int id) //click onlink
        {
            ViewBag.Action = nameof(UpdateStudent);

            var student = repository.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult UpdateStudent([FromForm] Student student) //click onbutton
        {
            if (student.BirthDate != DateTime.MinValue && student.Email != null && student.GitHubLink != null && student.Name != null && student.Notes != null && student.PhoneNumber.Length == 12)
            {
                repository.UpdateStudent(student);
            }
            return RedirectToAction("Student");
        }

        [HttpGet]
        public IActionResult Create() //click onlink
        {
            Student student = new Student();
            ViewBag.Action = nameof(Create);
            return View("UpdateStudent", student);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student student) //click onbutton
        {
            if (student.BirthDate != DateTime.MinValue && student.Email != null && student.GitHubLink != null && student.Name != null && student.Notes != null && student.PhoneNumber.Length == 12)
            {
                repository.CreateStudent(student);
            }
            return RedirectToAction("Student");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("Student");
        }

        [HttpGet]
        public IActionResult Check(int studentId)
        {
            ViewBag.Action = nameof(Check);
            List<HomeTaskAssessment> homeTaskAssessment = repository.GetHomeTaskAssessmentsByStudentId(studentId);
            return View("StudentCourses", homeTaskAssessment);
        }

        [HttpPost]
        public IActionResult UpdateHomeTaskAssessments(  IEnumerable<HomeTaskAssessment> homeTaskAssessment) 
        {       
            repository.UpdateHomeTaskAssessments(homeTaskAssessment.ToList());
            return RedirectToAction("Student");
        }
    }
}