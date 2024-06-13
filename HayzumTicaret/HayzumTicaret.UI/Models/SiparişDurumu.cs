using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class SiparişDurumu
    {
        public SiparişDurumu()
        {
            this.Satislars = new List<Satislar>();
        }

        public int id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public virtual ICollection<Satislar> Satislars { get; set; }
    }
}
