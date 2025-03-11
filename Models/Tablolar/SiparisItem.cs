namespace UmutYapi.Models.Tablolar
{
    public class SiparisItem : Entity
    {
        public int UrunId { get; set; }
        public int Adet { get; set; }
        public int SiparisId { get; set; }
        public virtual Siparis Siparis { get; set; }
    }
}
