using System.Diagnostics;
using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Form()
        {
            return View();
        }

        public IActionResult Result(Birth model)
        {
            if (!model.isValid())
            {
                return BadRequest();
            }
            return View(model);
        }

    }
}
