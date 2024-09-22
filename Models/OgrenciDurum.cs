using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class OgrenciDurum
{
    public int OgrenciDurumId { get; set; }

    public string? OgrenciDurumu { get; set; }

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();
}
