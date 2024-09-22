using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersAlma
{
    public int DersAlmaId { get; set; }

    public int? DersAcmaId { get; set; }

    public int? OgrenciId { get; set; }

    public int? DersAlmaDurumId { get; set; }

    public virtual DersAcma? DersAcma { get; set; }

    public virtual DersAlmaDurumu? DersAlmaDurum { get; set; }

    public virtual Ogrenci? Ogrenci { get; set; }

    public List<DersHavuzu> DersHavuzu { get; set; }
}
