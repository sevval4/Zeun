using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Kullanici
{
    public int KullaniciId { get; set; }

    public int? KullaniciTuruId { get; set; }

    public string? KullaniciAdi { get; set; }

    public string? Parola { get; set; }

    public virtual KullaniciTuru? KullaniciTuru { get; set; }

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();

    public virtual ICollection<OgretimElemani> OgretimElemanis { get; set; } = new List<OgretimElemani>();
}
