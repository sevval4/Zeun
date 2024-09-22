using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class OgretimElemani
{
    public int OgretimElemaniId { get; set; }

    public int? BolumId { get; set; }

    public int? KullaniciId { get; set; }

    public int? UnvanId { get; set; }

    public string? KurumSicilNo { get; set; }

    public string? Adi { get; set; }

    public string? Soyadi { get; set; }

    public string? TckimlikNo { get; set; }

    public int? CinsiyetId { get; set; }

    public DateTime? DogumTarihi { get; set; }

    public string? Fotograf { get; set; }

    public string? Adres { get; set; }

    public string? Email { get; set; }

    public string? Telefon { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual Cinsiyet? Cinsiyet { get; set; }

    public virtual ICollection<Danismanlik> Danismanliks { get; set; } = new List<Danismanlik>();

    public virtual ICollection<DersAcma> DersAcmas { get; set; } = new List<DersAcma>();

    public virtual Kullanici? Kullanici { get; set; }

    public virtual ICollection<Sinav> Sinavs { get; set; } = new List<Sinav>();

    public virtual Unvan? Unvan { get; set; }
}
