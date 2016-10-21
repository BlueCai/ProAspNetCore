using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlueCaiCms.BLL;
using BlueCaiCms.Model;

namespace BlueCaiCms.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public string Add(Student student)
        {
            _service.Add(student);
            return "success";
        }
    }
}