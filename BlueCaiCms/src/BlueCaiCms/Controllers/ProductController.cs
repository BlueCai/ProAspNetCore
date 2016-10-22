using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlueCaiCms.Data.Dapper.Repositories;
using BlueCaiCms.Data.Dapper.Models;

namespace BlueCaiCms.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository repository)
        {
            productRepository = repository;
        }


        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return productRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Product Get(int Id)
        {
            return productRepository.GetByID(Id);
        }

        [HttpPost]
        public void Post([FromBody]Product prod)
        {
            if (ModelState.IsValid)
            {
                productRepository.Add(prod);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
            {
                productRepository.Update(prod);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productRepository.Delete(id);
        }
    }
}