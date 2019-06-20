using FischbeckEnterprises.XML.Working;
using System;
using System.Collections.Generic;
using System.IO;

namespace FischbeckEnterprises.XML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pease wait...");
            string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\XML";
            FileInfo[] files = new DirectoryInfo(directory).GetFiles();
            foreach (FileInfo file in files)
            {
                XMLConvertFightClub converter = new XMLConvertFightClub(file.FullName);
                converter.Read();
                PrintablePlayerCharacter _character = converter._printablePlayerCharacter;
                new PDFCreator(_character);
            }
            Console.WriteLine("Finished building character sheets!");
            //Console.ReadLine();
        }
    }
}
