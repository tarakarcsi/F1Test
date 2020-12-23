using F1Test.Interfaces;
using F1Test.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace F1Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITeamSvc teamSvc;

        public HomeController(ILogger<HomeController> logger, ITeamSvc teamSvc)
        {
            _logger = logger;
            this.teamSvc = teamSvc;
        }

        public IActionResult Index()
        {
            var model = new Team();

            return View(model);
        }

        public List<Team> GetTeamsGridData()
        {
            return teamSvc.LoadTeams();
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
    }
}
