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
        public IActionResult Add(Student student)
        {
            _service.Add(student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid id)
        {
            var student = _service.GetStudentById(id);
            return View(student);
        }


        [HttpPost]
        public IActionResult Edit(Student student)
        {
            var result = _service.Edit(student);
            return RedirectToAction("index");
        }

        public IActionResult Delete(Guid id)
        {
            var result = _service.Delete(id);
            return RedirectToAction("index");
        }
    }
}