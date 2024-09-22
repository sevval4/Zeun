using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Zeun.Web.Controllers;
using Zeun.Web.Data;
using Zeun.Web.Models;

namespace Zeun.Web.Tests.Controllers
{
    [TestFixture]
    public class LoginControllerTests
    {
        [Test]
        public async Task Login_ValidCredentials_RedirectToOgrenciIndex()
        {
            // Arrange
            var contextMock = new Mock<OgrenciDbContext>();
            var controller = new LoginController(contextMock.Object);

            var model = new Kullanici
            {
                KullaniciAdi = "testUser",
                Parola = "testPassword"
            };

            var kullanici = new Kullanici
            {
                KullaniciAdi = "testUser",
                Parola = "testPassword",
                KullaniciTuruId = 1,
                KullaniciId = 1
            };

            var kullaniciTuru = new KullaniciTuru
            {
                KullaniciTurId = 1,
                KullaniciTurAdi = "Ogrenci"
            };

            var ogrenci = new Ogrenci
            {
                KullaniciId = 1,
                OgrenciId = 123
            };

            contextMock.Setup(c => c.Kullanicis.FirstOrDefault(It.IsAny<Func<Kullanici, bool>>())).Returns(kullanici);
            contextMock.Setup(c => c.KullaniciTurus.FirstOrDefault(It.IsAny<Func<KullaniciTuru, bool>>())).Returns(kullaniciTuru);
            contextMock.Setup(c => c.Ogrencis.FirstOrDefault(It.IsAny<Func<Ogrenci, bool>>())).Returns(ogrenci);

            var serviceProvider = new ServiceCollection()
                .AddAuthentication()
                .AddCookie()
                .Services.BuildServiceProvider();

            controller.ControllerContext.HttpContext = new DefaultHttpContext
            {
                RequestServices = serviceProvider
            };

            // Act
            var result = await controller.Login(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("Ogrenci", result.ControllerName);
        }

        [Test]
        public async Task Login_InvalidCredentials_ReturnsErrorView()
        {
            // Arrange
            var contextMock = new Mock<OgrenciDbContext>();
            var controller = new LoginController(contextMock.Object);

            var model = new Kullanici
            {
                KullaniciAdi = "invalidUser",
                Parola = "invalidPassword"
            };

            contextMock.Setup(c => c.Kullanicis.FirstOrDefault(It.IsAny<Func<Kullanici, bool>>())).Returns((Kullanici)null);

            // Act
            var result = await controller.Login(model) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ViewName);
            Assert.AreEqual("Kullanıcı Bilgileri Geçersiz", result.ViewData["Error"]);
        }

        [Test]
        public async Task Login_ValidCredentials_OgretimElemani_RedirectToOgretimElemaniIndex()
        {
            // Arrange
            var contextMock = new Mock<OgrenciDbContext>();
            var controller = new LoginController(contextMock.Object);

            var model = new Kullanici
            {
                KullaniciAdi = "testUser",
                Parola = "testPassword"
            };

            var kullanici = new Kullanici
            {
                KullaniciAdi = "testUser",
                Parola = "testPassword",
                KullaniciTuruId = 2
            };

            var kullaniciTuru = new KullaniciTuru
            {
                KullaniciTurId = 2,
                KullaniciTurAdi = "OgretimElemani"
            };

            contextMock.Setup(c => c.Kullanicis.FirstOrDefault(It.IsAny<Func<Kullanici, bool>>())).Returns(kullanici);
            contextMock.Setup(c => c.KullaniciTurus.FirstOrDefault(It.IsAny<Func<KullaniciTuru, bool>>())).Returns(kullaniciTuru);

            // Act
            var result = await controller.Login(model) as RedirectToActionResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.ActionName);
            Assert.AreEqual("OgretimElemani", result.ControllerName);
        }
    }
}
