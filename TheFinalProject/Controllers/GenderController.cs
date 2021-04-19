using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheFinalProject.Models;
using TheFinalProject.Services;

namespace TheFinalProject.Controllers
{
    public class GenderController : Controller
    {
        private readonly IGender _gender;
        public GenderController(IGender gender)
        {
            _gender = gender;
        }
        public IActionResult Index()
        {
            return View(_gender.GetGenders);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Gender model)
        {
            if (ModelState.IsValid)
            {
                _gender.Add(model);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            else
            {
                Gender model = _gender.GetGender(Id);
                return View(model);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int? Id)
        {
            _gender.Remove(Id);
            return RedirectToAction("Index");
        }
    }

}
