using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersGunu
{
    public int DersGunuId { get; set; }

    public string? DersGunu1 { get; set; }

    public virtual ICollection<DersProgrami> DersProgramis { get; set; } = new List<DersProgrami>();
}
