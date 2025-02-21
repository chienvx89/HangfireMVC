using Hangfire;
using TestHangfire.Controllers;
using TestHangfire.Services;

namespace TestHangfire
{
    public class InitJob: BackgroundService
    {
        private readonly ILogger<InitJob> _logger;
        private readonly IJobTestService _jobTestService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public InitJob(ILogger<InitJob> logger, IJobTestService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _logger = logger;
            _jobTestService = jobTestService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }
      
        protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
            _logger.LogInformation($" BackgroundService CreateReccuringJob at {DateTime.Now:F}");
            _recurringJobManager.AddOrUpdate("jobId", () => _jobTestService.ReccuringJob(), Cron.Minutely, new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });
        }


      
    }
}
