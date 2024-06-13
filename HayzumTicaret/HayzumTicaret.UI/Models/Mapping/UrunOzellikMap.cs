using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HayzumTicaret.UI.Models.Mapping
{
    public class UrunOzellikMap : EntityTypeConfiguration<UrunOzellik>
    {
        public UrunOzellikMap()
        {
            // Primary Key
            this.HasKey(t => new { t.UrunID, t.OzellikTip, t.OzellikDeger });

            // Properties
            this.Property(t => t.UrunID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OzellikTip)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.OzellikDeger)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("UrunOzellik");
            this.Property(t => t.UrunID).HasColumnName("UrunID");
            this.Property(t => t.OzellikTip).HasColumnName("OzellikTip");
            this.Property(t => t.OzellikDeger).HasColumnName("OzellikDeger");

            // Relationships
            this.HasRequired(t => t.OzellikDeger1)
                .WithMany(t => t.UrunOzelliks)
                .HasForeignKey(d => d.OzellikDeger);
            this.HasRequired(t => t.OzellikTip1)
                .WithMany(t => t.UrunOzelliks)
                .HasForeignKey(d => d.OzellikTip);
            this.HasRequired(t => t.Urun)
                .WithMany(t => t.UrunOzelliks)
                .HasForeignKey(d => d.UrunID);

        }
    }
}
