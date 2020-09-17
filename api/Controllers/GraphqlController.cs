using Api.Graphql;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[Route("graphql")]
[ApiController]
public class GraphqlController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
    {
        var schema = new MySchema();
        //var inputs = null;

        var result = await new DocumentExecuter().ExecuteAsync(executionOptions =>
        {
            executionOptions.Schema = schema.GraphQLSchema;
            executionOptions.Query = query.Query;
            executionOptions.OperationName = query.OperationName;
          //executionOptions.Inputs = inputs;
      });

        if (result.Errors?.Count > 0)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}