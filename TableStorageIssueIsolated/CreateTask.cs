using System.Text.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using TableStorageIssueIsolated.Request;
using Task = TableStorageIssueIsolated.Models.Task;

namespace TableStorageIssueIsolated
{
    public class CreateTask
    {
        private readonly ILogger _logger;

        public CreateTask(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<CreateTask>();
        }

        [Function("CreateTask")]
        [TableOutput("TaskTable")]
        public async Task<Task> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            var request = await JsonSerializer.DeserializeAsync<CreateTaskRequest>(req.Body);

            var entity = new Task
            {
                PartitionKey = "*",
                RowKey = Guid.NewGuid().ToString(),
                Value = request.Value
            };

            return entity;
        }
    }
}
