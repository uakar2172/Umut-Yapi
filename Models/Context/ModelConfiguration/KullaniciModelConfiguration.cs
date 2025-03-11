using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class KullaniciModelConfiguration : IEntityTypeConfiguration<Kullanici>
    {
        public void Configure(EntityTypeBuilder<Kullanici> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Sepet) // Sepet ile ilişki tanımlandı
                   .WithOne(x => x.Kullanici)
                   .HasForeignKey<Kullanici>(x => x.SepetId)
                   .IsRequired(false);

            builder.HasMany(x => x.Siparisler)
                   .WithOne(x => x.Kullanici)
                   .HasForeignKey(x => x.KullaniciId)
                   .IsRequired(false);
        }
    }
}
