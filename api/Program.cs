using api.Database;
using Api.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Linq;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
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

                //Dummy data if not exists
                if (!dbContext.Projects.Any())
                {
                    dbContext.Projects.AddRange(new Project[]
                        {
                             new Project{ Id="1", Name="Blog 1", Active=true },
                             new Project{ Id="2", Name="Blog 2", Active=true },
                             new Project{ Id="3", Name="Blog 3", Active=true }
                        });
                    dbContext.SaveChanges();
                }
            }

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
