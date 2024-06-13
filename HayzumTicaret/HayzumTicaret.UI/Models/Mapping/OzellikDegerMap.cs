using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class OzellikDegerMap : EntityTypeConfiguration<OzellikDeger>
    {
        public OzellikDegerMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Aciklama)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("OzellikDeger");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.OzellikTip).HasColumnName("OzellikTip");

            // Relationships
            this.HasRequired(t => t.OzellikTip1)
                .WithMany(t => t.OzellikDegers)
                .HasForeignKey(d => d.OzellikTip);

        }
    }
}
