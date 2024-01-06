using Labolatorium_3.Models;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Labolatorium_3.Controllers
{
    public class PostController : Controller
    {
        public class CarController : Controller
        {
            private readonly IPost _ipost;

            public CarController(IPost ipost)
            {
                _ipost = ipost;
            }

            public IActionResult Index()
            {
                return View(_ipost.FindAll());
            }

            [HttpGet]
            public IActionResult CreateCar()
            {
                return View();
            }

            [HttpPost]
            public IActionResult CreateCar(Models.Post post)
            {
                if (ModelState.IsValid)
                {
                    _ipost.Add(post);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

            [HttpGet]
            public IActionResult EditCar(int id)
            {
                if (_ipost.FindById(id) is not null)
                {
                    return View(_ipost.FindById(id));
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public IActionResult EditCar(Post post)
            {
                if (ModelState.IsValid)
                {
                    _ipost.Update(post);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }

            [HttpGet]
            public IActionResult DeleteCar(int id)
            {
                if (_ipost.FindById(id) is not null)
                {
                    return View(_ipost.FindById(id));
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public IActionResult Delete(int id)
            {
                _ipost.Delete(id);
                return RedirectToAction("Index");
            }

            [HttpGet]
            public IActionResult DetailsCar(int id)
            {
                if (_ipost.FindById(id) is not null)
                {
                    return View(_ipost.FindById(id));
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpPost]
            public IActionResult DetailsCar()
            {
                if (ModelState.IsValid)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}
