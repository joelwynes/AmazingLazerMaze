using JoelWynes.AmazingLazerMaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoelWynes.AmazingLazerMaze.Data.EntityConfigurations
{
    public class LazerGunEntityConfiguration : IEntityTypeConfiguration<LazerGun>
    {
        public void Configure(EntityTypeBuilder<LazerGun> builder)
        {
            builder.ToTable("LazerGuns");

            builder.Property(e => e.Id).UseIdentityColumn(1, 1);
            builder.Property(e => e.XCoordinate).IsRequired().HasColumnType("int");
            builder.Property(e => e.YCoordinate).IsRequired().HasColumnType("int");
            builder.Property(e => e.LazerOrientationId).IsRequired().HasColumnType("int");

        }
    }
}
