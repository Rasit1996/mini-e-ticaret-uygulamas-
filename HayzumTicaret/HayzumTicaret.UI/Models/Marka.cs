using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class Marka
    {
        public Marka()
        {
            this.Uruns = new List<Urun>();
        }

        public int id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public Nullable<int> ResimID { get; set; }
        public virtual Resim Resim { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
