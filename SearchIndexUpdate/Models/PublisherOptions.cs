using System;

namespace XmcSearchPublishing.Models
{
    public class PublisherOptions
    {
        public bool CompareRevisions { get; set; }
        public bool Deep { get; set; }
        public DateTime FromDate { get; set; }
        public string Mode { get; set; }
        public DateTime PublishDate { get; set; }
        public bool RepublishAll { get; set; }
        public Guid RecoveryId { get; set; }
        public string SourceDatabaseName { get; set; }
        public string TargetDatabaseName { get; set; }
        public Guid RootItemId { get; set; }
        public string UserName { get; set; }
        public bool WillBeQueued { get; set; }
        public string[] Languages { get; set; }
    }
}
