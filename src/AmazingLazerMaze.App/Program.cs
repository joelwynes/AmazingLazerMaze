using JoelWynes.AmazingLazerMaze.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using JoelWynes.AmazingLazerMaze.Services;
using AutoMapper;
using System.Reflection;
using JoelWynes.AmazingLazerMaze.Repository;

namespace JoelWynes.AmazingLazerMaze.UI
{
    class Program
    {

        static void Main(string[] args)
        {

            var serviceCollection = new ServiceCollection();

            // added dependency injection to demonstrate skills and knowledge of DI containers in .net core
            serviceCollection.AddLogging(builder => builder.AddConsole())
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IFileService, FileService>()
                .AddTransient<ILazerMazeService, LazerMazeService>()
                .BuildServiceProvider();

            // added an in-memory database to demonstrate skills and knowledge of EntityFrameworkCore inside Onion Architecture
            serviceCollection.AddDbContext<DatabaseContext>
                (options => options.UseInMemoryDatabase("AmazingLazerMazeDatabase"));

            // added AutoMapper to demonstrate usage of 3rd party NuGet library packages
            Assembly mappingAssembly = Assembly.Load(new AssemblyName("AmazingLazerMaze.Repository"));
            serviceCollection.AddAutoMapper(mappingAssembly);


            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();


            if (args != null && args.Length > 0)
            {
                var fileService = serviceProvider.GetService<IFileService>();
                var lazerMazeService = serviceProvider.GetService<ILazerMazeService>();

                var parsedModel = fileService.ParseDataFile(args[0]);
                lazerMazeService.SaveToDatabase(parsedModel);

                var mazeBoard = lazerMazeService.GetMazeBoard(1);

                var printModel = lazerMazeService.GetBoardDimensions(mazeBoard);

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine(printModel.BoardDemensions);

                Console.WriteLine();
                Console.WriteLine();

                foreach (string room in printModel.MirrorLocations)
                {
                    Console.WriteLine(room);
                }
                Console.WriteLine(printModel.LaserStartingPoint);

                Console.WriteLine();
                Console.WriteLine();


                // I ran out of time to get the calculations for lazer exit,
                // so enjoy the sound byte :)
                lazerMazeService.PewPewPew();
                Console.WriteLine("Pew Pew Pew! Laser was fired!");

                Console.ReadLine();
            }

            Console.WriteLine("The MazeData file is required.  Please reference the path to the file in the application arguments.");
        }
    }
}
