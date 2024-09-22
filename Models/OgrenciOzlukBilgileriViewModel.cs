namespace Zeun.Web.Models
{
    public class OgrenciOzlukBilgileriViewModel
    {

        public Ogrenci Ogrenci { get; set; }
        public Bolum Bolum { get; set; }
        public Danismanlik Danismanlik { get; set; }
     
        public OgrenciDurum OgrenciDurum { get; set; }
        public List<Mufredat> Mufredat { get; set; }
      
        public List<AkademikYil> AkademikYil { get; set; }
        public List<DersHavuzu> DersHavuzu { get; set; }
        public List<DersAlma> DersAlma { get; set; }
        public List<DersAcma> DersAcma { get; set; }
        public List<DersTuru> DersTuru { get; set;}
        public List<DersDili> DersDili { get; set;}
        public List<OgretimElemani> OgretimElemani { get; set; }
        public List<DersProgrami> DersProgrami { get; set; }
        public List<Sinav> Sinav { get; set; }
        public List<Degerlendirme> Degerlendirme { get; set; }
        public List<SinavTuru> SinavTuru { get; set; }
        public List<Derslik> Derslik { get; set; }
        public List<AkademikDonem> AkademikDonem { get; set; }







    }
}
