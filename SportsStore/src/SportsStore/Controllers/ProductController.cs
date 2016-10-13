using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }
        // GET: /<controller>/
        public IActionResult Index(int page = 1)
        {
            return View(repository.Products.OrderBy(p=>p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
        }
    }
}
