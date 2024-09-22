using Zeun.Web.Controllers;

namespace Zeun.Web.Models
{
    public class OgretimElemaniViewModel
    {
        public OgretimElemani OgretimElemani { get; set; }
        public Unvan Unvan { get; set; }
        public Bolum Bolum { get; set; }
        public Danismanlik Danismanlik { get; set; }
        public List<Mufredat> Mufredat { get; set; }
        public List<DersAcma> DersAcma { get; set; }
        public List<DersTuru> DersTuru { get; set; }
        public List<DersDili> DersDili { get; set; }
       
        public List<DersProgrami> DersProgrami { get; set; }
        public List<Sinav> Sinav { get; set; }
        public List<Degerlendirme> Degerlendirme { get; set; }
        public List<SinavTuru> SinavTuru { get; set; }
        public List<Derslik> Derslik { get; set; }
        public List<AkademikDonem> AkademikDonem { get; set; }
    }
}
