using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConfigurationApps.Infrastructure;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ConfigurationApps.Controllers
{
    public class HomeController : Controller
    {

        private UptimeService uptime;

        public HomeController(UptimeService up)
        {
            uptime = up;
        }

        public IActionResult Index()
        {
            return View(new Dictionary<string, string> {
                ["Message"] = "This is the Index action",
                ["Uptime"] = $"{uptime.Uptime}ms"

            });
        }
    }
}
