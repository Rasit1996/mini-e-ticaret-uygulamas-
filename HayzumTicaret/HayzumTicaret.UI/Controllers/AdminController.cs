using HayzumTicaret.UI.App_Classes;
using HayzumTicaret.UI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HayzumTicaret.UI.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Urun()
        {
            
            return View(Context.Baglanti.Uruns.ToList());
        }

        public ActionResult UrunEkle()
        {
            ViewBag.Kategori = Context.Baglanti.Kategoris.ToList();
            ViewBag.Marka = Context.Baglanti.Markas.ToList();
            return View();
        }

        [HttpPost]

        public ActionResult UrunEkle(Urun u)
        {
            try
            {
                Context.Baglanti.Uruns.Add(u);
                Context.Baglanti.SaveChanges();
                return RedirectToAction("Urun");
            }
            catch (DbUpdateException ex)
            {

                throw;
            }
            
        }

        public ActionResult Marka()
        {
            ViewBag.marka = Context.Baglanti.Markas.ToList();
            return View();
        }

        public  ActionResult MarkaEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult MarkaEkle(Marka mrk, HttpPostedFileBase FileUpload)
        {
            int resimID = -1;
            if (FileUpload == null)
            {
                Context.Baglanti.Markas.Add(mrk);
                Context.Baglanti.SaveChanges();
                return RedirectToAction("Marka");
            }
            Image img = Image.FromStream(FileUpload.InputStream);
            int width =
        Convert.ToInt32(ConfigurationManager.AppSettings["MarkaWidth"].ToString());
            int height =
            Convert.ToInt32(ConfigurationManager.AppSettings["MarkaHeight"].ToString());
            string name = "/Content/MarkaResim/"+ Guid.NewGuid() + Path.GetExtension(FileUpload.FileName);
            Bitmap bm = new Bitmap(img, width, height);
            bm.Save(Server.MapPath(name));

            Resim rsm = new Resim();
            rsm.OrtaYol = name;
            try
            {
                Context.Baglanti.Resims.Add(rsm);
                Context.Baglanti.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);

            }
        
            if (rsm.id != null)
            {
                resimID = rsm.id;
                mrk.ResimID = resimID;
            }
            
            try
            {
                Context.Baglanti.Markas.Add(mrk);
                Context.Baglanti.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                
            }
            
            
            return RedirectToAction("Marka");
        }

        public ActionResult Kategori()
        {
            return View(Context.Baglanti.Kategoris.ToList());
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]

        public ActionResult KategoriEkle(Kategori ktg)
        {
            Context.Baglanti.Kategoris.Add(ktg);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("Kategori");
        }

        public ActionResult OzellikTip()
        {
            return View(Context.Baglanti.OzellikTips.ToList());
        }

        public ActionResult OzellikTipEkle()
        {
            return View(Context.Baglanti.Kategoris.ToList());
        }

        [HttpPost]

        public ActionResult OzellikTipEkle(OzellikTip ot)
        {
            Context.Baglanti.OzellikTips.Add(ot);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("OzellikTip");
        }

        public ActionResult OzellikDeger()
        {
            return View(Context.Baglanti.OzellikDegers.ToList());
        }

        public ActionResult OzellikDegerEkle()
        {
            return View(Context.Baglanti.OzellikTips.ToList());
        }

        [HttpPost]

        public ActionResult OzellikDegerEkle(OzellikDeger od)
        {
            Context.Baglanti.OzellikDegers.Add(od);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("OzellikDeger");
        }

        public ActionResult UrunOzellik()
        {
            return View(Context.Baglanti.UrunOzelliks.ToList());
        }

        public ActionResult UrunOzellikEkle()
        {
            ViewBag.urunler = Context.Baglanti.Uruns.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult UrunOzellikEkle(UrunOzellik UrOz)
        {
            Context.Baglanti.UrunOzelliks.Add(UrOz);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("UrunOzellik");
        }

        public ActionResult UrunOzellikSil(int urunID,int OzelliktipID,int ozellikdegerID)
        {
            HayzumTicaret.UI.Models.UrunOzellik item = Context.Baglanti.UrunOzelliks.SingleOrDefault
                (x => x.UrunID == urunID&& x.OzellikTip == OzelliktipID&&x.OzellikDeger==ozellikdegerID);
            Context.Baglanti.UrunOzelliks.Remove(item);
            Context.Baglanti.SaveChanges();
            return RedirectToAction("UrunOzellik");
                
        }

        public PartialViewResult UrunOzellikTip(int? id)
        {

            var urn = Context.Baglanti.Uruns.SingleOrDefault(x => x.id == id);
            int ID = urn.KategoriID;  
              
              var data = Context.Baglanti.OzellikTips.Where(x => x.KategoriID == ID);
            ViewBag.ozellikler = data;
                return PartialView();
            
        }

        public PartialViewResult UrunOzellikDeger(int? id)
        {
           
                var data = Context.Baglanti.OzellikDegers.Where(x => x.OzellikTip == id);
                ViewBag.degerler = data;
                return PartialView();
            }

        public ActionResult UrunResimEkle(int id)
        {
            return View(id);
        }

        [HttpPost]

        public ActionResult UrunResimEkle(int uID, HttpPostedFileBase fileUpload)
        {
            if (fileUpload!=null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap kucukResim = new Bitmap(img, Settings.UrunKucukBoyut);
                Bitmap buyukResim = new Bitmap(img, Settings.UrunBuyukBoyut);

                string kucukYol = "/Content/UrunResim/Kucuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);
                string buyukYol = "/Content/UrunResim/Buyuk/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                kucukResim.Save(Server.MapPath(kucukYol));
                buyukResim.Save(Server.MapPath(buyukYol));

                Resim rsm = new Resim();
                rsm.KüçükYol = kucukYol;
                rsm.BüyükYol = buyukYol;
                rsm.UrunID = uID;
                Context.Baglanti.Resims.Add(rsm);
                Context.Baglanti.SaveChanges();
                return View(uID);
            }
            return View(uID);
        }
        public PartialViewResult ResimGoster(int id)
        {
            var rsm = Context.Baglanti.Resims.SingleOrDefault(x => x.id == id);
            ViewBag.resim = rsm;
            return PartialView();
        }

        public ActionResult SliderResimleri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SliderResimEkle(HttpPostedFileBase fileUpload)
        {
            if (fileUpload!=null)
            {
                Image img = Image.FromStream(fileUpload.InputStream);

                Bitmap rsm = new Bitmap(img, Settings.SliderBoyut);

                string yol = "/Content/SliderResimleri/" + Guid.NewGuid() + Path.GetExtension(fileUpload.FileName);

                rsm.Save(Server.MapPath(yol));

                Resim rs = new Resim();
                rs.BüyükYol = yol;
                Context.Baglanti.Resims.Add(rs);
                Context.Baglanti.SaveChanges();

                return View("SliderResimleri");
            }
            return View("SlinderResimleri");
        }
    }
   
        
    }
