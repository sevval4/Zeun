using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Danismanlik
{
    public int DanismanlikId { get; set; }

    public int? OgrElmId { get; set; }

    public int? OgrenciId { get; set; }

    public virtual OgretimElemani? OgrElm { get; set; }

    public virtual Ogrenci? Ogrenci { get; set; }
}
