using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Zeun.Web.Controllers;
using Zeun.Web.Data;
using Zeun.Web.Models;

public class OgrenciControllerTests
{
    [Fact]
    public void BolumMufredati_Action_Returns_ViewResult_With_Valid_Model()
    {
        // Arrange
        var ogrenciId = 1;
        var bolumId = 2;
        var ogrenciDurumId = 3;
        var kullaniciId = 4;
        var ogrenciNo = "O12346";
        var kayitTarihi = DateTime.Now;
        var ayrilmaTarihi = DateTime.Now.AddDays(30);
        var adi = "Enes";
        var soyadi = "Köse";
        var tckimlikNo = "12345678921";
        var cinsiyetId = 1;
        var dogumTarihi = new DateTime(1990, 1, 1);
        var fotograf = "path/to/photo.jpg";
        var adres = "Sample Address";
        var email = "enskse@example.com";
        var telefonNumarasi = "555-1234";
        var gano = 3.5;

        var mockOgrenci1 = OgrenciMockFactory.CreateMockOgrenci(
            ogrenciId, bolumId, ogrenciDurumId, kullaniciId, ogrenciNo,
            kayitTarihi, ayrilmaTarihi, adi, soyadi, tckimlikNo,
            cinsiyetId, dogumTarihi, fotograf, adres, email,
            telefonNumarasi, gano);

        var mockDbContext = new Mock<OgrenciDbContext>();
        mockDbContext.Setup(c => c.Ogrencis).Returns(new Mock<DbSet<Ogrenci>>().Object);
        mockDbContext.Object.Ogrencis.Add(mockOgrenci1.Object);

        var controller = new OgrenciController(mockDbContext.Object);

        // Act
        var result = controller.BolumMufredati() as ViewResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal("BolumMufredati", result.ViewName);

        var model = result.Model as OgrenciOzlukBilgileriViewModel;
        Assert.NotNull(model);

    }

}
