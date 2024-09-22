using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class KullaniciTuru
{
    public int KullaniciTurId { get; set; }

    public string? KullaniciTurAdi { get; set; }

    public virtual ICollection<Kullanici> Kullanicis { get; set; } = new List<Kullanici>();
}
