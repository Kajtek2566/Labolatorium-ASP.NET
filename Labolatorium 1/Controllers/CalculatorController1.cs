using Labolatorium_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult index(Calculator model)
        {
            if (!model.isValid())
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
