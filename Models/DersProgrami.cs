using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class DersProgrami
{
    public int DersProgramiId { get; set; }

    public int? DersAcmaId { get; set; }

    public int? DerslikId { get; set; }

    public int? DersGunuId { get; set; }

    public int? DersSaatiId { get; set; }

    public virtual DersAcma? DersAcma { get; set; }

    public virtual DersGunu? DersGunu { get; set; }

    public virtual DersSaati? DersSaati { get; set; }

    public virtual Derslik? Derslik { get; set; }
}
