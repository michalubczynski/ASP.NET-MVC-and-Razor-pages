using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Prostopadloscian
    {
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public double Wysokosc { get; set; } = 1;
        [RegularExpression(@"^[0-9]*[02468]$", ErrorMessage = "Podaj wartosc parzysta")]
        public int Szerokosc { get; set; } 
        public int Grubosc { get; set; } 
        public double PolePowierzchni { get {return Szerokosc* Wysokosc; } }
        public double Objetosc { get { return Szerokosc * Wysokosc; } }
        public double DlugoscKrawedzi { get { return Szerokosc * Wysokosc*Grubosc; } }
        public string[]? Obliczenia { get; set; }



    }
}
