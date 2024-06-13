using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class Kargo
    {
        public Kargo()
        {
            this.Satislars = new List<Satislar>();
        }

        public int id { get; set; }
        public string SirketAdi { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string WebSite { get; set; }
        public string EMail { get; set; }
        public virtual ICollection<Satislar> Satislars { get; set; }
    }
}
