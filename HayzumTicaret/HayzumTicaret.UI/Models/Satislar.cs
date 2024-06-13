using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class Satislar
    {
        public Satislar()
        {
            this.SatisDetays = new List<SatisDetay>();
        }

        public int id { get; set; }
        public System.Guid MusteriID { get; set; }
        public System.DateTime SatisTarihi { get; set; }
        public decimal ToplamTutar { get; set; }
        public bool SepetteMi { get; set; }
        public int KargoID { get; set; }
        public int SiparisDurumID { get; set; }
        public string KargoTakipNo { get; set; }
        public virtual Kargo Kargo { get; set; }
        public virtual Musteri Musteri { get; set; }
        public virtual ICollection<SatisDetay> SatisDetays { get; set; }
        public virtual SiparişDurumu SiparişDurumu { get; set; }
    }
}
