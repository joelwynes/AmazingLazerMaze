using JoelWynes.AmazingLazerMaze.Common;
using System.ComponentModel.DataAnnotations;

namespace JoelWynes.AmazingLazerMaze.Data.Entities
{
    public class LazerGun
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public int LazerOrientationId { get; set; }

        [EnumDataType(typeof(LazerOrientations))]
        public LazerOrientations LazerOrientation { get; set; }

    }
}
