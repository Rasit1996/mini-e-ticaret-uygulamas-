using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class Resim
    {
        public Resim()
        {
            this.Kategoris = new List<Kategori>();
            this.Markas = new List<Marka>();
        }

        public int id { get; set; }
        public string BüyükYol { get; set; }
        public string OrtaYol { get; set; }
        public string KüçükYol { get; set; }
        public Nullable<byte> SıraNo { get; set; }
        public Nullable<int> UrunID { get; set; }
        public virtual ICollection<Kategori> Kategoris { get; set; }
        public virtual ICollection<Marka> Markas { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
