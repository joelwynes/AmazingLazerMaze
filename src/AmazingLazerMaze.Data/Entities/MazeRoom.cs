namespace JoelWynes.AmazingLazerMaze.Data.Entities
{
    public class MazeRoom
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public int MazeBoardId { get; set; }
        public virtual MazeBoard MazeBoard { get; set; }

        public int? MirrorId { get; set; }
        public virtual Mirror Mirror { get; set; }

        public int? LazerGunId { get; set; }
        public virtual LazerGun LazerGun { get; set; }

    }
}
