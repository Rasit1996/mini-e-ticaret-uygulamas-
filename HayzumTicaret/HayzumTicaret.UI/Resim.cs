namespace HayzumTicaret.UI
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int id { get; set; }

        [StringLength(50)]
        public string BüyükYol { get; set; }

        [StringLength(500)]
        public string OrtaYol { get; set; }

        [StringLength(50)]
        public string KüçükYol { get; set; }

        public byte? SıraNo { get; set; }

        public int? UrunID { get; set; }
    }
}
