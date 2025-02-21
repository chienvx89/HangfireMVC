using System.Diagnostics;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using TestHangfire.Models;
using TestHangfire.Services;

namespace TestHangfire.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IJobTestService _jobTestService;
        private readonly IBackgroundJobClient _backgroundJobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public HomeController(ILogger<HomeController> logger,IJobTestService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
        {
            _logger = logger;
            _jobTestService = jobTestService;
            _backgroundJobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("App start!");
            
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult Test()
        {
            _logger.LogInformation($"click at {DateTime.Now:F}");
            return new EmptyResult();
        }

        public ActionResult CreateFireAndForgetJob()
        {
            _backgroundJobClient.Enqueue(() => _jobTestService.FireAndForgetJob());
            return Ok();
        }
        public ActionResult CreateDelayedJob()
        {
            _backgroundJobClient.Schedule(() => _jobTestService.DelayedJob(), TimeSpan.FromSeconds(60));
            return Ok();
        }
        public ActionResult CreateReccuringJob()
        {
            _logger.LogInformation($"CreateReccuringJob at {DateTime.Now:F}");
            _recurringJobManager.AddOrUpdate("jobId", () => _jobTestService.ReccuringJob(), Cron.Minutely,new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });
            return Ok();
        }

    }
}
