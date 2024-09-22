using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zeun.Web.Data;
using Zeun.Web.Models;

namespace Zeun.Web.Controllers
{
    public class OgretimElemani : Controller
    {
        private readonly OgrenciDbContext _context;

        public OgretimElemani(OgrenciDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe=>oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };




            return View("Index",viewModel);
        }
        public IActionResult OzlukBilgileri()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("OzlukBilgileri", viewModel);
        }

        public IActionResult BolumMufredati()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("BolumMufredati", viewModel);
        }

        public IActionResult VerilenDersler()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("VerilenDersler", viewModel);
        }

        public IActionResult DersProgrami()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("DersProgrami", viewModel);
        }
        public IActionResult Degerlendirme()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("Degerlendirme", viewModel); return View();
        }

        public IActionResult SinavTanimla()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("SinavTanimla", viewModel);
        }

        public IActionResult SinavTakvimi()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("SinavTakvimi", viewModel);
        }

        public IActionResult DersKayitOnayi()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("DersKayitOnayi", viewModel);
        }
        public IActionResult Danismanlik()
        {
            int? ogretimElemaniId = HttpContext.Session.GetInt32("ogretimElemaniId");

            var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(oe => oe.OgretimElemaniId == ogretimElemaniId);
            var unvan = _context.Unvans.FirstOrDefault(u => u.UnvanId == ogretimElemani.UnvanId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogretimElemani.BolumId);

            var viewModel = new OgretimElemaniViewModel
            {
                OgretimElemani = ogretimElemani,
                Unvan = unvan,
                Bolum = bolum,
            };
            return View("Danismanlik", viewModel);
        }
    }
}
