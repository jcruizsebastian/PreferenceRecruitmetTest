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
            login(userName: String!, password: String): User!
            projects: [Project]
            tasks(projectid: String!): [ProjectTask]
            updatingProjectInfo(projectid: String!): Project!
            updatingUserInfo(userid: String!): User!
            users: [User]
            project(projectid: String!): Project!
        }

        type Project {
            id: String
            name: String
            projectTasks: [ProjectTask]
            projectUsers: [ProjectUser]
        }

        type ProjectTask {
            id: String!
            title: String
            description: String
            severity: TaskSeverity!
            status: TaskStatus!
        }

        type ProjectUser{
            projectid: String!
            userid: String!
            user: User!
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
            id: String!
            userName: String!
            password: String!
            elevated: Boolean
        }

        
      ", _ =>
            {
                _.Types.Include<Query>();
                //_.Types.Include<Mutation>();
            });
        }

    }
}

// #type Mutation{
// #    login(userName: String!, password: String!) : Boolean
// #    addProject(name: String!): Project!
// #    addUser(userName: String!, password: String!): User!
// #    addProjectTask(projectId: ID!, title: String, description: String, severity: TaskSeverity!, status: TaskStatus!): ProjectTask
// #    updateProjectTask(projectTaskId: ID, title: String, description: String, severity: TaskSeverity!, status: TaskStatus!): Boolean!
// #}