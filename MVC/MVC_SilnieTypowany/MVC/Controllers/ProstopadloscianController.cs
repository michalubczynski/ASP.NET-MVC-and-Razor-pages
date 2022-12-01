using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProstopadloscianController : Controller
    {
        public IActionResult Index(Prostopadloscian prostopadloscian)
        {
            if (ModelState.IsValid)
            {
                return View(prostopadloscian);
            }
            else return NoContent();
        }
    }
}
