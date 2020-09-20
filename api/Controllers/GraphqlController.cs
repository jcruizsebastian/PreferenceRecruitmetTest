using Api.Graphql;
using GraphQL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Linq;

[Route("graphql")]
[ApiController]
public class GraphqlController : ControllerBase
{
    private readonly ILogger<GraphqlController> _logger;

    public GraphqlController(ILogger<GraphqlController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] GraphQLQuery query)
    {
        var schema = new MySchema();

        var result = await new DocumentExecuter().ExecuteAsync(executionOptions =>
        {
            executionOptions.Schema = schema.GraphQLSchema;
            executionOptions.Query = query.Query;
            executionOptions.OperationName = query.OperationName;
        });

        if (result.Errors?.Count > 0)
        {
            result.Errors.ToList().ForEach(error => _logger.LogWarning($"{query.OperationName} with {query.Query} faulted by {error.Message}"));

            return BadRequest();
        }

        return Ok(result);
    }
}