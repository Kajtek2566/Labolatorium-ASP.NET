using Labolatorium_3_v2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Data;

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
        [Authorize]
        public IActionResult CreatePost()
        {
            Post model = new Post();
            model.Users = _postService
                .FindAllUsersForVieModel()
                .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Login })
                .ToList();
            return View(model);
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_postService.FindAll());
        }

        public IActionResult Tablica()
        {
            return View(_postService.FindAll());
        }

        [HttpPost]
        [Authorize]
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
        [Authorize(Roles = "admin")]
        public IActionResult EditPost(int id)
        { 

            if (_postService.FindById(id) is not null)
            {
                Post model = _postService.FindById(id);
                model.Users = _postService
                    .FindAllUsersForVieModel()
                    .Select(o => new SelectListItem() { Value = o.Id.ToString(), Text = o.Login })
                    .ToList();
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [AllowAnonymous]
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
        [AllowAnonymous]
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
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        public IActionResult Delete(Post posts)
        {
            _postService.Delete(posts.Id);
            return RedirectToAction("Index");
        }

    }
}
