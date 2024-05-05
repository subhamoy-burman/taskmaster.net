namespace TaskScheduler.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _services;


        public Worker(ILogger<Worker> logger, IServiceProvider services)
        {
            _logger = logger;
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                }
                using (var scope = _services.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<TaskSchedulerDbContext>();

                    // Fetch tasks that are eligible for execution
                    var tasks = dbContext.Tasks_Schedules
                    .Where(t => t.ScheduledAt <= DateTime.UtcNow.AddSeconds(30) && t.PickedAt == null && t.Status == "Scheduled")
                    .ToList();


                    foreach (var task in tasks)
                    {
                        // Update task status
                        task.PickedAt = DateTime.UtcNow;
                        task.Status = "In Progress";
                        dbContext.Tasks_Schedules.Update(task);

                        // Push task to Kafka queue
                        // ...
                    }

                    await dbContext.SaveChangesAsync();
                }

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
