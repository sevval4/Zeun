using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class AkademikDonem
{
    public int AkademikDonemId { get; set; }

    public string? AkademikDonem1 { get; set; }

    public virtual ICollection<DersAcma> DersAcmas { get; set; } = new List<DersAcma>();

    public virtual ICollection<Mufredat> Mufredats { get; set; } = new List<Mufredat>();
}
