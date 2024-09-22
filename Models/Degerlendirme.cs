using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Degerlendirme
{
    public int DegerlendirmeId { get; set; }

    public int? SinavId { get; set; }

    public int? OgrenciId { get; set; }

    public float? SinavNotu { get; set; }

    public virtual Ogrenci? Ogrenci { get; set; }

    public virtual Sinav? Sinav { get; set; }
}
