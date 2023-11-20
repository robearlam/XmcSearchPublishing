using GraphQL.Client.Http;
using GraphQL.Client.Serializer.SystemTextJson;
using GraphQL;
using System;
using System.Threading.Tasks;
using XmcSearchPublishing.SearchIndexUpdate.Models;

namespace XmcSearchPublishing.SearchIndexUpdate.Edge
{
    public class EdgeDataRetriever : IEdgeDataRetriever
    {
        public async Task<EdgeData> GetEdgeData(Guid rootItemId, bool deep)
        {
            var edgeToken = Environment.GetEnvironmentVariable("EDGE-TOKEN", EnvironmentVariableTarget.Process);

            var graphQLClient = new GraphQLHttpClient("https://edge.sitecorecloud.io/api/graphql/v1", new SystemTextJsonSerializer());
            graphQLClient.HttpClient.DefaultRequestHeaders.Add("X-GQL-Token", edgeToken);

            var getRenderedContent = new GraphQLRequest
            {
                Query = $@"
                    query {{
                        item(path: ""{rootItemId}"", language: ""en"") {{
                        rendered
                        }}
                    }}"
            };

            var graphQLResponse = await graphQLClient.SendQueryAsync<EdgeData>(getRenderedContent);
            return graphQLResponse.Data;
        }

        private static string GetEnvironmentVariable(string name)
        {
            return Environment.GetEnvironmentVariable(name, EnvironmentVariableTarget.Process);
        }
    }
}
