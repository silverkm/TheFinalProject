using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollment _enrollment;
        private readonly ICourse _course;
        private readonly IStudent _student;
        public EnrollmentController(IEnrollment enrollment, ICourse course, IStudent student)
        {
            _enrollment = enrollment;
            _course = course;
            _student = student;
        }
        public IActionResult Index()
        {
            return View(_enrollment.GetEnrollments);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Courses = _course.GetCourses;
            ViewBag.Students = _student.GetStudents;
            Enrollment model = new Enrollment
            {
                EnrollmentId = 0
            };
            return View(model);
        }
        [HttpPost]

        public IActionResult Create(Enrollment model)
        {
            if (ModelState.IsValid)
            {
                _enrollment.Add(model);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            Enrollment model = _enrollment.GetEnrollment(Id);
            return View(model);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _enrollment.Remove(Id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            ViewBag.Courses = _course.GetCourses;
            ViewBag.StudentName = _student.GetStudent(_enrollment.GetEnrollment(Id).StudentId).FullName;
            return View(_enrollment.GetEnrollment(Id));
        }
        [HttpPost]
        public IActionResult Edit(Enrollment model)
        {
            if (ModelState.IsValid)
            {
                _enrollment.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }

}