using ADO.NET.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionADO
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Course> courses = new List<Course>();
            DateTime dateTime = DateTime.Now;
            using (SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DemoAdo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"select* from Course where StartDate < startDate";
                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.Value = dateTime;
                sqlParameter.ParameterName = @"startDate";
                command.Parameters.Add(sqlParameter);
                using (SqlDataReader reader =  command.ExecuteReader())
                {                    
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Course course = new Course();
                            course.Id = reader.GetInt32(0);
                            course.Name = reader.GetString(1);
                            course.StartDate = reader.GetDateTime(2);
                            course.EndDate = reader.GetDateTime(3);
                            course.PassCredits = reader.GetInt32(4);
                            courses.Add(course);
                        }

                    }
                    
                }
                
            }
            

           

            Console.ReadLine();


        }
    }
}
