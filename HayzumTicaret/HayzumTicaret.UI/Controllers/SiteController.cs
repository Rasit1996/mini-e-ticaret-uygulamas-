using HayzumTicaret.UI.App_Classes;
using HayzumTicaret.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace HayzumTicaret.UI.Controllers
{
    public class SiteController : Controller
    {
        // GET: Site
        public ActionResult Index()
        {
            var Slider = Context.Baglanti.Resims.Where(x => x.BüyükYol.Contains("SliderResimleri"));
            ViewBag.slider = Slider;
            var U = Context.Baglanti.Uruns.ToList();
            ViewBag.urunler = U;
            return View();
           // OzellikDeger b = new OzellikDeger();
           // Dictionary<string, List<OzellikDeger>> deger = new Dictionary<string, List<OzellikDeger>>();
            
        }

        public ActionResult UrunDetay(int id)
        {
            Resim r = Context.Baglanti.Resims.SingleOrDefault(x => x.UrunID == id);
             List<UrunOzellik> uo = Context.Baglanti.UrunOzelliks.Where(x => x.UrunID == id).ToList();
            List<OzellikTip> ot = new List<OzellikTip>();
            foreach (UrunOzellik item in uo)
            {
                 OzellikTip o= Context.Baglanti.OzellikTips.SingleOrDefault(x => x.id == item.OzellikTip);
                if (!ot.Contains(o))
                {
                    ot.Add(o);
                }
            }
            ViewBag.OzellikTipler = ot;
            return View(r);
        }

        int adet = 0;

      

        public int SepetEkle(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                HttpCookie Adet = Request.Cookies["Adet"];
                if (Adet == null)
                {
                    adet++;
                    Adet = new HttpCookie("Adet", adet.ToString());
                    Response.Cookies.Add(Adet);
                    Adet.Expires = DateTime.Now.AddMinutes(1);
                }
                else
                {

                    adet = Convert.ToInt32(Adet.Value);
                    adet++;

                    Adet.Value = adet.ToString();

                    Response.Cookies.Add(Adet);
                }

                Sepet s;
                if (Session["Sepet"] == null)
                {
                    s = new Sepet();
                }
                else
                {
                    s = (Sepet)Session["Sepet"];
                }
                Urun u = Context.Baglanti.Uruns.SingleOrDefault(x => x.id == id);
                s.Urunler.Add(u);
                Session["Sepet"] = s;
            }
            else
            {
                HttpCookie Adet = Request.Cookies[User.Identity.Name];
                if (Adet==null)
                {
                    adet++;
                    Adet = new HttpCookie(User.Identity.Name,adet.ToString());
                    Adet.Expires = DateTime.Now.AddMinutes(1);
                    Response.Cookies.Add(Adet);
                }
                else
                {
                    adet = Convert.ToInt32(Adet.Value);
                    adet++;
                    Adet.Value = adet.ToString();
                    Response.Cookies.Add(Adet);
                }

                Sepet s;
                if (Session[User.Identity.Name]==null)
                {
                    s = new Sepet();
                }
                else
                {
                    s = (Sepet)Session[User.Identity.Name];
                }
                Urun u = Context.Baglanti.Uruns.SingleOrDefault(x => x.id == id);
                s.Urunler.Add(u);
                Session[User.Identity.Name] = s;
                
            }
            
            
            
            return adet;
        }

        public ActionResult Sepet()
        {
            Sepet s;
            if (User.Identity.IsAuthenticated==false)
            {
                 s = (Sepet)Session["Sepet"];
            }
            else
            {
                 s = (Sepet)Session[User.Identity.Name];
            }

            
            if (s!=null)
                ViewBag.S_Urunler = s.Urunler.GroupBy(x => x.id).Select(g=> new { id=g.Key, adet=g.Count() }).ToList();
           
                
             return View();
        }

        public PartialViewResult SepetUrunAdet()
        {
           
            return PartialView();
        }

        [HttpPost]
        public ActionResult OdemeSayfasi()
        {
            return View();
        }

        public ActionResult Hata()
        {
            return View();
        }
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
         public ActionResult GirisYap(Kullanici k)
        {
          //  Sepet s = new App_Classes.Sepet();
          //int a=  s.urunDetay.SingleOrDefault(x => x.urun.id == 2).adet;
          //  a++;
          //  s.urunDetay.SingleOrDefault(x => x.urun.id == 2).adet = a;

            if (!ModelState.IsValid)
            {
                return View("GirisYap");
            }
            try
            {
                Membership.CreateUser(k.Adi, k.Sifre, k.Email);
                Roles.CreateRole("Üye");
                Roles.AddUserToRole(k.Adi, "Üye");
                return RedirectToAction("Index");
            }
            catch (MembershipCreateUserException e)
            {

                return RedirectToAction("GirisYap");
            }
           
        }

        [HttpPost]

        public ActionResult Giris(Kullanici k)
        {
            
           
            MembershipUserCollection users = Membership.GetAllUsers();
            //MembershipUser u = Membership.GetAllUsers().Cast<MembershipUser>().SingleOrDefault(x => x.Email == k.Email);
            MembershipUser u = users.Cast<MembershipUser>().SingleOrDefault(x => x.Email==k.Email);
            string[] rol= Roles.GetRolesForUser(u.UserName);
            if (u==null)
            {
                return RedirectToAction("GirisYap");
            }
            bool state = Membership.ValidateUser(u.UserName, k.Sifre);
            if (state)
            {
                FormsAuthentication.RedirectFromLoginPage(u.UserName, true);
                if (!rol.Contains("Admin"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index","Admin");
                }
                
            }
            return RedirectToAction("GirisYap");
           
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    }
}