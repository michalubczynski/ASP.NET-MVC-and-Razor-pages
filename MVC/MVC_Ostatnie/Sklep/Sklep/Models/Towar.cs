using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sklep.Models
{
    [Table("Towary")]
    public class Towar
    {
        [Key]
        public int TowarId { get; set; }
        public string Nazwa { get; set; }
        public string Producent { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal Cena { get; set; }
        public int Ilosc { get; set; }
    }
}
