namespace UmutYapi.Models.Tablolar
{
    public class UrunKategori : Entity
    {
        public string KategoriAdi { get; set; }
        public virtual List<Urun> Urunler { get; set; }
    }
}
