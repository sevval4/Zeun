using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Yandal
{
    public int YandalId { get; set; }

    public int YandalBolumId { get; set; }

    public int YandalOgrenciId { get; set; }

    public virtual Bolum YandalBolum { get; set; } = null!;
}
