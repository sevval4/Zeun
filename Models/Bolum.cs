using System;
using System.Collections.Generic;

namespace Zeun.Web.Models;

public partial class Bolum
{
    public int BolumId { get; set; }

    public string? BolumAdi { get; set; }

    public int? ProgramTuruId { get; set; }

    public int? OgretimTuruId { get; set; }

    public int? BolumFakulteId { get; set; }

    public int? OgrenimDiliId { get; set; }

    public string? WebAdresi { get; set; }

    public virtual Fakulte? BolumFakulte { get; set; }

    public virtual ICollection<Mufredat> Mufredats { get; set; } = new List<Mufredat>();

    public virtual ICollection<Ogrenci> Ogrencis { get; set; } = new List<Ogrenci>();

    public virtual OgrenimDili? OgrenimDili { get; set; }

    public virtual ICollection<OgretimElemani> OgretimElemanis { get; set; } = new List<OgretimElemani>();

    public virtual OgretimTuru? OgretimTuru { get; set; }

    public virtual ProgramTuru? ProgramTuru { get; set; }

    public virtual ICollection<Yandal> Yandals { get; set; } = new List<Yandal>();
}
