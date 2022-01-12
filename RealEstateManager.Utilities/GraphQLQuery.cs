using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RealEstateManager.Utilities
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        //public Dictionary<string, Object?> Variables { get; set; }
        public JObject Variables { get; set; }
        // The JObject does not contain ToInputs method
    }
}
