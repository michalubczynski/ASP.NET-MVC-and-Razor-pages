using Microsoft.AspNetCore.Mvc;

namespace Czolgi.Controllers
{
    public class KlientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
