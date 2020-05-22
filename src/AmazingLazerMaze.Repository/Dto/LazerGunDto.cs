using JoelWynes.AmazingLazerMaze.Common;
using System.ComponentModel.DataAnnotations;

namespace JoelWynes.AmazingLazerMaze.Repository.Dto
{
    public class LazerGunDto
    {
        public int Id { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }

        public int LazerOrientationId { get; set; }

        [EnumDataType(typeof(LazerOrientations))]
        public LazerOrientations LazerOrientation { get; set; }


    }
}
