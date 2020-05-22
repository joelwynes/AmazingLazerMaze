using System.Collections.Generic;

namespace JoelWynes.AmazingLazerMaze.Data.Entities
{
    public class MazeBoard
    {
        public int Id { get; set; }
        public int LazerGunId { get; set; }
        public virtual LazerGun LazerGun { get; set; }
        public ICollection<MazeRoom> MazeRooms { get; set; }
    }
}
