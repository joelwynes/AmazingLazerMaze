using JoelWynes.AmazingLazerMaze.Data;
using JoelWynes.AmazingLazerMaze.Data.Entities;

namespace JoelWynes.AmazingLazerMaze.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext dbContext;
        private Repository<MazeBoard> mazeBoards;
        private Repository<MazeRoom> mazeRooms;
        private Repository<LazerGun> lazerGuns;
        private Repository<Mirror> mirrors;

        public UnitOfWork(DatabaseContext context)
        {
            dbContext = context;
        }

        public IRepository<MazeBoard> MazeBoards
        {
            get
            {
                return mazeBoards ??
                    (mazeBoards = new Repository<MazeBoard>(dbContext));
            }
        }

        public IRepository<MazeRoom> MazeRooms
        {
            get
            {
                return mazeRooms ??
                    (mazeRooms = new Repository<MazeRoom>(dbContext));
            }
        }

        public IRepository<LazerGun> LazerGuns
        {
            get
            {
                return lazerGuns ??
                    (lazerGuns = new Repository<LazerGun>(dbContext));
            }
        }

        public IRepository<Mirror> Mirrors
        {
            get
            {
                return mirrors ??
                    (mirrors = new Repository<Mirror>(dbContext));
            }
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
