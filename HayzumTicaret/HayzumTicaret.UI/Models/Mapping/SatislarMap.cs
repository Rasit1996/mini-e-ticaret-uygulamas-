using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class SatislarMap : EntityTypeConfiguration<Satislar>
    {
        public SatislarMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.KargoTakipNo)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Satislar");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.MusteriID).HasColumnName("MusteriID");
            this.Property(t => t.SatisTarihi).HasColumnName("SatisTarihi");
            this.Property(t => t.ToplamTutar).HasColumnName("ToplamTutar");
            this.Property(t => t.SepetteMi).HasColumnName("SepetteMi");
            this.Property(t => t.KargoID).HasColumnName("KargoID");
            this.Property(t => t.SiparisDurumID).HasColumnName("SiparisDurumID");
            this.Property(t => t.KargoTakipNo).HasColumnName("KargoTakipNo");

            // Relationships
            this.HasRequired(t => t.Kargo)
                .WithMany(t => t.Satislars)
                .HasForeignKey(d => d.KargoID);
            this.HasRequired(t => t.Musteri)
                .WithMany(t => t.Satislars)
                .HasForeignKey(d => d.MusteriID);
            this.HasRequired(t => t.SiparişDurumu)
                .WithMany(t => t.Satislars)
                .HasForeignKey(d => d.SiparisDurumID);

        }
    }
}
