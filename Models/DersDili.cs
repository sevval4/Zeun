using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersDili
{
    public int DersDiliId { get; set; }

    public string? DersDili1 { get; set; }

    public virtual ICollection<DersHavuzu> DersHavuzus { get; set; } = new List<DersHavuzu>();
}
