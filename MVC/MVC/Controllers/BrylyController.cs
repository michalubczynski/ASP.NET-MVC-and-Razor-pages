using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class BrylyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Oblicz(double wys, double szer, string bryla, string[] operacje)
        {
            if (bryla == "walec")
            {
                if (operacje[0] == "pole")
                {
                    double pole = wys * szer;
                    ViewBag.przechowalnia = "Walec Pole" + pole;
                }
                if (operacje[0] == "objetosc")
                {
                    double obj = wys * szer;
                    ViewBag.przechowalnia = "Walec Objetosc" + obj;
                }
            }
            if (bryla == "stozek")
            {
                if (operacje[0] == "pole")
                {
                    double pole = wys * szer;
                    ViewBag.przechowalnia = "Stozek Pole" + pole;
                }
                if (operacje[0] == "objetosc")
                {
                    double obj = wys * szer;
                    ViewBag.przechowalnia = "Stozek Objetosc" + obj;
                }
            }
            if (bryla == "x2stozek")
            {
                if (operacje[0] == "pole")
                {
                    double pole = wys * szer;
                    ViewBag.przechowalnia = "x2Stozek Pole" + pole;
                }
                if (operacje[0] == "objetosc")
                {
                    double obj = wys * szer;
                    ViewBag.przechowalnia = "x2Stozek Objetosc" + obj;
                }
            }
            return View("Index");
        }
    }
}
