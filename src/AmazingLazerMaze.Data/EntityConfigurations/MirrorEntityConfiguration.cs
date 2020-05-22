using JoelWynes.AmazingLazerMaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoelWynes.AmazingLazerMaze.Data.EntityConfigurations
{
    public class MirrorEntityConfiguration : IEntityTypeConfiguration<Mirror>
    {
        public void Configure(EntityTypeBuilder<Mirror> builder)
        {
            builder.ToTable("Mirrors");

            builder.Property(e => e.Id).UseIdentityColumn(1, 1);

            builder.Property(e => e.MirrorDirectionId).IsRequired().HasColumnType("int");
            builder.Property(e => e.MirrorReflectionId).IsRequired().HasColumnType("int");

        }
    }
}
