using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class SatisDetay
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public Nullable<double> İndirim { get; set; }
        public virtual Satislar Satislar { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
