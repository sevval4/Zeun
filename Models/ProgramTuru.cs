using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class ProgramTuru
{
    public int ProgramTuruId { get; set; }

    public string? ProgramTurAdi { get; set; }

    public virtual ICollection<Bolum> Bolums { get; set; } = new List<Bolum>();
}
