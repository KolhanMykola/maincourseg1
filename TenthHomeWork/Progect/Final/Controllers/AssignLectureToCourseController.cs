using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.EF;
using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Final.ViewModel;
using static Final.ViewModel.AssignLectureToCourseModel;

namespace Final.Controllers
{
    public class AssignLectureToCourseController : Controller
    {
        private readonly Repository repository;

        public AssignLectureToCourseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IActionResult Assign(int id)
        {
            var alllectures = this.repository.GetAllLecturers();
            var course = repository.GetCourse(id);
            var model = new AssignLectureToCourseModel
            {
                Id = id,
                CourseName = course.Name,
                BirthDate = course.StartDate,
                Lectures = new List<LectureViewModel>()
            };

            foreach (var alllecture in alllectures)
            {
                model.Lectures.Add(new LectureViewModel()
                {
                    Id = alllecture.Id,
                    Name = alllecture.Name,
                    IsChecked = course.Lecturers.Any(s => s.LecturerId == alllecture.Id)//???
                });
            }
            return View("AssignLectureToCourse", model);
        }

        [HttpPost]
        public IActionResult Assign(AssignLectureToCourseModel model)
        {
            var lecture = model.Lectures.Where(s => s.IsChecked).Select(s => s.Id);
            repository.SetLecturersToCourse(model.Id, lecture);
            return RedirectToAction("Course", "Course");
        }
    }
}