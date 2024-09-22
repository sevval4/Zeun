using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class SinavTuru
{
    public int SinavTuruId { get; set; }

    public string SinavTuru1 { get; set; } = null!;

    public virtual ICollection<Sinav> Sinavs { get; set; } = new List<Sinav>();
}
