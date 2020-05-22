using JoelWynes.AmazingLazerMaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoelWynes.AmazingLazerMaze.Data.EntityConfigurations
{
    public class MazeRoomEntityConfiguration : IEntityTypeConfiguration<MazeRoom>
    {
        public void Configure(EntityTypeBuilder<MazeRoom> builder)
        {
            builder.ToTable("MazeRooms");

            builder.Property(e => e.Id).UseIdentityColumn(1, 1);
            
            builder.Property(e => e.MazeBoardId).IsRequired().HasColumnType("int");
            builder.Property(e => e.XCoordinate).IsRequired().HasColumnType("int");
            builder.Property(e => e.YCoordinate).IsRequired().HasColumnType("int");

            builder.HasOne(s => s.MazeBoard).WithMany(g => g.MazeRooms).HasForeignKey(s => s.MazeBoardId);

        }
    }
}
