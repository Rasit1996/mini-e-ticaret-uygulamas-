using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class ResimMap : EntityTypeConfiguration<Resim>
    {
        public ResimMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.BüyükYol)
                .HasMaxLength(500);

            this.Property(t => t.OrtaYol)
                .HasMaxLength(500);

            this.Property(t => t.KüçükYol)
                .HasMaxLength(500);

            // Table & Column Mappings
            this.ToTable("Resim");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.BüyükYol).HasColumnName("BüyükYol");
            this.Property(t => t.OrtaYol).HasColumnName("OrtaYol");
            this.Property(t => t.KüçükYol).HasColumnName("KüçükYol");
            this.Property(t => t.SıraNo).HasColumnName("SıraNo");
            this.Property(t => t.UrunID).HasColumnName("UrunID");

            // Relationships
            this.HasOptional(t => t.Urun)
                .WithMany(t => t.Resims)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
