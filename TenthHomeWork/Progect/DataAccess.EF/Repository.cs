using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.EF
{
    public class Repository : IRepository, IDisposable
    {
        private UniversityContext context;

        public Repository(IOptions<RepositoryOptions> options)
        {
            context = new UniversityContext(options);
            context.Database.EnsureCreated();
        }



        public Course CreateCourse(Course course)
        {
            if (course != null)
            {
                context.Course.Add(course);
            }
            SaveChanges();
            return course;
        }

        public List<HomeTask> GetAllHomeTasks()
        {
            return context.HomeTask.ToList();
        }

        public Lecturer GetLecturerById(int id)
        {
            Lecturer student;
            try
            {
                student = context.Lecturer.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                student = new Lecturer();
            }

            return student;
        }

        public void UpdateLecturer(Lecturer lecture)
        {
            context.Lecturer.Update(lecture);
            SaveChanges();
        }

        public List<HomeTask> GetHomeTasksByCourseId(int id)
        {
            List<HomeTask> homeTasks = new List<HomeTask>();
            Course course = GetCourse(id);
            homeTasks.AddRange(course.HomeTasks);
            return homeTasks;
        }

        public void DeleteLecturer(int id)
        {
            var st = GetLecturerById(id);
            context.Lecturer.Remove(st);
            SaveChanges();
        }

        public Lecturer CreateLecturer(Lecturer lecturer)
        {
            if (lecturer != null)
            {
                context.Lecturer.Add(lecturer);
            }
            SaveChanges();
            return lecturer;
        }

        public HomeTask CreateHomeTask(HomeTask homeTask, int courseId)
        {
            if (homeTask != null && courseId > 0)
            {
                var t = GetCourse(courseId);
                homeTask.Course = t;
                context.HomeTask.Add(homeTask);
            }
            SaveChanges();
            return homeTask;
        }

        public void CreateHomeTaskAssessments(List<HomeTaskAssessment> homeTaskHomeTaskAssessments)
        {
            if (homeTaskHomeTaskAssessments != null)
            {
                context.HomeTaskAssessment.AddRange(homeTaskHomeTaskAssessments);
            }
            SaveChanges();
        }

        public Student CreateStudent(Student student)
        {
            if (student != null)
            {
                context.Student.Add(student);
            }
            SaveChanges();
            return student;
        }

        public void DeleteHomeTaskById(int id)
        {
            var st = GetHomeTaskById(id);
            context.HomeTask.Remove(st);
            SaveChanges();
        }

        public void DeleteCourse(int courseId)
        {
            var st = GetCourse(courseId);
            //var del = context.LecturerCourse.Where(p => p.CourseId == courseId).ToList();
            //if (del != null)
            //{
            //    context.LecturerCourse.RemoveRange(del);
            //    context.SaveChanges();
            //}
            context.Course.Remove(st);
            SaveChanges();
        }

        public void DeleteHomeTask(int homeTaskId)
        {
            HomeTask st = GetHomeTaskById(homeTaskId);
            context.HomeTask.Remove(st);
            SaveChanges();
        }

        public void DeleteStudent(int studentId)
        {
            var st = GetStudentById(studentId);
            context.Student.Remove(st);
            SaveChanges();
        }

        public void Dispose()
        {
            ((IDisposable)context).Dispose();
        }

        public List<Lecturer> GetAllLecturers()
        {
            return context.Lecturer.ToList();
        }

        public List<Course> GetAllCourses()
        {
            return context.Course.ToList();
        }

        public List<Student> GetAllStudents()
        {
            return context.Student.ToList();
        }

        public void UpdateHomeTaskAssessment(HomeTaskAssessment homeTaskAssessment)
        {
            var t = context.HomeTaskAssessment.Where(p => p.Id == homeTaskAssessment.Id).FirstOrDefault();
            t.IsComplete = homeTaskAssessment.IsComplete;
            context.HomeTaskAssessment.Update(t);
            SaveChanges();
        }

        public Course GetCourse(int id)
        {
            Course course;
            try
            {
                course = context.Course.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                course = new Course();
            }
            return course;
        }

        public HomeTask GetHomeTaskById(int id)
        {
            HomeTask homeTask;
            try
            {
                homeTask = context.HomeTask.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                homeTask = new HomeTask();
            }

            return homeTask;
        }

        public Student GetStudentById(int id)
        {
            Student student;
            try
            {
                student = context.Student.Where(p => p.Id == id).FirstOrDefault();
            }
            catch (ArgumentNullException)
            {
                student = new Student();
            }

            return student;
        }

        public void SetStudentsToCourse(int courseId, IEnumerable<int> studentsId)
        {
            var remove = context.StudentCourse.Where(p => p.CourseId == courseId).ToList();
            context.StudentCourse.RemoveRange(remove);
            context.SaveChanges();
            List<StudentCourse> studentCourse = new List<StudentCourse>();

            foreach (var studentId in studentsId)
            {
                studentCourse.Add(new StudentCourse { CourseId = courseId, StudentId = studentId });
            }

            context.StudentCourse.AddRange(studentCourse);
            SaveChanges();
        }

        public void GetStudentsByCourse(List<int> coursesId, int studentId)
        {

        }

        public void SetLecturersToCourse(int courseId, IEnumerable<int> lecturerIds)
        {
            var remove = context.LecturerCourse.Where(p => p.CourseId == courseId).ToList();
            context.LecturerCourse.RemoveRange(remove);
            context.SaveChanges();
            List<LecturerCourse> lecturerCourse = new List<LecturerCourse>();
            foreach (var lecturerId in lecturerIds)
            {
                lecturerCourse.Add(new LecturerCourse { CourseId = courseId, LecturerId = lecturerId });
            }

            context.LecturerCourse.AddRange(lecturerCourse);
            SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            var oldCourseForUpdate = GetCourse(course.Id);
            if (oldCourseForUpdate != null && course != null)
            {
                oldCourseForUpdate.Name = course.Name;
                oldCourseForUpdate.EndDate = course.EndDate;
                oldCourseForUpdate.PassCredits = course.PassCredits;
                oldCourseForUpdate.StartDate = course.StartDate;
                context.Course.Update(oldCourseForUpdate);
            }
            SaveChanges();
        }

        public void UpdateHomeTask(HomeTask homeTask)
        {
            //var oldHomeTaskForUpdate = GetHomeTaskById(homeTask.Id);
            //if (oldHomeTaskForUpdate != null && homeTask != null)
            //{
            //    oldHomeTaskForUpdate.Date = homeTask.Date;
            //    oldHomeTaskForUpdate.Description = homeTask.Description;
            //    oldHomeTaskForUpdate.Number = homeTask.Number;
            //    oldHomeTaskForUpdate.Title = homeTask.Title;
            //    context.HomeTask.Update(oldHomeTaskForUpdate);
            //}
            context.HomeTask.Update(homeTask);
            SaveChanges();
        }

        public void UpdateHomeTaskAssessments(List<HomeTaskAssessment> homeTaskHomeTaskAssessments)
        {
            context.HomeTaskAssessment.UpdateRange(homeTaskHomeTaskAssessments);
            SaveChanges();
        }

        public List<HomeTaskAssessment> GetHomeTaskAssessmentsByStudentId(int studentId)
        {
            var homeTaskAssessment = context.HomeTaskAssessment.Where(p => p.Student.Id == studentId).ToList();
            return homeTaskAssessment;
        }

        public void UpdateStudent(Student student)
        {
            var oldStudentForUpdate = GetStudentById(student.Id);
            if (oldStudentForUpdate != null && student != null)
            {
                oldStudentForUpdate.Name = student.Name;
                oldStudentForUpdate.BirthDate = student.BirthDate;
                oldStudentForUpdate.PhoneNumber = student.PhoneNumber;
                oldStudentForUpdate.Email = student.Email;
                oldStudentForUpdate.GitHubLink = student.GitHubLink;
                oldStudentForUpdate.Notes = student.Notes;
                context.Student.Update(oldStudentForUpdate);
            }
            SaveChanges();
        }

        public void SaveChanges()
        {
            context.SaveChanges();
            //Dispose(); ne tre
        }
    }
}

