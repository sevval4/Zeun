using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zeun.Web.Models;

namespace Zeun.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // HomeController sınıfının constructor'ı
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa için action metodu
        public IActionResult Index()
        {
            return View();
        }

        // Gizlilik sayfası için action metodu
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata sayfası için action metodu
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Hata sayfasını görüntüler ve ilgili bilgileri modelle paylaşır
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
