using AutoMapper;
using JoelWynes.AmazingLazerMaze.Repository.Dto;
using JoelWynes.AmazingLazerMaze.Data.Entities;

namespace JoelWynes.AmazingLazerMaze.Repository.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<LazerGun, LazerGunDto>().ReverseMap();
            CreateMap<MazeBoard, MazeBoardDto>().ReverseMap();
            CreateMap<MazeRoom, MazeRoomDto>().ReverseMap();
            CreateMap<Mirror, MirrorDto>().ReverseMap();

        }
    }
}
