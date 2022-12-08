using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    [Table("Miasta")]
    public class Miasto
    {
        [Key]
        public int MiastoId { get; set; }
        [MaxLength(50)]
        public String Nazwa { get; set; }
        [Range(0, 300000)]
        public int IleMieszkancow { get; set; }
        public int? WojewodztwoId { get; set; }
        [ForeignKey(nameof(WojewodztwoId))]
        public Wojewodztwo? Wojewodztwo { get; set; }
        public void Configure(EntityTypeBuilder<Miasto> builder)
        {
            builder.HasOne(s => s.Wojewodztwo).WithMany(g => g.Miasta).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
