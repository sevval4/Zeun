using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Derslik
{
    public int DerslikId { get; set; }

    public int? DerslikTuruId { get; set; }

    public string? DerslikAdi { get; set; }

    public int? Kapasite { get; set; }

    public virtual ICollection<DersProgrami> DersProgramis { get; set; } = new List<DersProgrami>();

    public virtual DerslikTuru? DerslikTuru { get; set; }

    public virtual ICollection<Sinav> Sinavs { get; set; } = new List<Sinav>();
}
