using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class OzellikDeger
    {
        public OzellikDeger()
        {
            this.UrunOzelliks = new List<UrunOzellik>();
        }

        public int id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }
        public int OzellikTip { get; set; }
        public virtual OzellikTip OzellikTip1 { get; set; }
        public virtual ICollection<UrunOzellik> UrunOzelliks { get; set; }
    }
}
