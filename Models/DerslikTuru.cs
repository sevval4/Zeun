using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DerslikTuru
{
    public int DerslikTuruId { get; set; }

    public string? DerslikTuruAdi { get; set; }

    public virtual ICollection<DersHavuzu> DersHavuzus { get; set; } = new List<DersHavuzu>();

    public virtual ICollection<Derslik> Dersliks { get; set; } = new List<Derslik>();
}
