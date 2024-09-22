using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersSaati
{
    public int DersSaatiId { get; set; }

    public string? DersSaati1 { get; set; }

    public virtual ICollection<DersProgrami> DersProgramis { get; set; } = new List<DersProgrami>();
}
