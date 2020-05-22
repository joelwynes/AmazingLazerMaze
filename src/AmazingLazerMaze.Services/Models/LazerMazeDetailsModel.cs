using System.Collections.Generic;

namespace JoelWynes.AmazingLazerMaze.Services.Models
{
    public class LazerMazeDetailsModel
    {
        public LazerMazeDetailsModel()
        {
            MirrorLocations = new List<string>();
        }
        public string BoardDemensions { get; set; }
        public string LaserStartingPoint { get; set; }
        public List<string> MirrorLocations { get; set; }
    }
}
