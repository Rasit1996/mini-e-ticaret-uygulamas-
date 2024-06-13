using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class Musteri
    {
        public Musteri()
        {
            this.MusteriAdres = new List<MusteriAdre>();
            this.Satislars = new List<Satislar>();
        }

        public System.Guid id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullanıcıAdi { get; set; }
        public string EMail { get; set; }
        public string Telefon { get; set; }
        public virtual aspnet_Users aspnet_Users { get; set; }
        public virtual ICollection<MusteriAdre> MusteriAdres { get; set; }
        public virtual ICollection<Satislar> Satislars { get; set; }
    }
}
