using Microsoft.AspNetCore.Mvc;
using Assignment10.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Components
{
    public class TeamFilterViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;
        public TeamFilterViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
        }


        public IViewComponentResult Invoke()
        {


            return View(context.Teams
            .Distinct()
            .OrderBy(x=>x));
        }
    }
}
