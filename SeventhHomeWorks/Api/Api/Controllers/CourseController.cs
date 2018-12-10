using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Access;
using Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class CourseController : Controller
    {
        private readonly Repository repository;

        public CourseController(Repository repository)
        {
            this.repository = repository;
        }
       
        [HttpGet]
        public List<Course> GetCourses()
        {
            return repository.GetAllCourses();
        }
    }
}