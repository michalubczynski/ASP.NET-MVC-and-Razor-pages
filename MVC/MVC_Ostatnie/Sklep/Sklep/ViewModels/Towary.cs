using Sklep.Models;

namespace Sklep.ViewModels
{
    public class Towary
    {
        public ICollection<Towar> Towary_ { get; set; }
        public int CalkowitaLiczbaTowarow { get; set; }
        public decimal SredniaCena { get; set; }
    }
}
