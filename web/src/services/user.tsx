import { ExecuteQuery } from './graphql'
import * as Queries from './graphql.constants'

export function login(username: string, password: string) {
    let query = Queries.query_login(username, password);
    return ExecuteQuery(query);
}

