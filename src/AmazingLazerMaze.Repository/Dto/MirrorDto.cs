using JoelWynes.AmazingLazerMaze.Common;
using System.ComponentModel.DataAnnotations;

namespace JoelWynes.AmazingLazerMaze.Repository.Dto
{
    public class MirrorDto
    {
        public int Id { get; set; }
        public int MirrorReflectionId { get; set; }
        public int MirrorDirectionId { get; set; }

        [EnumDataType(typeof(MirrorReflections))]
        public MirrorReflections MirrorReflection { get; set; }

        [EnumDataType(typeof(MirrorLeanDirections))]
        public MirrorLeanDirections MirrorLeanDirection { get; set; }
    }
}
