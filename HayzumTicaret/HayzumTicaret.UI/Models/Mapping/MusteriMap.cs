using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class MusteriMap : EntityTypeConfiguration<Musteri>
    {
        public MusteriMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.Adi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Soyadi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.KullanıcıAdi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.EMail)
                .HasMaxLength(50);

            this.Property(t => t.Telefon)
                .IsFixedLength()
                .HasMaxLength(15);

            // Table & Column Mappings
            this.ToTable("Musteri");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Adi).HasColumnName("Adi");
            this.Property(t => t.Soyadi).HasColumnName("Soyadi");
            this.Property(t => t.KullanıcıAdi).HasColumnName("KullanıcıAdi");
            this.Property(t => t.EMail).HasColumnName("EMail");
            this.Property(t => t.Telefon).HasColumnName("Telefon");

            // Relationships
            this.HasRequired(t => t.aspnet_Users)
                .WithOptional(t => t.Musteri);

        }
    }
}
