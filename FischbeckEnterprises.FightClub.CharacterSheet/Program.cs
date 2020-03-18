using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter;
using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using FischbeckEnterprises.FightClub.CharacterSheet.Printable;

namespace FischbeckEnterprises.FightClub.CharacterSheet
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = $"{System.IO.Directory.GetCurrentDirectory()}\\FightClubXML";
            FileInfo[] files = new DirectoryInfo(directory).GetFiles();
            pc result = new pc();
            XmlSerializer serializer = new XmlSerializer(typeof(pc));

            foreach (FileInfo file in files)
            {
                using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                {
                    try
                    {
                        result = (pc)serializer.Deserialize(fileStream);
                        PrintablePlayerCharacter _character = new Converter(result).Build();
                        new PDFCreator(_character);
                     }
                    catch 
                    {
                    }
                }
            }
            Console.WriteLine("Finished building character sheets!");
            //Console.ReadLine();
        }
    }
}
