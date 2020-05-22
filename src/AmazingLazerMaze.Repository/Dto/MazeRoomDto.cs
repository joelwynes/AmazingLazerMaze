namespace JoelWynes.AmazingLazerMaze.Repository.Dto
{
    public class MazeRoomDto
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public int MazeBoardId { get; set; }
        public virtual MazeBoardDto MazeBoard { get; set; }

        public int? MirrorId { get; set; }
        public virtual MirrorDto Mirror { get; set; }

        public int? LazerGunId { get; set; }
        public virtual LazerGunDto LazerGun { get; set; }

    }
}
