using GraphQL.Types;

namespace Api.Graphql
{
    public class MySchema
    {
        private ISchema _schema { get; set; }
        public ISchema GraphQLSchema
        {
            get
            {
                return this._schema;
            }
        }

        public MySchema()
        {
            this._schema = Schema.For(@"
        type Query {
            projects: [Project]
            project(projectid: ID!): Project!
        }

        type Project {
            id: ID
            name: String
            active: Boolean
            ProjectTasks: [ProjectTask]
            Users: [User]
        }

        type ProjectTask {
            id: ID!
            title: String
            description: String
            severity: TaskSeverity!
            status: TaskStatus!

        }

        enum TaskStatus {
            TODO
            DOING
            DONE
        }

        enum TaskSeverity {
            HIGH
            MEDIUM
            LOW
        }

        type User {
            id: ID!
            userName: String!
            password: String!
        }
      ", _ =>
      {
          _.Types.Include<Query>();
          //_.Types.Include<Mutation>();
      });
        }

    }
}