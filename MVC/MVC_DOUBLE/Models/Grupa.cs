using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOUBLE.Models
{
    [Table("Grupy")]
    public class Grupa
    {
        [Key]
        public int GrupaId { get; set; }
        public string Nazwa { get; set; }
        public ICollection<Student>? Studenci { get; set; }
    }
}
