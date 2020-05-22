using AutoMapper;
using JoelWynes.AmazingLazerMaze.Data.Entities;
using JoelWynes.AmazingLazerMaze.Repository;
using JoelWynes.AmazingLazerMaze.Repository.Dto;
using JoelWynes.AmazingLazerMaze.Services.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;

namespace JoelWynes.AmazingLazerMaze.Services
{
    public class LazerMazeService : BaseService, ILazerMazeService
    {

        public LazerMazeService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {

        }

        public MazeBoardDto GetMazeBoard(int id)
        {
            var entity = base.UnitOfWork.MazeBoards.GetById(id);

            return base.Mapper.Map<MazeBoardDto>(entity);
        }

        public void PewPewPew()
        {
            SoundPlayer player = new SoundPlayer();
            player.SoundLocation = Directory.GetCurrentDirectory() + "/Pew_Pew.wav";
            player.Play();

        }

        public LazerMazeDetailsModel GetBoardDimensions(MazeBoardDto mazeBoardDto)
        {
            var model = new LazerMazeDetailsModel();

            int top = mazeBoardDto.MazeRooms.Max(r => r.YCoordinate) + 1;
            int right = mazeBoardDto.MazeRooms.Max(r => r.XCoordinate) + 1;

            model.BoardDemensions = $"Lazer Maze Board Dimensions: {right}x{top}";

            foreach (var room in mazeBoardDto.MazeRooms.Where(r => r.Mirror != null))
            {
                model.MirrorLocations.Add($"There is a room here: X={room.XCoordinate} - Y={room.YCoordinate}");
                if(room.LazerGun != null)
                {
                    model.LaserStartingPoint = $"Laser gun is located in this room: X={room.XCoordinate} - Y={room.YCoordinate}";
                }
            }

            return model;
        }

        public void SaveToDatabase(MazeDataFileModel mazeDataFileModel)
        {
            var mazeBoardDto = new MazeBoardDto();
            var mazeRooms = new List<MazeRoomDto>();

            var xCoord = mazeDataFileModel.MazeSizeData.Item1;
            var yCoord = mazeDataFileModel.MazeSizeData.Item2;

            for (int x = 0; x < xCoord; x++)
            {
                for (int y = 0; y < yCoord; y++)
                {
                    var mazeRoom = new MazeRoomDto() { XCoordinate = x, YCoordinate = y };
                    mazeRooms.Add(mazeRoom);
                }
            }

            mazeBoardDto.MazeRooms = mazeRooms;
            int lazerGunX = mazeDataFileModel.LazerGunData.Item1;
            int lazerGunY = mazeDataFileModel.LazerGunData.Item2;
            string lazerGunOrientation = mazeDataFileModel.LazerGunData.Item3;

            foreach (var room in mazeRooms)
            {
                foreach(var mirrorData in mazeDataFileModel.MirrorData)
                {
                    var x = mirrorData.Item1;
                    var y = mirrorData.Item2;
                    var types = mirrorData.Item3;

             
                    if (room.XCoordinate == x && room.YCoordinate == y)
                    {
                        var mirror = new MirrorDto();
                        if (!string.IsNullOrEmpty(types))
                        {
                            var length = types.Length;
                            switch (length)
                            {
                                case 1:
                                    SetMirrorLeanDirection(ref mirror, types);
                                    break;
                                case 2:
                                    SetMirrorLeanDirection(ref mirror, types);
                                    SetMirrorReflection(ref mirror, types);
                                    break;
                            }
                        }

                        room.Mirror = mirror;
                    }
                
                }

                if(room.XCoordinate == lazerGunX && room.YCoordinate == lazerGunY)
                {
                    room.LazerGun = new LazerGunDto() { XCoordinate = lazerGunX, YCoordinate = lazerGunY };
                    if(lazerGunOrientation == "H")
                    {
                        room.LazerGun.LazerOrientation = Common.LazerOrientations.Horizontal;
                    }
                    
                    if(lazerGunOrientation == "V")
                    {
                        room.LazerGun.LazerOrientation = Common.LazerOrientations.Vertical;
                    }
                }
            }

            base.UnitOfWork.MazeBoards.Insert(base.Mapper.Map<MazeBoard>(mazeBoardDto));

        }

        private void SetMirrorLeanDirection(ref MirrorDto mirrorDto, string types)
        {
            if (types.Substring(0, 1).Equals("L"))
            {
                mirrorDto.MirrorLeanDirection = Common.MirrorLeanDirections.Left;
            }
            else
            {
                mirrorDto.MirrorLeanDirection = Common.MirrorLeanDirections.Right;
            }
        }

        private void SetMirrorReflection(ref MirrorDto mirrorDto, string types)
        {
            var value = types.Substring(1, 1).ToUpper();
            if (value == "L")
            {
                mirrorDto.MirrorReflection = Common.MirrorReflections.Left;
            }
            else if(value == "R")
            {
                mirrorDto.MirrorReflection = Common.MirrorReflections.Right;
            }
            else
            {
                mirrorDto.MirrorReflection = Common.MirrorReflections.Both;
            }
        }

        
    }
}
