using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class SiparisModelConfiguration : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.SiparisItems)
                   .WithOne(x => x.Siparis)
                   .HasForeignKey(x => x.SiparisId);
        }
    }
}
