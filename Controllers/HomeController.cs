using Assignment10.Models;
using Assignment10.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }


        public IActionResult Index(long? teamId, string teamName = "Home", int pageNum = 0)
        {
            ViewBag.teamName = teamName;

            int pageSize = 5;

            return View(new IndexViewModel
            {
                bowlers = (context.Bowlers
                .Where(m => m.TeamId == teamId || teamId == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    numItemsPerPage = pageSize,
                    currentPage = pageNum,

                    // if no team has been selected, get the full count, otherwise count from selected team
                    totalNumItems = (teamId == null ? context.Bowlers.Count() : 
                    context.Bowlers.Where(x => x.TeamId == teamId).Count())

                },

                TeamNameId = teamName

            });
                
                
                
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
