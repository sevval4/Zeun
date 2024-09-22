using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Zeun.Web.Data;
using Zeun.Web.Models;

namespace Zeun.Web.Controllers
{
    public class OgrenciController : Controller
    {
        // dbcontext enjeksiyonu
        private readonly OgrenciDbContext _context;
        public OgrenciController(OgrenciDbContext context)
        {
            _context = context;
        }


        // Ogrenci indeksi
        public IActionResult Index()
        {   // loginde alınan ogrenciId ile verilerin getirilmesi
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            var ogrenci = _context.Ogrencis.FirstOrDefault(a => a.OgrenciId == ogrenciId);
            var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
            var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
            var akademikDonemList = new List<AkademikDonem>();


            //müfredattaki tüm dersleri dönme
            foreach (var mufredat in mufredats)
            {
                var akademikDonem = _context.AkademikDonems.Where(ad => ad.AkademikDonemId == mufredat.AkademikDonemId).ToList();
                akademikDonemList.AddRange(akademikDonem);
            }
                var viewModel = new OgrenciOzlukBilgileriViewModel()
            {
                Ogrenci = ogrenci,
                Bolum = bolum,
                Mufredat = mufredats,
                AkademikDonem = akademikDonemList,
                
            };





            return View("Index", viewModel);
        }



        // özlük Bilgilerini getiren action

        public IActionResult OzlukBilgileri()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");
            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var ogrenciDurum = _context.OgrenciDurums.FirstOrDefault(od => od.OgrenciDurumId == ogrenci.OgrenciDurumId);



                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    OgrenciDurum = ogrenciDurum,


                };

                return View("OzlukBilgileri", viewModel);
            }
            else
            {

                ViewBag.Error = "Öğrenci ID'si geçersiz";
                return View();
            }
        }



        // bölüm müfredatını getiren action

        public IActionResult BolumMufredati()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();
                var akademikYilList = new List<AkademikYil>();
                var dersTuruList = new List<DersTuru>();
                var dersDiliList = new List<DersDili>();

                foreach (var mufredat in mufredats)
                {
                    var akademikYil = _context.AkademikYils.Where(ad => ad.AkademikYilId == mufredat.AkademikYiIid).ToList();
                    akademikYilList.AddRange(akademikYil);

                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                foreach (var ders in dersHavuzuList)
                {

                    var dersTuru = _context.DersTurus.FirstOrDefault(dt => dt.DersTuruId == ders.DersTuruId);
                    var dersDili = _context.DersDilis.FirstOrDefault(dd => dd.DersDiliId == ders.DersDiliId);


                    dersTuruList.Add(dersTuru);
                    dersDiliList.Add(dersDili);
                }


                // viewmodele ekleyerek biden çok tablo iletme
                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    AkademikYil = akademikYilList,
                    DersTuru = dersTuruList,
                    DersDili = dersDiliList,



                };









                return View("BolumMufredati", viewModel);
            }
            else
            {
                //null durum işleme
                ViewBag.Error = "Öğrenci ID'si geçersiz";
                return View(); // hata mesajıyla view ı dönme
            }



        }


        // dönem derslerini getiren action
        public IActionResult DonemDersleri()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");


            // null kontrolü
            if (ogrenciId != null)
            {

                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();
                var dersAcmaList = new List<DersAcma>();
                var ogretimElemaniList = new List<OgretimElemani>();

                var dersTuruList = new List<DersTuru>();



                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);

                    var dersAcma = _context.DersAcmas.Where(da => da.MufredatId == mufredat.MufredatId);
                    dersAcmaList.AddRange(dersAcma);



                }

                foreach (var ders in dersHavuzuList)
                {

                    var dersTuru = _context.DersTurus.FirstOrDefault(dt => dt.DersTuruId == ders.DersTuruId);



                    dersTuruList.Add(dersTuru);

                }

                // tip hatası alınan kod veri çekmede çok sıkıntı yaşandı casting nedeni bulunamayan bir sebepten hata veriyor diğer tablolar vermezken 
                //foreach(var ders in dersAcmaList)
                //{
                //    var ogretimE = _context.OgretimElemanis.FirstOrDefault(d => d.OgretimElemaniId == ders.OgrElmId);

                //    ogretimElemaniList.Add(ogretimE);
                //}




                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    DersTuru = dersTuruList,
                    DersAcma = dersAcmaList,







                };
                return View("DonemDersleri", viewModel);



            }
            return View();

        }



        //ders programını getiren action

        public IActionResult DersProgrami()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");


            if (ogrenciId != null)
            {

                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();
                var dersAcmaList = new List<DersAcma>();

                var dersTuruList = new List<DersTuru>();



                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);

                    var dersAcma = _context.DersAcmas.Where(da => da.MufredatId == mufredat.MufredatId);
                    dersAcmaList.AddRange(dersAcma);



                }

                foreach (var ders in dersHavuzuList)
                {

                    var dersTuru = _context.DersTurus.FirstOrDefault(dt => dt.DersTuruId == ders.DersTuruId);



                    dersTuruList.Add(dersTuru);

                }

                var DersProgrami = new List<DersProgrami>();
                foreach (var ders in dersAcmaList)
                {
                    var dersprogrami = _context.DersProgramis.Where(dp => dp.DersAcmaId == ders.DersAcmaId).ToList();
                    DersProgrami.AddRange(dersprogrami);

                }





                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    DersTuru = dersTuruList,
                    DersAcma = dersAcmaList,
                    DersProgrami = DersProgrami,







                };
                return View("DersProgrami", viewModel);



            }
            return View();
        }


        // sınav notlarını getiren action
        public IActionResult SinavNotlari()
        {

            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();


                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                var degerlendirme = _context.Degerlendirmes.Where(d => d.OgrenciId == ogrenciId).ToList();

                var sinavlar = new List<Sinav>();

                foreach (var deger in degerlendirme)
                {
                    var sinav = _context.Sinavs.Where(s => s.SinavId == deger.SinavId).ToList();
                    sinavlar.AddRange(sinav);


                }

                var sinavTuru = new List<SinavTuru>();

                foreach (var sinav in sinavlar)
                {
                    var sinavTemp = _context.SinavTurus.Where(st => st.SinavTuruId == sinav.SinavTuruId).ToList();
                    sinavTuru.AddRange(sinavTemp);
                }

                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    Sinav = sinavlar,
                    Degerlendirme = degerlendirme,
                    SinavTuru = sinavTuru,



                };
                return View("SinavNotlari", viewModel);
            }



            return View();


        }
        // sınav Takvimini getiren action
        public IActionResult SinavTakvimi()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();


                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                var degerlendirme = _context.Degerlendirmes.Where(d => d.OgrenciId == ogrenciId).ToList();

                var sinavlar = new List<Sinav>();

                foreach (var deger in degerlendirme)
                {
                    var sinav = _context.Sinavs.Where(s => s.SinavId == deger.SinavId).ToList();
                    sinavlar.AddRange(sinav);


                }

                var sinavTuru = new List<SinavTuru>();
                var derslik = new List<Derslik>();

                foreach (var sinav in sinavlar)
                {
                    var sinavTemp = _context.SinavTurus.Where(st => st.SinavTuruId == sinav.SinavTuruId).ToList();
                    var derslikTemp = _context.Dersliks.Where(d => d.DerslikId == sinav.DerslikId);
                    derslik.AddRange(derslikTemp);
                    sinavTuru.AddRange(sinavTemp);
                }

                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    Sinav = sinavlar,
                    Degerlendirme = degerlendirme,
                    SinavTuru = sinavTuru,
                    Derslik = derslik,



                };
                return View("SinavTakvimi", viewModel);
            }

            return View();
        }


        //Transkipt fonksiyonu ve actionu
        public IActionResult Transkript()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();


                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                var degerlendirme = _context.Degerlendirmes.Where(d => d.OgrenciId == ogrenciId).ToList();

                var sinavlar = new List<Sinav>();

                foreach (var deger in degerlendirme)
                {
                    var sinav = _context.Sinavs.Where(s => s.SinavId == deger.SinavId).ToList();
                    sinavlar.AddRange(sinav);


                }

                var sinavTuru = new List<SinavTuru>();
                var derslik = new List<Derslik>();

                foreach (var sinav in sinavlar)
                {
                    var sinavTemp = _context.SinavTurus.Where(st => st.SinavTuruId == sinav.SinavTuruId).ToList();
                    var derslikTemp = _context.Dersliks.Where(d => d.DerslikId == sinav.DerslikId);
                    derslik.AddRange(derslikTemp);
                    sinavTuru.AddRange(sinavTemp);
                }
                var ogrenciDurum = _context.OgrenciDurums.FirstOrDefault(od => od.OgrenciDurumId == ogrenci.OgrenciDurumId);

                var dersTuruList = new List<DersTuru>();
                foreach (var ders in dersHavuzuList)
                {
                    var dersTuru = _context.DersTurus.Where(dt => dt.DersTuruId == ders.DersTuruId).ToList();
                    dersTuruList.AddRange(dersTuru);
                }
                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    Sinav = sinavlar,
                    Degerlendirme = degerlendirme,
                    SinavTuru = sinavTuru,
                    Derslik = derslik,
                    OgrenciDurum = ogrenciDurum,
                    DersTuru = dersTuruList,



                };
                return View("Transkript", viewModel);
            }
            return View();
        }


        float? HesaplaGANO()
        {
            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");

            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();


                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                var degerlendirme = _context.Degerlendirmes.Where(d => d.OgrenciId == ogrenciId).ToList();

                var sinavlar = new List<Sinav>();

                foreach (var deger in degerlendirme)
                {
                    var sinav = _context.Sinavs.Where(s => s.SinavId == deger.SinavId).ToList();
                    sinavlar.AddRange(sinav);


                }

                var sinavTuru = new List<SinavTuru>();
                var derslik = new List<Derslik>();

                foreach (var sinav in sinavlar)
                {
                    var sinavTemp = _context.SinavTurus.Where(st => st.SinavTuruId == sinav.SinavTuruId).ToList();
                    var derslikTemp = _context.Dersliks.Where(d => d.DerslikId == sinav.DerslikId);
                    derslik.AddRange(derslikTemp);
                    sinavTuru.AddRange(sinavTemp);
                }
                var ogrenciDurum = _context.OgrenciDurums.FirstOrDefault(od => od.OgrenciDurumId == ogrenci.OgrenciDurumId);

                var dersTuruList = new List<DersTuru>();
                foreach (var ders in dersHavuzuList)
                {
                    var dersTuru = _context.DersTurus.Where(dt => dt.DersTuruId == ders.DersTuruId).ToList();
                    dersTuruList.AddRange(dersTuru);
                }
                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    Sinav = sinavlar,
                    Degerlendirme = degerlendirme,
                    SinavTuru = sinavTuru,
                    Derslik = derslik,
                    OgrenciDurum = ogrenciDurum,
                    DersTuru = dersTuruList,



                };


                float? toplamNot = 0;
                float? toplamKredi = 0;

                foreach (var model in degerlendirme)
                {
                    foreach (var ders in dersHavuzuList)
                    {
                        string harfNotu = DersinNotunuBul(model);

                        // Harf notunu dörtlük sistemdeki değere çevir


                        float? dortlukDeger = DersinDortlukDegeriniBul(harfNotu);

                        // Dersin kredi değeriyle çarpıp toplama ekle
                        toplamNot += (ders.Kredi * dortlukDeger);
                        toplamKredi += ders.Kredi;
                    }
                }

                if (toplamKredi == 0)
                {
                    return 0;
                }
                return toplamNot / toplamKredi;
            }

            else
            {
                return 0;
            }


        }






        string DersinNotunuBul(Degerlendirme degerlendirme)
        {

            if (degerlendirme.SinavNotu >= 80)
            {
                if (degerlendirme.SinavNotu >= 85)
                {
                    return "AA";
                }
                else
                {
                    return "AB";
                }

            }
            else if (degerlendirme.SinavNotu >= 70)
            {
                if (degerlendirme.SinavNotu >= 75)
                {
                    return "BA";
                }
                else
                {
                    return "BB";
                }

            }
            else if (degerlendirme.SinavNotu >= 60)
            {
                if (degerlendirme.SinavNotu >= 65)
                {
                    return "CA";
                }
                else
                {
                    return "CB";
                }

            }
            else
            {
                return "FF";
            }
        }




        float? DersinDortlukDegeriniBul(string harf)
        {
            switch (harf)
            {
                case "AA":
                    return 4.0f;
                case "AB":
                    return 3.5f;
                case "BA":
                    return 3.0f;
                case "BB":
                    return 2.5f;
                case "CA":
                    return 2.0f;
                case "CB":
                    return 1.5f;
                case "FF":
                    return 0.0f;
                default:
                    return null;
            }
        }



        public async Task<IActionResult> IndirTranskriptPDF()
        {
            // GANO hesapla ve modeli al
            var gano = HesaplaGANO();
            var model = new OgrenciOzlukBilgileriViewModel(); // Bu kısmı projenizdeki modele göre değiştirin

            // Transkript sayfasını PDF olarak dönüştür
            var pdfStream = await new ViewAsPdf("Transkript", model)
            {
                FileName = "Transkript.pdf"
            }.BuildFile(ControllerContext);

            // PDF'yi kullanıcıya indirme olarak sun
            return File(pdfStream, "application/pdf", "Transkript.pdf");
        }



        public IActionResult DersKayit()
        {


            int? ogrenciId = HttpContext.Session.GetInt32("ogrenciId");
            if (ogrenciId != null)
            {


                var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.OgrenciId == ogrenciId);
                var bolum = _context.Bolums.FirstOrDefault(b => b.BolumId == ogrenci.BolumId);
                var mufredats = _context.Mufredats.Where(m => m.BolumId == bolum.BolumId).ToList();
                var dersHavuzuList = new List<DersHavuzu>();


                foreach (var mufredat in mufredats)
                {


                    var dersHavuzu = _context.DersHavuzus.Where(d => d.DersId == mufredat.DersId).ToList();
                    dersHavuzuList.AddRange(dersHavuzu);
                }

                var degerlendirme = _context.Degerlendirmes.Where(d => d.OgrenciId == ogrenciId).ToList();

                var sinavlar = new List<Sinav>();

                foreach (var deger in degerlendirme)
                {
                    var sinav = _context.Sinavs.Where(s => s.SinavId == deger.SinavId).ToList();
                    sinavlar.AddRange(sinav);


                }

                var sinavTuru = new List<SinavTuru>();
                var derslik = new List<Derslik>();

                foreach (var sinav in sinavlar)
                {
                    var sinavTemp = _context.SinavTurus.Where(st => st.SinavTuruId == sinav.SinavTuruId).ToList();
                    var derslikTemp = _context.Dersliks.Where(d => d.DerslikId == sinav.DerslikId);
                    derslik.AddRange(derslikTemp);
                    sinavTuru.AddRange(sinavTemp);
                }
                var ogrenciDurum = _context.OgrenciDurums.FirstOrDefault(od => od.OgrenciDurumId == ogrenci.OgrenciDurumId);

                var dersTuruList = new List<DersTuru>();
                foreach (var ders in dersHavuzuList)
                {
                    var dersTuru = _context.DersTurus.Where(dt => dt.DersTuruId == ders.DersTuruId).ToList();
                    dersTuruList.AddRange(dersTuru);
                }
                var viewModel = new OgrenciOzlukBilgileriViewModel
                {
                    Ogrenci = ogrenci,
                    Bolum = bolum,
                    Mufredat = mufredats,
                    DersHavuzu = dersHavuzuList,
                    Sinav = sinavlar,
                    Degerlendirme = degerlendirme,
                    SinavTuru = sinavTuru,
                    Derslik = derslik,
                    OgrenciDurum = ogrenciDurum,
                    DersTuru = dersTuruList,



                };

                return View("DersKayit", viewModel);
            }
            return View();
        }
    }
}
