using Moq;
using Zeun.Web.Models;

public static class OgrenciMockFactory
{
    public static Mock<Ogrenci> CreateMockOgrenci(int ogrenciId, int? bolumId, int? ogrenciDurumId, int? kullaniciId,
        string ogrenciNo, DateTime? kayitTarihi, DateTime? ayrilmaTarihi, string adi, string soyadi,
        string tckimlikNo, int? cinsiyetId, DateTime? dogumTarihi, string fotograf, string adres,
        string email, string telefonNumarasi, double? gano)
    {
        var mockOgrenci = new Mock<Ogrenci>();

        mockOgrenci.Setup(o => o.OgrenciId).Returns(ogrenciId);
        mockOgrenci.Setup(o => o.BolumId).Returns(bolumId);
        mockOgrenci.Setup(o => o.OgrenciDurumId).Returns(ogrenciDurumId);
        mockOgrenci.Setup(o => o.KullaniciId).Returns(kullaniciId);
        mockOgrenci.Setup(o => o.OgrenciNo).Returns(ogrenciNo);
        mockOgrenci.Setup(o => o.KayitTarihi).Returns(kayitTarihi);
        mockOgrenci.Setup(o => o.AyrilmaTarihi).Returns(ayrilmaTarihi);
        mockOgrenci.Setup(o => o.Adi).Returns(adi);
        mockOgrenci.Setup(o => o.Soyadi).Returns(soyadi);
        mockOgrenci.Setup(o => o.TckimlikNo).Returns(tckimlikNo);
        mockOgrenci.Setup(o => o.CinsiyetId).Returns(cinsiyetId);
        mockOgrenci.Setup(o => o.DogumTarihi).Returns(dogumTarihi);
        mockOgrenci.Setup(o => o.Fotograf).Returns(fotograf);
        mockOgrenci.Setup(o => o.Adres).Returns(adres);
        mockOgrenci.Setup(o => o.Email).Returns(email);
        mockOgrenci.Setup(o => o.TelefonNumarasi).Returns(telefonNumarasi);
        mockOgrenci.Setup(o => o.Gano).Returns(gano);

        // Set up relationships or other properties as needed

        return mockOgrenci;
    }

    internal static object CreateMockOgrenci()
    {
        throw new NotImplementedException();
    }
}



