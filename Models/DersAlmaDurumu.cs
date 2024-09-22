using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersAlmaDurumu
{
    public int DersAlmaDurumId { get; set; }

    public string? DersAlmaDurumu1 { get; set; }

    public virtual ICollection<DersAlma> DersAlmas { get; set; } = new List<DersAlma>();
}
