using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Access;
using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Api.Controllers
{
    public class StudentController : ControllerBase
    {
        private readonly Repository repository;

        public StudentController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = repository.GetStudentById(id);
            if (student==null)
            {
                return BadRequest();
            }

            return student;
        }

        [HttpDelete]
        public void DeleteStudent(int id)
        {
            repository.DeleteStudent(id);
        }

        [HttpPost]
        public void CreateStudent([FromBody]Student student)
        {
            repository.CreateStudent(student);
        }

        [HttpPut]
        public void UpdateStudent([FromBody]Student student) 
        {
            repository.UpdateStudent(student);
        }
       
    }
}