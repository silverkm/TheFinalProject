using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        private readonly IGender _gender;
        public StudentController(IStudent student, IGender gender)
        {
            _student = student;
            _gender = gender;
        }
        public IActionResult Index()
        {
            return View(_student.GetStudents);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Genders = _gender.GetGenders;
            Student model = new Student
            {
                StudentId = 0
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(Student model)
        {
            if (ModelState.IsValid)
            {
                _student.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            Student model = _student.GetStudent(Id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _student.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_student.GetStudent(Id));
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            ViewBag.Genders = _gender.GetGenders;
            return View(_student.GetStudent(Id));
        }
        [HttpPost]
        public IActionResult Edit(Student model)
        {
            if (ModelState.IsValid)
            {
                _student.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}
