using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.Access;
using Api.Data;

namespace CoreMVC.Controllers
{
    public class HomeTaskController : Controller
    {
        private readonly Repository repository;

        public HomeTaskController(Repository repository)
        {
            this.repository = repository;
        }

        public IActionResult HomeTask()
        {
            var homeTask = repository.GetAllHomeTasks();
            return this.View(homeTask);
        }

        [HttpGet]
        public IActionResult UpdateHomeTask(int id) //click onlink
        {
            ViewBag.Action = nameof(UpdateHomeTask);
            ViewBag.Id = id;
            var hometask = repository.GetHomeTasksByCourseId(id);
            return View("HomeTask", hometask);
        }

        [HttpPost]
        public IActionResult UpdateHomeTask([FromForm] HomeTask homeTask) //click onbutton
        {
            repository.UpdateHomeTask(homeTask);
            return RedirectToAction("Course", "Course");
        }

        [HttpGet]
        public IActionResult Create(int id) //click onlink
        {
            HomeTask homeTask = new HomeTask();
            ViewBag.Action = nameof(Create);
            ViewBag.Id = id;
            return View("UpdateHomeTask", homeTask);
        }

        [HttpPost]
        public IActionResult Create([FromForm] HomeTask homeTask, [FromForm]int id) //click onbutton
        {
            repository.CreateHomeTask(homeTask, id);
            return RedirectToAction("Course", "Course");
        }

        public IActionResult Delete(int id)
        {
            repository.DeleteHomeTaskById(id);
            return RedirectToAction("Course","Course");
        }
    }
}