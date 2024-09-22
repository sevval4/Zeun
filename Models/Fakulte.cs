using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Fakulte
{
    public int FakulteId { get; set; }

    public string FakulteAdi { get; set; } = null!;

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();
}
