using Castle.DynamicProxy.Generators;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory.ValueGeneration.Internal;
using Microsoft.Extensions.Options;
using Models.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.EF
{
    public class UniversityContext: DbContext
    {
        private readonly IOptions<RepositoryOptions> options;
        

        public UniversityContext(IOptions<RepositoryOptions> options)
        {
            this.options = options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(options.Value.ConnectionString);
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //          STUDENT
            modelBuilder.Entity<Student>().HasMany(p => p.HomeTaskAssessments).WithOne(p=>p.Student);
            modelBuilder.Entity<StudentCourse>().HasKey(p => new { p.StudentId, p.CourseId });
            modelBuilder.Entity<StudentCourse>().HasOne(pt => pt.Student).WithMany(p => p.Courses).HasForeignKey(pt => pt.StudentId);
            modelBuilder.Entity<StudentCourse>().HasOne(pt => pt.Course).WithMany(p => p.Students).HasForeignKey(pt => pt.CourseId);

            //          COURSE
            modelBuilder.Entity<Course>().HasMany(p => p.HomeTasks).WithOne(p => p.Course).IsRequired();
            modelBuilder.Entity<LecturerCourse>().HasKey(p => new { p.CourseId, p.LecturerId });
            modelBuilder.Entity<LecturerCourse>().HasOne(p => p.Lecturer).WithMany(p => p.Courses).HasForeignKey(p => p.LecturerId);
            modelBuilder.Entity<LecturerCourse>().HasOne(p => p.Course).WithMany(p => p.Lecturers).HasForeignKey(p => p.CourseId);

            //          HOMETASK
            modelBuilder.Entity<HomeTask>().HasMany(p => p.HomeTaskAssessments).WithOne(p => p.HomeTask);

            //          HOMETASKASSESSMENT

            //          LECTURER

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<HomeTask> HomeTask { get; set; }
        public DbSet<Lecturer> Lecturer { get; set; }
        public DbSet<HomeTaskAssessment> HomeTaskAssessment { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<LecturerCourse> LecturerCourse { get; set; }        

    }
}