using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Access;
using Api.Data;
using CoreMVC.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVC.Controllers
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
            repository.UpdateStudent(student);
            return RedirectToAction("Student");
        }

        [HttpGet]
        public IActionResult Create() //click onlink
        {
            Student student = new Student();
            ViewBag.Action =nameof(Create);
            return View("UpdateStudent", student);
        }

        [HttpPost]
        public IActionResult Create([FromForm] Student student) //click onbutton
        {
            repository.CreateStudent(student);
            return RedirectToAction("Student");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteStudent(id);
            return RedirectToAction("Student");
        }

        [HttpGet] 
        public IActionResult Check(int id)
        {
            ViewBag.Action = nameof(Check);
            List<CheckHomework> model = new List<CheckHomework>();
            ViewBag.studentName = repository.GetStudentById(id).Name;
            List<Course> courseName = repository.GetStudentCourses(id);
            List<HomeTask> hometasks = null;

            foreach (var course in courseName)
            {
                hometasks = repository.GetAllHomeTasks().Where(t => t.Course.Id == course.Id).ToList();
                                
            }

            if(hometasks!=null)
            foreach (var homeTask in hometasks)
            {
                List<CourseCheck> courseCheckList = new List<CourseCheck>();
                var courseCheck = new CourseCheck();
                var homeTaskStudent = homeTask.HomeTaskAssessments.Where(t => t.Student.Id == id).ToList();
                foreach (var item in homeTaskStudent)
                {
                    courseCheck.hometaskName = item.HomeTask.Title;
                    courseCheck.mark = item.IsComplete;
                    courseCheck.HomeTaskAssessmentId = item.Id;
                    courseCheckList.Add(courseCheck);
                }

                if(courseCheckList.Count!=0)
                model.Add(new CheckHomework()
                {
                    courseName = homeTask.Course.Name,
                    courseChecks = courseCheckList
                });
            }

            if (model.Count == 0)
            {
                return RedirectToAction("Student");
            }
            else return View("CheckStudent", model);
        }

        [HttpPost]
        public IActionResult Assign(string name, bool mark, int id)
        {
            var task = repository.GetHomeTaskAssessmentById(id, mark);
            repository.UpdateHomeTaskAssessmentByTask(task);
            return RedirectToAction("Student");
        }
    }
}