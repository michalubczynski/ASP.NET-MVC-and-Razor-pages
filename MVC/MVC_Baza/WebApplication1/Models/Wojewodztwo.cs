using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Wojewodztwa")]
    public class Wojewodztwo
    {
        [Key]
        public int WojewodzwoId { get; set; }
        public String Nazwa { get; set; }
        public ICollection<Miasto>? Miasta { get; set; }
    }
}
