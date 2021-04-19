using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourse _course;
        public CourseController(ICourse course)
        {
            _course = course;
        }

        public IActionResult Index()
        {
            return View(_course.GetCourses);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Course model = new Course
            {
                CourseId = 0
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(Course model)
        {
            if (ModelState.IsValid)
            {
                _course.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }
       public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                //Written by Reza: Error Handling
                return NotFound();
            }
            else
            {
                Course model = _course.GetCourse(Id);
                return View(model);
            }
        }
   
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _course.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int? Id)
        {
            return View(_course.GetCourse(Id));
        }
        public IActionResult Edit(int? Id)
        {
            var model = _course.GetCourse(Id);
            return View("Create", model);
        }


    }
}
