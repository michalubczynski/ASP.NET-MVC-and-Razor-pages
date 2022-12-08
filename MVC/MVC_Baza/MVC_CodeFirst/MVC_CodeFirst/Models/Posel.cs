using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_CodeFirst.Models
{
    [Table("Poslowie")]
    public class Posel : IEntityTypeConfiguration<Posel>
    {
        [Key]
        public int PoselId { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public int? PartiaId { get; set; }
        [ForeignKey(nameof(PartiaId))]
        public Partia? Partia { get; set; }


        public void Configure(EntityTypeBuilder<Posel> builder)
        {
            builder.HasOne(s => s.Partia).WithMany(g => g.Poslowie).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
