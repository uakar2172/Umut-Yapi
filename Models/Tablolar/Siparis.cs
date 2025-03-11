namespace UmutYapi.Models.Tablolar
{
    public class Siparis : Entity
    {
        public Guid KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; }
        public decimal SiparisTutarı { get; set; }
        public DateTime SatınAlmaTarihi { get; set; }
        public virtual ICollection<SiparisItem> SiparisItems { get; set; }
    }
}
