using JoelWynes.AmazingLazerMaze.Services.Models;

namespace JoelWynes.AmazingLazerMaze.Services
{
    public interface IFileService
    {
        MazeDataFileModel ParseDataFile(string filePath);
    }
}
