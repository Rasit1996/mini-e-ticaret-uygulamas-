using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HayzumTicaret.UI.Models;
namespace HayzumTicaret.UI.App_Classes
{
    public class Context
    {
       
        private static Db01_eTicaretContext baglanti;


        public static Db01_eTicaretContext Baglanti
        {
            get
            {
                if (baglanti == null)
                    baglanti = new Db01_eTicaretContext();
                return baglanti;
            }
            set { baglanti = value; }
        }

    }
}