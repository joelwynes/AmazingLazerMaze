using System;
using System.Collections.Generic;

namespace JoelWynes.AmazingLazerMaze.Services.Models
{
    public class MazeDataFileModel
    {

        public MazeDataFileModel()
        {
            MirrorData = new List<Tuple<int, int, string>>();
        }

        public Tuple<int,int> MazeSizeData { get; set; }
        public List<Tuple<int, int, string>> MirrorData { get; set; }
        public Tuple<int, int, string> LazerGunData { get; set; }
    }
}
