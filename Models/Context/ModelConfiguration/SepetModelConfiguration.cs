using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class SepetModelConfiguration : IEntityTypeConfiguration<Sepet>
    {
        public void Configure(EntityTypeBuilder<Sepet> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Kullanici) 
                   .WithOne(x => x.Sepet)
                   .HasForeignKey<Sepet>(x => x.KullaniciId);

            builder.HasMany(x => x.SepetItems).WithOne(x => x.Sepet).HasForeignKey(x => x.SepetId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
