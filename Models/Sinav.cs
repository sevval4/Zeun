using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Sinav
{
    public int SinavId { get; set; }

    public int? DersAcmaId { get; set; }

    public int? SinavTuruId { get; set; }

    public int? DerslikId { get; set; }

    public int? OgrElmId { get; set; }

    public int? EtkiOrani { get; set; }

    public DateTime? SinavTarihi { get; set; }

    public DateTime? SinavSaati { get; set; }

    public virtual ICollection<Degerlendirme> Degerlendirmes { get; set; } = new List<Degerlendirme>();

    public virtual DersAcma? DersAcma { get; set; }

    public virtual Derslik? Derslik { get; set; }

    public virtual OgretimElemani? OgrElm { get; set; }

    public virtual SinavTuru? SinavTuru { get; set; }
}
