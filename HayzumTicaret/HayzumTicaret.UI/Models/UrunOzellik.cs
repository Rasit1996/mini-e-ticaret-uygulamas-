using System;
using System.Collections.Generic;

namespace HayzumTicaret.UI.Models
{
    public partial class UrunOzellik
    {
        public int UrunID { get; set; }
        public int OzellikTip { get; set; }
        public int OzellikDeger { get; set; }
        public virtual OzellikDeger OzellikDeger1 { get; set; }
        public virtual OzellikTip OzellikTip1 { get; set; }
        public virtual Urun Urun { get; set; }
    }
}
