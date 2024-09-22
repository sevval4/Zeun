using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class OgrenimDili
{
    public int OgrenimDiliId { get; set; }

    public string? OgrenimDili1 { get; set; }

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();
}
