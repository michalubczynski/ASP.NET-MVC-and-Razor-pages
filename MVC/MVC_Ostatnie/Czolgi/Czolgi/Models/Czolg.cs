using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Czolgi.Models
{
    [Table("Czolgi")]
    public class Czolg
    {
        [Key]
        public int CzolgId { get; set; }
        public string Typ { get; set; }
        public double Kaliber { get; set; }
        public double Masa { get; set; }
    }
}
