using System;

namespace XmcSearchPublishing.Models
{
    public class PublishEvent
    {
        public string EventName { get; set; }
        public Guid WebhookItemId { get; set; }
        public PublisherOptions PublisherOptions { get; set; }
        public string WebhookItemName { get; set; }
    }
}
