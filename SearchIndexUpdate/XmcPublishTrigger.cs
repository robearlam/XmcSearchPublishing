using System.Diagnostics;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using XmcSearchPublishing.Models;

namespace XmcSearchPublishing
{
    public static class XmcPublishTrigger
    {
        [Function(nameof(XmcPublishTrigger))]
        public static HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequestData req,
            [FromBody] PublishEvent publishEvent,
            FunctionContext executionContext)
        {
            var sw = new Stopwatch();
            sw.Restart();

            var logger = executionContext.GetLogger("XmcSearchPublishing.XmcPublishTrigger");
            logger.LogInformation("Message logged");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.WriteString("Hello world!");

            var timeRun = sw.Elapsed.TotalMilliseconds;
            logger.LogInformation($"Function execution finished in: {timeRun}ms");

            return response;
        }
    }
}