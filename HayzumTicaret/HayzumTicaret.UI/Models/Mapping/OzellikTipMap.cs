using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class OzellikTipMap : EntityTypeConfiguration<OzellikTip>
    {
        public OzellikTipMap()
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
            this.ToTable("OzellikTip");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Aciklama).HasColumnName("Aciklama");
            this.Property(t => t.KategoriID).HasColumnName("KategoriID");

            // Relationships
            this.HasRequired(t => t.Kategori)
                .WithMany(t => t.OzellikTips)
                .HasForeignKey(d => d.KategoriID);

        }
    }
}
