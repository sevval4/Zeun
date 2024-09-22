using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Unvan
{
    public int UnvanId { get; set; }

    public string? UnvanAdi { get; set; }

    public virtual ICollection<OgretimElemani> OgretimElemanis { get; set; } = new List<OgretimElemani>();
}
