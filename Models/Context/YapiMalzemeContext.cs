using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UmutYapi.Models.Context.ModelConfiguration;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context
{
    public class YapiMalzemeContext : IdentityDbContext<Kullanici, UserRole, Guid>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=YapiMalzemeDb;Integrated Security=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UrunKategoriModelConfiguration());
            builder.ApplyConfiguration(new UrunModelConfiguration());
            builder.ApplyConfiguration(new SepetItemModelConfiguration());
            builder.ApplyConfiguration(new SepetModelConfiguration());
            builder.ApplyConfiguration(new SiparisModelConfiguration());
            builder.ApplyConfiguration(new KullaniciModelConfiguration());
            builder.ApplyConfiguration(new SiparisItemModelConfiguration());
        }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<UrunKategori> UrunKategoriler { get; set; }
        public DbSet<Sepet> Sepetler { get; set; }
        public DbSet<SepetItem> SepetItemler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisItem> SiparisItems { get; set; }
    }
}
