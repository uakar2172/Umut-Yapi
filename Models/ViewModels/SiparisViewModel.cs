namespace UmutYapi.Models.ViewModels
{
    public class SiparisViewModel
    {
        public int SiparisId { get; set; }
        public decimal SiparisTutarı => SiparisItems.Sum(x => x.ToplamFiyat);
        public List<SiparisItemViewModel> SiparisItems { get; set; } = new List<SiparisItemViewModel>();
    }
    public class SiparisItemViewModel
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public string Forograf { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat => BirimFiyat * Adet;
    }
}
