using api.Database;
using Api.Database;
using GraphQL;
using System.Collections.Generic;

namespace Api.Graphql
{
    public class Query
    {
        private MyDBContext myDBContext;

        public Query()
        {
            myDBContext = new MyDBContext();
        }

        [GraphQLMetadata("projects")]
        public IEnumerable<Project> GetProjects()
        {
            return myDBContext.Projects;
        }
    }
}