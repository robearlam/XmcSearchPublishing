using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using XmcSearchPublishing.Models;
using XmcSearchPublishing.SearchIndexUpdate.Edge;
using XmcSearchPublishing.SearchIndexUpdate.Models;

namespace XmcSearchPublishing
{
    public class XmcPublishTrigger
    {
        private readonly IEdgeDataRetriever edgeDataRetriever;

        public XmcPublishTrigger(IEdgeDataRetriever edgeDataRetriever)
        {
            this.edgeDataRetriever = edgeDataRetriever;
        }

        [Function(nameof(XmcPublishTrigger))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
            [FromBody] PublishEvent publishEvent,
            FunctionContext executionContext)
        {
            var sw = new Stopwatch();
            sw.Restart();

            if (publishEvent?.PublisherOptions == null)
                throw new HttpRequestException("XmcPublishTrigger: Publish Item information not included");

            var logger = executionContext.GetLogger("XmcSearchPublishing.XmcPublishTrigger");
            logger.LogInformation($"XmcPublishTrigger: Starting Processing Publish:End event for rootItemId:{publishEvent.PublisherOptions.RootItemId}");

            var edgeData = await edgeDataRetriever.GetEdgeData(publishEvent.PublisherOptions.RootItemId, publishEvent.PublisherOptions.Deep);
            if (edgeData?.Item?.Rendered != null)
                ProcessRenderedLayoutData(edgeData, logger);
            else
                logger.LogInformation($"XmcPublishTrigger: Processing stopped, no layout data returned from Experience Edge");

            var timeRun = sw.Elapsed.TotalMilliseconds;
            logger.LogInformation($"Function execution finished in: {timeRun}ms");

            var response = req.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private void ProcessRenderedLayoutData(EdgeData edgeData, ILogger logger)
        {
            logger.LogInformation($"XmcPublishTrigger: Processing layout data received from Experience Edge");
        }
    }
}