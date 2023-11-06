using Labolatorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            return View(contact); 
        }
    }
}
