using FischbeckEnterprises.FightClub.XMLToOnenote.Core;
using System;
using System.IO;

namespace FischbeckEnterprises.FightClub.XMLToOnenote
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Gathering source files for build");
            string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\Sources";
            DataLoader dataLoader = new DataLoader(new DirectoryInfo(directory));
        }
    }
}
