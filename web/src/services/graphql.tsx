import { ApolloClient, InMemoryCache, gql } from '@apollo/client';

const client = new ApolloClient({
    uri: 'http://localhost:5000/graphql',
    cache: new InMemoryCache()
  });

export function ExecuteQuery(query: string)
{
  return client.query({query: gql`${query}`});
}

