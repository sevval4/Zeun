using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class AkademikYil
{
    public int AkademikYilId { get; set; }

    public string? AkademikYil1 { get; set; }

    public virtual ICollection<DersAcma> DersAcmas { get; set; } = new List<DersAcma>();

    public virtual ICollection<Mufredat> Mufredats { get; set; } = new List<Mufredat>();
}
