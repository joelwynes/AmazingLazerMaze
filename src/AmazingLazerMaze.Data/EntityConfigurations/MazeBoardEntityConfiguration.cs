using JoelWynes.AmazingLazerMaze.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JoelWynes.AmazingLazerMaze.Data.EntityConfigurations
{
    public class MazeBoardEntityConfiguration : IEntityTypeConfiguration<MazeBoard>
    {
        public void Configure(EntityTypeBuilder<MazeBoard> builder)
        {
            builder.ToTable("MazeBoards");

            builder.Property(e => e.Id).UseIdentityColumn(1, 1);

        }
    }
}
