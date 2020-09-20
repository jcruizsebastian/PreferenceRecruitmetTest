using api.Database;
using Api.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;
using Microsoft.Extensions.Logging;
using System;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLog.Web.NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            logger.Debug("init main");

            try
            {
                CreateDataBase();
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception exception)
            {
                //NLog: catch setup errors
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        private static void CreateDataBase()
        {
            string dbName = "TestDatabase.db";
            if (File.Exists(dbName))
            {
                File.Delete(dbName);
            }

            using (var dbContext = new MyDBContext())
            {
                //Ensure database is created
                dbContext.Database.EnsureCreated();
                AddDummyData(dbContext);
            }
        }

        private static void AddDummyData(MyDBContext dbContext)
        {
            ////Dummy data if not exists
            //if (!dbContext.Users.Any())
            //{
            //    dbContext.Users.AddRange(new User[]
            //    {
            //            new User { Id="1", UserName="admin", Password="admin", Elevated=true },
            //            new User { Id="2", UserName="user1", Password="user1", Elevated=false },
            //            new User { Id="3", UserName="user2", Password="user2", Elevated=false },
            //            new User { Id="4", UserName="user3", Password="user3", Elevated=false }
            //    });
            //    dbContext.SaveChanges();
            //}

            if (!dbContext.ProjectUsers.Any())
            {

                var userAdmin = new User { Id = 1, UserName = "admin", Password = "admin", Elevated = true };
                var user1 = new User { Id = 2, UserName = "user1", Password = "user1", Elevated = false };
                var user2 = new User { Id = 3, UserName = "user2", Password = "user2", Elevated = false };
                var user3 = new User { Id = 4, UserName = "user3", Password = "user3", Elevated = false };

                ICollection<ProjectTask> tasksProject1 = new List<ProjectTask>(){
                        { new ProjectTask () { Id = 1, Title = "Task1", Description = "Description1", Severity = ProjectTask.TaskSeverity.HIGH, Status = ProjectTask.TaskStatus.DONE } },
                        { new ProjectTask () { Id = 2, Title = "Task2", Description = "Description2", Severity = ProjectTask.TaskSeverity.MEDIUM, Status = ProjectTask.TaskStatus.DOING } },
                        { new ProjectTask () { Id = 3, Title = "Task3", Description = "Description3", Severity = ProjectTask.TaskSeverity.LOW, Status = ProjectTask.TaskStatus.DOING } }
                    };

                ICollection<ProjectTask> tasksProject2 = new List<ProjectTask>(){
                        { new ProjectTask () { Id = 4, Title = "Task4", Description = "Description4", Severity = ProjectTask.TaskSeverity.MEDIUM, Status = ProjectTask.TaskStatus.DONE } },
                        { new ProjectTask () { Id = 5, Title = "Task5", Description = "Description5", Severity = ProjectTask.TaskSeverity.MEDIUM, Status = ProjectTask.TaskStatus.TODO } }
                    };

                ICollection<ProjectTask> tasksProject3 = new List<ProjectTask>(){
                        { new ProjectTask () { Id = 6, Title = "Task6", Description = "Description6", Severity = ProjectTask.TaskSeverity.HIGH, Status = ProjectTask.TaskStatus.DONE } },
                        { new ProjectTask () { Id = 7, Title = "Task7", Description = "Description7", Severity = ProjectTask.TaskSeverity.HIGH, Status = ProjectTask.TaskStatus.DOING } },
                        { new ProjectTask () { Id = 8, Title = "Task8", Description = "Description8", Severity = ProjectTask.TaskSeverity.HIGH, Status = ProjectTask.TaskStatus.DOING } },
                        { new ProjectTask () { Id = 9, Title = "Task9", Description = "Description9", Severity = ProjectTask.TaskSeverity.MEDIUM, Status = ProjectTask.TaskStatus.DOING } },
                        { new ProjectTask () { Id = 10, Title = "Task10", Description = "Description10", Severity = ProjectTask.TaskSeverity.LOW, Status = ProjectTask.TaskStatus.TODO } },
                        { new ProjectTask () { Id = 11, Title = "Task11", Description = "Description11", Severity = ProjectTask.TaskSeverity.LOW, Status = ProjectTask.TaskStatus.TODO } },
                        { new ProjectTask () { Id = 12, Title = "Task12", Description = "Description12", Severity = ProjectTask.TaskSeverity.LOW, Status = ProjectTask.TaskStatus.TODO } }
                    };

                var project1 = new Project { Id = 1, Name = "Project1", Tasks = tasksProject1 };
                var project2 = new Project { Id = 2, Name = "Project2", Tasks = tasksProject2 };
                var project3 = new Project { Id = 3, Name = "Project3", Tasks = tasksProject3 };

                dbContext.ProjectUsers.AddRange(new ProjectUser[]
                {
                    new ProjectUser { UserId = userAdmin.Id, User = userAdmin, ProjectId = project1.Id, Project = project1 },
                    new ProjectUser { UserId = userAdmin.Id, User = userAdmin, ProjectId = project2.Id, Project = project2 },
                    new ProjectUser { UserId = userAdmin.Id, User = userAdmin, ProjectId = project3.Id, Project = project3 },

                    new ProjectUser { UserId = user1.Id, User = user1, ProjectId = project1.Id, Project = project1 },

                    new ProjectUser { UserId = user2.Id, User = user2, ProjectId = project1.Id, Project = project1 },
                    new ProjectUser { UserId = user2.Id, User = user2, ProjectId = project2.Id, Project = project2 },

                    new ProjectUser { UserId = user3.Id, User = user3, ProjectId = project1.Id, Project = project1 },
                    new ProjectUser { UserId = user3.Id, User = user3, ProjectId = project2.Id, Project = project2 },
                    new ProjectUser { UserId = user3.Id, User = user3, ProjectId = project3.Id, Project = project3 },

                });

                dbContext.SaveChanges();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();
    }
}
