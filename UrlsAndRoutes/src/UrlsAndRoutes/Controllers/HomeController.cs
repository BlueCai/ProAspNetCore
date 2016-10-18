using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlsAndRoutes.Models;

namespace UrlsAndRoutes.Controllers
{
    public class HomeController : Controller
    {

        public ViewResult Index()
        {
            var result = new Result { Controller = nameof(HomeController), Action = nameof(Index) };
            return View("Result", result);
        }

        public ViewResult List() => View("Result", new Result { Controller = nameof(Controller), Action = nameof(List) });
    }
}
