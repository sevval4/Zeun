using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zeun.Web.Models;

[Table("Mufredat")]
public partial class Mufredat
{
    public int MufredatId { get; set; }

    public int? BolumId { get; set; }

    public int? AkademikYiIid { get; set; }

    public int? AkademikDonemId { get; set; }

    public int? DersId { get; set; }

    public int? DersDonemi { get; set; }

    public virtual AkademikDonem? AkademikDonem { get; set; }

    public virtual AkademikYil? AkademikYiI { get; set; }

    public virtual Bolum? Bolum { get; set; }

    public virtual DersHavuzu? Ders { get; set; }

    public virtual ICollection<DersAcma> DersAcmas { get; set; } = new List<DersAcma>();
}
