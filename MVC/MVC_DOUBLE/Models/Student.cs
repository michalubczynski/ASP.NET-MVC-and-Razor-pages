using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_DOUBLE.Models
{
    [Table("Studenci")]
    public class Student : IEntityTypeConfiguration<Student>
    {
        [Key]
        public int StudentId { get; set; }
        public int Ocena { get; set; }
        public string Nazwisko { get; set; }
        public int? GrupaId { get; set; }
        [ForeignKey(nameof(GrupaId))]
        public Grupa? Grupa { get; set; }

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(s => s.Grupa).WithMany(g => g.Studenci).OnDelete(DeleteBehavior.Cascade);
        }

    }
}
