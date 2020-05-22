using System.Collections.Generic;

namespace JoelWynes.AmazingLazerMaze.Repository.Dto
{
    public class MazeBoardDto
    {
        public int Id { get; set; }
        public ICollection<MazeRoomDto> MazeRooms { get; set; }

    }
}
