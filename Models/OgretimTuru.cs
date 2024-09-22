using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class OgretimTuru
{
    public int OgretimTuruId { get; set; }

    public string? OgretimTurAdi { get; set; }

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();
}
