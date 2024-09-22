using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Ogrenci
{
    public int OgrenciId { get; set; }

    public int? BolumId { get; set; }

    public int? OgrenciDurumId { get; set; }

    public int? KullaniciId { get; set; }

    public string? OgrenciNo { get; set; }

    public DateTime? KayitTarihi { get; set; }

    public DateTime? AyrilmaTarihi { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? TckimlikNo { get; set; }

    public int? CinsiyetId { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Fotograf { get; set; }

    public string? Adres { get; set; }

    public string? Email { get; set; }

    public string? TelefonNumarasi { get; set; }

    public double? Gano { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual Cinsiyet? Cinsiyet { get; set; }

    public virtual ICollection<Danismanlik> Danismanliks { get; set; } = new List<Danismanlik>();

    public virtual ICollection<Degerlendirme> Degerlendirmes { get; set; } = new List<Degerlendirme>();

    public virtual ICollection<DersAlma> DersAlmas { get; set; } = new List<DersAlma>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual OgrenciDurum? OgrenciDurum { get; set; }
}
