using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SerilogDemoApp.Models;

namespace SerilogDemoApp.Controllers
{
        public class HomeController : Controller

        {

            private readonly ILogger<HomeController> _logger;

            public HomeController(ILogger<HomeController> logger)

            {

                _logger = logger;

            }

            public IActionResult Index()

            {

                _logger.LogInformation("Accessed the Home page.");

                return View();

            }

            public IActionResult Privacy()

            {

                _logger.LogInformation($"Privacy page accessed");

                return View();

            }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

            public IActionResult Error()

            {

                _logger.LogError("An error occurred.");

                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            }

        }

    }


