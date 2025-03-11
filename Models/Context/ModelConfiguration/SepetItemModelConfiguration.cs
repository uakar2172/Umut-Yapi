using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UmutYapi.Models.Tablolar;

namespace UmutYapi.Models.Context.ModelConfiguration
{
    public class SepetItemModelConfiguration : IEntityTypeConfiguration<SepetItem>
    {
        public void Configure(EntityTypeBuilder<SepetItem> builder)
        {
            builder.HasKey(x => x.Id);

        }
    }
}
