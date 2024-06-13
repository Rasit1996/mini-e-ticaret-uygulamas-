using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class MusteriAdre
    {
        public int id { get; set; }
        public System.Guid MusteriID { get; set; }
        public string Adres { get; set; }
        public string Adi { get; set; }
        public virtual Musteri Musteri { get; set; }
    }
}
