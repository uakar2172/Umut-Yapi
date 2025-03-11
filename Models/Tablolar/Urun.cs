
namespace UmutYapi.Models.Tablolar
{
    public class Urun : Entity
    {
        public string UrunKodu { get; set; }
        public string UrunAdi { get; set; }
        public decimal UrunFiyati { get; set; }
        public string Aciklama { get; set; }
        public int StokAdeti { get; set; }
        public string? StokAdetiBirimi { get; set; }
        public string? UrunFoto { get; set; }
        public int KategoriId { get; set; }
        public virtual UrunKategori Kategori { get; set; }
        
    }
}
