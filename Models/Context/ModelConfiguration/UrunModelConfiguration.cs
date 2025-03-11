using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class UrunModelConfiguration : IEntityTypeConfiguration<Urun>
    {
        public void Configure(EntityTypeBuilder<Urun> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Kategori).WithMany(x => x.Urunler).HasForeignKey(x => x.KategoriId);

            builder.HasData(
               new Urun() { Id = 1, Aciklama = "50KG", UrunKodu = "B-0001", KategoriId = 1, UrunAdi = "Çimento", StokAdeti = 1900, UrunFiyati = 200, OlusturmaTarihi = DateTime.Now ,UrunFoto="çimento.jpg",StokAdetiBirimi="Kg"},
               new Urun() { Id = 2, Aciklama="İnce Kum", UrunKodu = "B-0002", KategoriId = 1, UrunAdi="Kum", StokAdeti=10000, UrunFiyati=60, OlusturmaTarihi = DateTime.Now,UrunFoto="kum.jpg",StokAdetiBirimi="Ton"},
               new Urun() { Id = 3, Aciklama = "Kırma Çakıl", UrunKodu = "B-0003", KategoriId = 1, UrunAdi = "Çakıl", StokAdeti = 8000, UrunFiyati = 240, OlusturmaTarihi = DateTime.Now , UrunFoto = "çakıl.jpg", StokAdetiBirimi = "Ton" },
               new Urun() { Id = 4, Aciklama = "5cm", UrunKodu = "Y-0001", KategoriId = 2, UrunAdi = "Strafor", StokAdeti = 700, UrunFiyati = 250, OlusturmaTarihi = DateTime.Now , UrunFoto = "strafor.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 5, Aciklama = "10cm", UrunKodu = "Y-0002", KategoriId = 2, UrunAdi = "Cam Yünü", StokAdeti = 650, UrunFiyati = 300, OlusturmaTarihi = DateTime.Now , UrunFoto = "cam yünü.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 6, Aciklama = "5cm", UrunKodu = "Y-0003", KategoriId = 2, UrunAdi = "Taş yünü", StokAdeti = 500, UrunFiyati = 400, OlusturmaTarihi = DateTime.Now , UrunFoto = "taş yünü.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 7, Aciklama = "3mm", UrunKodu = "Y-0004", KategoriId = 2, UrunAdi = "Su Yalıtım Membranı", StokAdeti = 1000, UrunFiyati = 50, OlusturmaTarihi = DateTime.Now , UrunFoto = "su membranı.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 8, Aciklama = "40mm", UrunKodu = "Y-0005", KategoriId = 2, UrunAdi = "Akustik Panel", StokAdeti = 150, UrunFiyati = 50, OlusturmaTarihi = DateTime.Now, UrunFoto = "akustik panel.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 9, Aciklama = "Yığma", UrunKodu = "D-0001", KategoriId = 3, UrunAdi = "Tuğla", StokAdeti = 5000, UrunFiyati = 7, OlusturmaTarihi = DateTime.Now , UrunFoto = "tuğla1.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 10, Aciklama = "5'lik", UrunKodu = "D-0002", KategoriId = 3, UrunAdi = "Ytong", StokAdeti = 3000, UrunFiyati = 190, OlusturmaTarihi = DateTime.Now , UrunFoto = "ytong tuğla.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 11, Aciklama = "G4", UrunKodu = "D-0003", KategoriId = 3, UrunAdi = "Gaz Beton", StokAdeti = 2800, UrunFiyati = 180, OlusturmaTarihi = DateTime.Now , UrunFoto = "gaz beton.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 12, Aciklama = "Duvar Karosu", UrunKodu = "D-0004", KategoriId = 3, UrunAdi = "Seramik", StokAdeti = 3000, UrunFiyati = 340, OlusturmaTarihi = DateTime.Now, UrunFoto = "seramik.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 13, Aciklama = "Seramik", UrunKodu = "D-0005", KategoriId = 3, UrunAdi = "Fayans", StokAdeti = 3300, UrunFiyati = 280, OlusturmaTarihi = DateTime.Now , UrunFoto = "fayans.png", StokAdetiBirimi = "m3" },
               new Urun() { Id = 14, Aciklama = "Ahşap", UrunKodu = "D-0006", KategoriId = 3, UrunAdi = "Laminant Parke", StokAdeti = 4000, UrunFiyati = 450, OlusturmaTarihi = DateTime.Now , UrunFoto = "laminant.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 15, Aciklama = "Kahverengi Renk", UrunKodu = "K-0001", KategoriId = 4, UrunAdi = "Ahşap Kapı", StokAdeti = 100, UrunFiyati = 2000, OlusturmaTarihi = DateTime.Now , UrunFoto = "ahşap kapı.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 16, Aciklama = "Gri Renk", UrunKodu = "K-0002", KategoriId = 4, UrunAdi = "Çelik Kapı", StokAdeti = 100, UrunFiyati = 2500, OlusturmaTarihi = DateTime.Now , UrunFoto = "çelik kapı.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 17, Aciklama = "Çift Açılım", UrunKodu = "K-0003", KategoriId = 4, UrunAdi = "PVC Pencere", StokAdeti = 200, UrunFiyati = 1900, OlusturmaTarihi = DateTime.Now , UrunFoto = "pvc pencere.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 18, Aciklama = "Giyotin", UrunKodu = "K-0004", KategoriId = 4, UrunAdi = "Ahşap Pencere", StokAdeti = 230, UrunFiyati = 2500, OlusturmaTarihi = DateTime.Now, UrunFoto = "ahşap pencere.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 19, Aciklama = "Fonksiyonel", UrunKodu = "K-0005", KategoriId = 4, UrunAdi = "Menteşe", StokAdeti = 4003, UrunFiyati = 6, OlusturmaTarihi = DateTime.Now , UrunFoto = "menteşe.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 20, Aciklama = "Asma", UrunKodu = "K-0006", KategoriId = 1, UrunAdi = "Kilit", StokAdeti = 400, UrunFiyati = 70, OlusturmaTarihi = DateTime.Now, UrunFoto = "kilit.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 21, Aciklama = "Krom Kaplama", UrunKodu = "K-0007", KategoriId = 4, UrunAdi = "Kulp", StokAdeti = 280, UrunFiyati = 30, OlusturmaTarihi = DateTime.Now , UrunFoto = "kapı kulp.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 22, Aciklama = "Plastik Boya", UrunKodu = "BK-0001", KategoriId = 5, UrunAdi = "Plastik Boya", StokAdeti = 200, UrunFiyati = 50, OlusturmaTarihi = DateTime.Now, UrunFoto = "plastik boya.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 23, Aciklama = "Silikonlu Boya", UrunKodu = "BK-0002", KategoriId = 5, UrunAdi = "Silikonlu Boya", StokAdeti = 250, UrunFiyati = 80, OlusturmaTarihi = DateTime.Now , UrunFoto = "silikonlu boya.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 24, Aciklama = "Saten Boya", UrunKodu = "BK-0003", KategoriId = 5, UrunAdi = "Dekoratif Kaplama", StokAdeti = 4000, UrunFiyati = 140, OlusturmaTarihi = DateTime.Now, UrunFoto = "dekoratif kaplama.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 25, Aciklama = "Meşe", UrunKodu = "A-0001", KategoriId = 6, UrunAdi = "Kereste", StokAdeti = 5000, UrunFiyati = 160, OlusturmaTarihi = DateTime.Now, UrunFoto = "kereste.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 26, Aciklama = "Filmli", UrunKodu = "A-0002", KategoriId = 6, UrunAdi = "Plywood", StokAdeti = 4000, UrunFiyati = 280, OlusturmaTarihi = DateTime.Now, UrunFoto = "plywood.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 27, Aciklama = "MDF Lam", UrunKodu = "A-0003", KategoriId = 6, UrunAdi = "MDF", StokAdeti = 3900, UrunFiyati = 200, OlusturmaTarihi = DateTime.Now , UrunFoto = "mdf.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 28, Aciklama = "Turuncu Renk", UrunKodu = "A-0004", KategoriId = 6, UrunAdi = "Sunta", StokAdeti = 2800, UrunFiyati = 80, OlusturmaTarihi = DateTime.Now , UrunFoto = "sunta.jpg", StokAdetiBirimi = "m3" },
               new Urun() { Id = 29, Aciklama = "Çok Telli", UrunKodu = "E-00001", KategoriId = 7, UrunAdi = "NYA Kablo", StokAdeti = 1500, UrunFiyati = 40, OlusturmaTarihi = DateTime.Now , UrunFoto = "nya kablo.jpg", StokAdetiBirimi = "Metre" },
               new Urun() { Id = 30, Aciklama = "G4", UrunKodu = "E-0002", KategoriId = 7, UrunAdi = "Duy Priz", StokAdeti = 900, UrunFiyati = 25, OlusturmaTarihi = DateTime.Now , UrunFoto = "duy priz.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 31, Aciklama = "Komülatör", UrunKodu = "E-0003", KategoriId = 7, UrunAdi = "Anahtar", StokAdeti = 800, UrunFiyati = 15, OlusturmaTarihi = DateTime.Now , UrunFoto = "anahtar.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 32, Aciklama = "Beyaz Renk", UrunKodu = "E-0004", KategoriId = 7, UrunAdi = "Led Ampul", StokAdeti = 1000, UrunFiyati = 80, OlusturmaTarihi = DateTime.Now , UrunFoto = "led ampul.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 33, Aciklama = "PLC 2 Pinli", UrunKodu = "E-0005", KategoriId = 7, UrunAdi = "Florasan Lamba", StokAdeti = 600, UrunFiyati = 40, OlusturmaTarihi = DateTime.Now, UrunFoto = "florasan.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 34, Aciklama = "250mm", UrunKodu = "S-0001", KategoriId = 8, UrunAdi = "PVC Boru", StokAdeti = 700, UrunFiyati = 20, OlusturmaTarihi = DateTime.Now, UrunFoto = "pcv boru.jpg", StokAdetiBirimi = "Metre" },
               new Urun() { Id = 35, Aciklama = "Uzun Musluk", UrunKodu = "S-0002", KategoriId = 8, UrunAdi = "Musluk", StokAdeti = 1000, UrunFiyati = 190, OlusturmaTarihi = DateTime.Now , UrunFoto = "musluk.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 36, Aciklama = "Krom Menfez", UrunKodu = "S-0003", KategoriId = 8, UrunAdi = "Menfez", StokAdeti = 400, UrunFiyati = 50, OlusturmaTarihi = DateTime.Now ,UrunFoto="menfez.jpg",StokAdetiBirimi="Adet"},
               new Urun() { Id = 37, Aciklama = "Plastik Köşebent", UrunKodu = "M-0001", KategoriId = 9, UrunAdi = "Köşebent", StokAdeti = 1900, UrunFiyati = 4, OlusturmaTarihi = DateTime.Now, UrunFoto = "köşebent.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 38, Aciklama = "Germe Civatası", UrunKodu = "M-0002", KategoriId = 9, UrunAdi = "Civata", StokAdeti = 1450, UrunFiyati = 1, OlusturmaTarihi = DateTime.Now , UrunFoto = "civata.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 39, Aciklama = "Düz Rondela", UrunKodu = "M-0003", KategoriId = 9, UrunAdi = "Rondela", StokAdeti = 1400, UrunFiyati = 2, OlusturmaTarihi = DateTime.Now , UrunFoto = "rondela.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 40, Aciklama = "Demir Çekiç", UrunKodu = "EM-0001", KategoriId = 10, UrunAdi = "Çekiç", StokAdeti = 60, UrunFiyati = 100, OlusturmaTarihi = DateTime.Now , UrunFoto = "çekiç.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 41, Aciklama = "Yıldız Tornavida", UrunKodu = "EM-0002", KategoriId = 10, UrunAdi = "Tornavida", StokAdeti = 100, UrunFiyati = 30, OlusturmaTarihi = DateTime.Now , UrunFoto = "tornavida.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 42, Aciklama = "KargaBurun Pense", UrunKodu = "EM-0003", KategoriId = 10, UrunAdi = "Pense", StokAdeti = 40, UrunFiyati = 50, OlusturmaTarihi = DateTime.Now , UrunFoto = "pense.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 43, Aciklama = "Darbeli Matkap", UrunKodu = "EM-0004", KategoriId = 10, UrunAdi = "Matkap", StokAdeti = 20, UrunFiyati = 200, OlusturmaTarihi = DateTime.Now , UrunFoto = "matkap.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 44, Aciklama = "Demir Testere", UrunKodu = "EM-0005", KategoriId = 10, UrunAdi = "Testere", StokAdeti = 50, UrunFiyati = 100, OlusturmaTarihi = DateTime.Now , UrunFoto = "testere.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 45, Aciklama = "Sabit", UrunKodu = "EM-0006", KategoriId = 10, UrunAdi = "Beton Mikseri", StokAdeti = 5, UrunFiyati = 13000, OlusturmaTarihi = DateTime.Now, UrunFoto = "beton mikseri.jpg", StokAdetiBirimi = "Adet" },
               new Urun() { Id = 46, Aciklama = "Endistriyel", UrunKodu = "EM-0007", KategoriId = 10, UrunAdi = "Taş Kesme Makinası", StokAdeti = 5, UrunFiyati = 5000, OlusturmaTarihi = DateTime.Now, UrunFoto = "taş kesme makinası.jpg", StokAdetiBirimi = "Adet" }
               );
           
        }
    }
}
