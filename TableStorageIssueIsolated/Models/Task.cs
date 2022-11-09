using Azure;
using Azure.Data.Tables;

namespace TableStorageIssueIsolated.Models
{
    public class Task : ITableEntity
    {
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string Value { get; set; }
        public DateTimeOffset? DateCompleted { get; set; }
    }
}
