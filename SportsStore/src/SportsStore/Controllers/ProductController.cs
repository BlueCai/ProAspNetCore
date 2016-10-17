using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 8;

        public ProductController(IProductRepository repo)
        {
            this.repository = repo;
        }
        // GET: /<controller>/
        public IActionResult List(string category, int page = 1)
        {
            var result = new ProductsListViewModel
            {
                Products = repository.Products
                    .Where(p => string.IsNullOrWhiteSpace(category) || p.Category.ToLower() == category.ToLower())
                    .OrderBy(c => c.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo { CurrentPage = page, ItemsPerPage = PageSize, TotalItems = repository.Products.Count() },
                CurrentCategory = category
            };
            return View(result);
        }
    }
}
