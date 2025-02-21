namespace TestHangfire.Services
{
    public class JobTestService : IJobTestService
    {
        private ILogger<JobTestService> _logger;

        public JobTestService(ILogger<JobTestService> logger)
        {
            _logger = logger;
        }

        public void ContinuationJob()
        {
            _logger.LogInformation("Hello from a Continuation job!");
        }

        public void DelayedJob()
        {
            _logger.LogInformation("Hello from a Delayed job!");
        }

        public void FireAndForgetJob()
        {
            _logger.LogInformation("Hello from a Fire and Forget job!");
        }

        public void ReccuringJob()
        {
            Counter.CountVal = Counter.CountVal + 1;
            _logger.LogInformation("Hello from a Scheduled job!");
        }
    }
}
