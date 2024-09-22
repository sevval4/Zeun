using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersSeviyesi
{
    public int DersSeviyesiId { get; set; }

    public string? DersSeviyesi1 { get; set; }

    public virtual ICollection<DersHavuzu> DersHavuzus { get; set; } = new List<DersHavuzu>();
}
