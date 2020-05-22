using JoelWynes.AmazingLazerMaze.Repository.Dto;
using JoelWynes.AmazingLazerMaze.Services.Models;


namespace JoelWynes.AmazingLazerMaze.Services
{
    public interface ILazerMazeService
    {
        void SaveToDatabase(MazeDataFileModel mazeDataFileModel);
        MazeBoardDto GetMazeBoard(int id);
        void PewPewPew();
        LazerMazeDetailsModel GetBoardDimensions(MazeBoardDto mazeBoardDto);
    }
}
