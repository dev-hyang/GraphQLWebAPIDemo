using Microsoft.AspNetCore.Mvc;
using RealEstateManager.Utilities;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using System.IO;
using Newtonsoft.Json;
using GraphQL.NewtonsoftJson;

namespace GraphQLWebAPIDemo.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _docExecuter;
        public GraphQLController(ISchema schema,
            IDocumentExecuter docExecuter)
        {
            _schema = schema;
            _docExecuter = docExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            //parse the Variables from body
            var inputs = query.Variables?.ToInputs();

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                OperationName = query.OperationName,
                Inputs = inputs
            };

            var result = await _docExecuter.ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
