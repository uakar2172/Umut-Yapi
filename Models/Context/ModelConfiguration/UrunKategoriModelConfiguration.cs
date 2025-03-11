using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class UrunKategoriModelConfiguration : IEntityTypeConfiguration<UrunKategori>
    {
        public void Configure(EntityTypeBuilder<UrunKategori> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.KategoriAdi).HasMaxLength(200);

            builder.HasMany(x => x.Urunler).WithOne(x => x.Kategori).HasForeignKey(x => x.KategoriId);

            builder.HasData(
                new UrunKategori() { Id = 1, KategoriAdi = "Beton", OlusturmaTarihi = DateTime.Now},
                new UrunKategori() { Id = 2, KategoriAdi = "Yalıtım", OlusturmaTarihi = DateTime.Now},
                new UrunKategori() { Id = 3, KategoriAdi = "DuvarDöseme", OlusturmaTarihi = DateTime.Now},
                new UrunKategori() { Id = 4, KategoriAdi = "KapıPencere", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 5, KategoriAdi = "BoyaKaplama", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 6, KategoriAdi = "AhşapMarangoz", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 7, KategoriAdi = "Elektrik", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 8, KategoriAdi = "SıhhiTesisat", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 9, KategoriAdi = "Metal", OlusturmaTarihi = DateTime.Now },
                new UrunKategori() { Id = 10, KategoriAdi = "ELveMakina", OlusturmaTarihi = DateTime.Now }
                );
        }
    }
}
