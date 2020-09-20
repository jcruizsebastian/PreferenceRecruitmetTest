using api.Database;
using Api.Database;
using GraphQL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Api.Graphql
{
    public class Query
    {
        private MyDBContext myDBContext;

        public Query()
        {
            myDBContext = new MyDBContext();
        }

        [GraphQLMetadata("login")]
        public User login(string userName, string password)
        {
            return myDBContext.Users.First(x => x.UserName == userName && x.Password == password);
        }

        [GraphQLMetadata("projects")]
        public IEnumerable<Project> GetProjects()
        {
            return myDBContext.Projects;
        }

        [GraphQLMetadata("updatingProjectInfo")]
        public Project GetUpdatingProjectInfo(int projectid)
        {
            return myDBContext.Projects.Include(x => x.ProjectUsers).ThenInclude(y => y.User).First(y => y.Id == projectid);
        }

        [GraphQLMetadata("updatingUserInfo")]
        public User GetUser(int userid)
        {
            return myDBContext.Users.First(x => x.Id == userid && !x.Elevated);
        }

        [GraphQLMetadata("users")]
        public IEnumerable<User> GetUsers()
        {
            return myDBContext.Users.Where(x => !x.Elevated);
        }

        [GraphQLMetadata("tasks")]
        public IEnumerable<ProjectTask> GetTasks(int projectid)
        {
            return myDBContext.Projects.Include(y => y.Tasks).First(x => x.Id == projectid).Tasks;
        }
    }
}