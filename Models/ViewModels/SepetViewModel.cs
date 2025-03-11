namespace UmutYapi.Models.ViewModels
{
    public class SepetViewModel
    {
        public int UrunId { get; set; }
        public string Fotograf { get; set; }
        public string UrunAdi { get; set; }
        public string UrunAciklama { get; set; }
        public int Adet { get; set; }
        public decimal BirimFiyat { get; set; }
        public decimal ToplamFiyat { get; set; }
    }
}
