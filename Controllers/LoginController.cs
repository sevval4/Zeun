using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Zeun.Web.Data;
using Zeun.Web.Models;

namespace Zeun.Web.Controllers
{
     // Login Controller oluşturuldu
    public class LoginController : Controller
    {
        private readonly OgrenciDbContext _context;
        // DbCOntext  enjekte edildi
        public LoginController(OgrenciDbContext context)
        {
            _context = context;
        }


        // index action'u
        public IActionResult Index()
        {
            return View();
        }



        // asenkron login kısmı   claimler ve seasonlar kullanıldı autentication ve autherization 
        [HttpPost]
        public async Task<IActionResult> Login(Kullanici model)
        {
            var kullanici = _context.Kullanicis.FirstOrDefault(k => k.KullaniciAdi == model.KullaniciAdi & k.Parola == model.Parola);
            var kullaniciTuru = _context.KullaniciTurus.FirstOrDefault(kt => kt.KullaniciTurId == kullanici.KullaniciTuruId);
            if (kullaniciTuru != null)
            {

                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, kullanici.KullaniciAdi),
            new Claim(ClaimTypes.Role, kullaniciTuru.KullaniciTurAdi),

        };



                //Kullanıcı türü 1 olan yani öğrenciye geçiş yapma

                if (kullanici.KullaniciTuruId == 1)
                {
                    var ogrenci = _context.Ogrencis.FirstOrDefault(o => o.KullaniciId == kullanici.KullaniciId);
                    var OgrenciId = ogrenci.OgrenciId;
                    claims.Add(new Claim("OgrenciId", OgrenciId.ToString() ?? string.Empty));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                   authProperties);

                    HttpContext.Session.SetInt32("ogrenciId", ogrenci.OgrenciId);




                    return RedirectToAction("Index", "Ogrenci");

                }
                //öğretim elemanına geçiş yapma
                else if (kullanici.KullaniciTuruId == 2)
                {
                    var ogretimElemani = _context.OgretimElemanis.FirstOrDefault(o => o.KullaniciId == kullanici.KullaniciId);
                    var ogretimElemaniId = ogretimElemani.OgretimElemaniId;
                    claims.Add(new Claim("OgretimElemaniId", ogretimElemaniId.ToString() ?? string.Empty));
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties();
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
                   authProperties);


                    //season kullanımı
                    HttpContext.Session.SetInt32("ogretimElemaniId", ogretimElemani.OgretimElemaniId);

                    return RedirectToAction("Index", "OgretimElemani");

                }


            }

            // hatalı mesajı gösterme
            ViewBag.Error = "Kullanıcı Bilgileri Geçersiz";
            return View("Index");
        }

    }
}
