using JoelWynes.AmazingLazerMaze.Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JoelWynes.AmazingLazerMaze.Services
{
    public class FileService : IFileService
    {

        bool sizeDataIsParsed = false;
        bool mirrorDataIsParsed = false;
        bool lazerDataIsParsed = false;

        public MazeDataFileModel ParseDataFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The file could not be found.", filePath);
            }

            var mazeDataFileModel = new MazeDataFileModel();

            string lineValue;
            StreamReader file = new StreamReader(filePath);
            while ((lineValue = file.ReadLine()) != null)
            {
                bool isEndOfLine = lineValue.Trim().Equals("-1");
                if (!sizeDataIsParsed)
                {
                    ParseSizeData(lineValue, ref mazeDataFileModel, isEndOfLine);
                }
                else if (!mirrorDataIsParsed && sizeDataIsParsed)
                {
                    ParseMirrorData(lineValue, ref mazeDataFileModel, isEndOfLine);
                }
                else if (!lazerDataIsParsed && mirrorDataIsParsed)
                {
                    ParseLazerGunData(lineValue, ref mazeDataFileModel, isEndOfLine);
                }

            }

            return mazeDataFileModel;

        }

        private void ParseSizeData(string text, ref MazeDataFileModel mazeDataFileModel, bool isParsed)
        {
            sizeDataIsParsed = isParsed;

            if(!isParsed)
            {
                List<string> coordinates = text.Split(",").ToList();
                if (coordinates.Any() && coordinates.Count == 2)
                {
                    mazeDataFileModel.MazeSizeData = new Tuple<int, int>(int.Parse(coordinates[0]), int.Parse(coordinates[1]));
                }
            }          
        }

        private void ParseMirrorData(string text, ref MazeDataFileModel mazeDataFileModel, bool isParsed)
        {
            mirrorDataIsParsed = isParsed;
            if (!isParsed)
            {
                List<string> coordinates = text.Split(",").ToList();
                if (coordinates.Any() && coordinates.Count == 2)
                {
                    int x = int.Parse(coordinates[0]);
                    int y = int.Parse(coordinates[1].Substring(0, 1));
                    var types = new string(text.Where(Char.IsLetter).ToArray());
                    mazeDataFileModel.MirrorData.Add(new Tuple<int, int, string>(x, y, types.ToString()));
                }
            }
        }

        private void ParseLazerGunData(string text, ref MazeDataFileModel mazeDataFileModel, bool isParsed)
        {
            lazerDataIsParsed = isParsed;
            if (!isParsed)
            {
                List<string> coordinates = text.Split(",").ToList();
                if (coordinates.Any() && coordinates.Count == 2)
                {
                    int x = int.Parse(coordinates[0]);
                    int y = int.Parse(coordinates[1].Substring(0, 1));
                    var dir = new string(text.Where(Char.IsLetter).ToArray());
                    mazeDataFileModel.LazerGunData = new Tuple<int, int, string>(x, y, dir.ToString());
                }
            }            
        }
        
    }
}
