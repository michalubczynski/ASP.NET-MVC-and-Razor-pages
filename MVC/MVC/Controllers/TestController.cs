using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Test()
        {
            return View();
        }
        public IActionResult Test2(string pyt1, string pyt2, string pyt3, string pyt4, string pyt5, string pyt6, string[] pyt7, string[] pyt8)
        {
            int punktacja = 0;
            if (pyt1 == "Naziemny")
            {
                punktacja += 1;
            }
            if(pyt2 == "BMW")
            {
                punktacja += 1;

            }
            if(pyt3 ==  "tak")
            {
                punktacja += 1;
            }
            if (pyt4 == "Benzin")
            {
                punktacja += 1;
            }
            if (pyt5 == "Manual")
            {
                punktacja += 1;
            }
            if (pyt6 == "Maly")
            {
                punktacja += 1;
            }
            for (int i = 0; i < pyt7.Length; i++) {
                if (pyt7[i]=="Zimowe")
                {
                    punktacja += 1;
                }
                if (pyt7[i] == "Letnie")
                {
                    punktacja += 1;
                }
            }

            for (int i = 0; i < pyt8.Length; i++)
            {
                if (pyt8[i] == "Stalowki")
                {
                    punktacja += 1;
                }
                if (pyt8[i] == "Alufelgi")
                {
                    punktacja += 1;
                }
            }
            ViewBag.wynik = punktacja;
            return View("Test");
        }
    }
}
