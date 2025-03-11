using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class SiparisItemModelConfiguration : IEntityTypeConfiguration<SiparisItem>
    {
        public void Configure(EntityTypeBuilder<SiparisItem> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
