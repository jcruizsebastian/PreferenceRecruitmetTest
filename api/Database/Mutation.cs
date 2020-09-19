using api.Database;
using Api.Database;
using GraphQL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.Graphql
{
    [GraphQLMetadata("Mutation")]
    public class Mutation
    {
        private MyDBContext myDBContext;

        public Mutation()
        {
            myDBContext = new MyDBContext();
        }

        [GraphQLMetadata("createUser")]
        public User CreateUser(string userName, string password)
        {
            var newUser = new User() {UserName = userName, Password = password, Elevated = false};
            myDBContext.Users.Add(newUser);
            myDBContext.SaveChanges();

            return newUser;
        }

        [GraphQLMetadata("udpateUser")]
        public User UpdateUser(int userid, string userName, string password)
        {
            var updatingUser = myDBContext.Users.Single(x => x.Id == userid);
            updatingUser.UserName = userName;
            updatingUser.Password = password;

            myDBContext.Users.Update(updatingUser);
            myDBContext.SaveChanges();

            return updatingUser;
        }

        [GraphQLMetadata("createProject")]
        public Project CreateProject(string name, ICollection<int> usersId)
        {
            Project newProject = new Project() { Name = name };
            myDBContext.Projects.Add(newProject);
            myDBContext.SaveChanges();

            ReplaceUsersInProject(newProject, usersId);

            return newProject;
        }

        private void ReplaceUsersInProject(Project project, ICollection<int> usersId)
        {
            if (usersId != null)
            {
                myDBContext.Entry(project).Collection(x => x.ProjectUsers).Load();

                myDBContext.Entry(project.ProjectUsers).State = EntityState.Deleted;

                var projectUsers = new List<ProjectUser>();
                foreach (int userId in usersId)
                {
                    projectUsers.Add(new ProjectUser() { Project = project, ProjectId = project.Id, User = myDBContext.Users.Single(x => x.Id == userId), UserId = userId });
                }

                myDBContext.ProjectUsers.AddRange(projectUsers);
                myDBContext.SaveChanges();
            }
        }

        [GraphQLMetadata("updateProject")]
        public Project UpdateProject(int projectId, string name, ICollection<int> usersId)
        {
            var project = myDBContext.Projects.Single(x => x.Id == projectId);
            project.Name = name;

            ReplaceUsersInProject(project, usersId);

            return project;
        }
    }
}