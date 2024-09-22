using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Cinsiyet
{
    public int CinsiyetId { get; set; }

    public string? CinsiyetAdi { get; set; }

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();

    public virtual ICollection<OgretimElemani> OgretimElemanis { get; set; } = new List<OgretimElemani>();
}
