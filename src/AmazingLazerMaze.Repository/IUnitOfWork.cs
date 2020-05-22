using JoelWynes.AmazingLazerMaze.Data.Entities;

namespace JoelWynes.AmazingLazerMaze.Repository
{
    public interface IUnitOfWork
    {
        IRepository<MazeBoard> MazeBoards { get; }
        IRepository<MazeRoom> MazeRooms { get; }
        IRepository<LazerGun> LazerGuns { get; }
        IRepository<Mirror> Mirrors { get; }
        void Commit();
    }
}
