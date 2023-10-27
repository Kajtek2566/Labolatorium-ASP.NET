using Labolatorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        
        public IActionResult Form()
        {
            return View();
        }  
        
        public IActionResult Result(Calculator model)
        {
            if(!model.isValid())
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
