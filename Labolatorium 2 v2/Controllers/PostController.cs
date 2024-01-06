using Labolatorium_3_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Labolatorium_3_v2.Controllers
{
    public class PostController : Controller
    {

        static Dictionary<int, Post> _Posts = new Dictionary<int, Post>();

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_Posts);
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                int id = _Posts.Keys.Count != 0 ? _Posts.Keys.Max() : 0;
                model.Id = id + 1;
                _Posts.Add(model.Id, model);

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {

            if (_Posts.Keys.Contains(id))
            {
                return View(_Posts[id]);
            }
            else
            {
                return NotFound();
            };
        }

        [HttpPost]
        public IActionResult EditPost(Post posts)
        {

            if (ModelState.IsValid)
            {
                _Posts[posts.Id] = posts;
                return View("Index", _Posts);
            }
            else
            {
                return NotFound();
            };
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            if (_Posts.Keys.Contains(id))
            {
                return View(_Posts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Details()
        {

            return View("Index", _Posts);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (_Posts.Keys.Contains(id))
            {
                return View(_Posts[id]);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(Post posts)
        {
            _Posts.Remove(posts.Id);
            return View("Index", _Posts);
        }










    }
}
