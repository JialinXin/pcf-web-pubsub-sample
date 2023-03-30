using Azure.Messaging.WebPubSub;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System;

namespace FunctionPA
{
    public static class APHelper
    {
        [FunctionName("negotiate")]
        public static string GetClientConnection(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
        {
            Console.WriteLine("login");
            var client = new WebPubSubServiceClient("<web-pubsub-connection-string>", "synchub");
            var connection = client.GetClientAccessUri(roles: new string[] { "webpubsub.sendToGroup.pa", "webpubsub.joinLeaveGroup.pa" }).AbsoluteUri;
            return connection;
        }
    }
}
