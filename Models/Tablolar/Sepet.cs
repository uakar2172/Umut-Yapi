namespace UmutYapi.Models.Tablolar
{
    public class Sepet : Entity
    {
        public virtual List<SepetItem> SepetItems { get; set; }
        public Guid KullaniciId { get; set; }
        public virtual Kullanici Kullanici { get; set; } // Kullanici ile ilişki tanımlandı
    }
}
