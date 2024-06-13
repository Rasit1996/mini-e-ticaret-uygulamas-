using HayzumTicaret.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HayzumTicaret.UI.App_Classes
{
    public class UrunDetay
    {
        public Urun urun { get; set; }
        public decimal İndirim { get; set; }
        public int adet { get; set; }
    }
    public class Sepet
    {

        public List<UrunDetay> urunDetay { get; set; }


        public Sepet()
        {
            urunDetay = new List<UrunDetay>();
            urunler = new List<Urun>(); 
        }

        private List<Urun> urunler;

        public List<Urun> Urunler
        {
            get { return urunler; }
            set { urunler = value; }
        }

    }
}