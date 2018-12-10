using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Access;
using Api.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<Repository>();
            services.Configure<Demo>(configuration.GetSection("Demo"));
        }
         
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc(routes =>
            {                
                routes.MapRoute("Post", "Students", new { controller = "Student", action = "CreateStudent" });
                routes.MapRoute("Put", "Students", new { controller = "Student", action = "CreateStudent" });
                routes.MapRoute("Get", "Students/{id:int}", new { controller = "Student", action = "GetStudentById" });
                routes.MapRoute("Delete", "Students/{id:int}", new { controller = "Student", action = "DeleteStudent" });
                routes.MapRoute("GetCourse", "Courses", new { controller = "Course", action = "GetCourses" });
            });
        }
        
    }
}
