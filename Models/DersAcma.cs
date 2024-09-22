using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersAcma
{
    public int DersAcmaId { get; set; }

    public int? AkademikYilId { get; set; }

    public int? AkademikDonemId { get; set; }

    public int? MufredatId { get; set; }

    public int? OgrElmId { get; set; }

    public int? Kontejan { get; set; }

    public virtual AkademikDonem? AkademikDonem { get; set; }

    public virtual AkademikYil? AkademikYil { get; set; }

    public virtual ICollection<DersAlma> DersAlmas { get; set; } = new List<DersAlma>();

    public virtual ICollection<DersProgrami> DersProgramis { get; set; } = new List<DersProgrami>();

    public virtual Mufredat? Mufredat { get; set; }

    public virtual OgretimElemani? OgrElm { get; set; }

    public virtual ICollection<Sinav> Sinavs { get; set; } = new List<Sinav>();

    

}
