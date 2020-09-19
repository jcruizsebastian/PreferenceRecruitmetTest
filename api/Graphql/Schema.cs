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
            tasks(projectid: Int!): [ProjectTask]
            updatingProjectInfo(projectid: Int!): Project!
            updatingUserInfo(userid: Int!): User!
            users: [User]
            project(projectid: Int!): Project!
        }

        type Mutation {
            createUser(userName: String!, password: String!): User!
            udpateUser(userid: Int!, userName: String!, password: String!): User!
            createProject(name: String!, usersId: [Int]): Project!
            updateProject(projectId: Int!, name: String!, usersId: [Int]): Project!
        }

        type Project {
            id: Int
            name: String
            projectTasks: [ProjectTask]
            projectUsers: [ProjectUser]
        }

        type ProjectTask {
            id: Int!
            title: String
            description: String
            severity: TaskSeverity!
            status: TaskStatus!
        }

        type ProjectUser{
            projectid: Int!
            userid: Int!
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
            id: Int!
            userName: String!
            password: String!
            elevated: Boolean
        }
        ", _ =>
            {
                _.Types.Include<Query>();
                _.Types.Include<Mutation>();
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