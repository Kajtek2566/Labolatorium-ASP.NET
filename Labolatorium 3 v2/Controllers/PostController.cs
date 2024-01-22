using Labolatorium_3_v2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Labolatorium_3_v2.Controllers
{
    public class PostController : Controller
    {

        private readonly IPostService _postService;
        public PostController (IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }

        [HttpPost]
        public IActionResult Create(Post model)
        {
            if (ModelState.IsValid)
            {
                _postService.Add(model);

                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        { 

            if (_postService.FindById(id) is not null)
            {
                return View(_postService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult EditPost(Post posts)
        {

            if (ModelState.IsValid)
            {
                _postService.Update(posts);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            if (_postService.FindById(id) is not null)
            {
                return View(_postService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Details()
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {

            if (_postService.FindById(id) is not null)
            {
                return View(_postService.FindById(id));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(Post posts)
        {
            _postService.Delete(posts.Id);
            return RedirectToAction("Index");
        }










    }
}
