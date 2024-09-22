using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zeun.Web.Models;


[Table("DersHavuzu")]
public partial class DersHavuzu
{
    public int DersId { get; set; }

    public int? DersDiliId { get; set; }

    public int? DersSeviyesiId { get; set; }

    public int? DersTuruId { get; set; }

    public string? DersKodu { get; set; }

    public string? DersAdi { get; set; }

    public int? Teorik { get; set; }

    public int? Uygulama { get; set; }

    public float? Kredi { get; set; }

    public int? Ects { get; set; }

    public virtual DersDili? DersDili { get; set; }

    public virtual DersSeviyesi? DersSeviyesi { get; set; }

    public virtual DerslikTuru? DersTuru { get; set; }

    public virtual ICollection<Mufredat> Mufredats { get; set; } = new List<Mufredat>();
}
