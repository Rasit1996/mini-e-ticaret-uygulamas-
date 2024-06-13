using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HayzumTicaret.UI.App_Classes
{
    public class Kullanici
    {
       [Required(ErrorMessage ="Boş geçilemez..!")]
        public string Adi { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }

    }
}