using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    [Table("Partie")]
    public class Partia
    {
        [Key]
        public int PartiaId { get; set; }
        [MaxLength(50)]
        public string Nazwa { get; set; }
        public ICollection<Posel>? Poslowie { get; set; }

    }
}
