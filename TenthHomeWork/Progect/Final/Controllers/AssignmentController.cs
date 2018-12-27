using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Models.Models;
using Final.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Final.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly Repository repository;

        public AssignmentController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Assign( int id)
        {
            var allstudents = this.repository.GetAllStudents();
            var course = repository.GetCourse(id);
            var model = new AssignStudentsViewModel();
            if (course != null)
            {
                model.Id = id;
                model.CourseName = course.Name;
                model.StartDate = course.StartDate;
            }

            model.Students = new List<StudentViewModel>();

            foreach (var student in allstudents)
            {
                model.Students.Add(new StudentViewModel()
                {
                    Id = student.Id,
                    Name = student.Name,
                    IsChecked = course.Students.Any(s => s.StudentId == student.Id)
                });
            }
           
            return View(model);
        }

        [HttpPost]
        public IActionResult Assign(AssignStudentsViewModel model)
        {
            var student = model.Students.Where(s => s.IsChecked).Select(s => s.Id);
            repository.SetStudentsToCourse(model.Id, student);
            return RedirectToAction("Course", "Course");
        }

    }
}