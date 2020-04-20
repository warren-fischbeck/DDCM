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

            pc playerCharacter = new pc();
            data collectionPlayerCharacter = new data();

            XmlSerializer playerCharacterSerializer = new XmlSerializer(typeof(pc));
            XmlSerializer collectionPlayerCharacterSerializer = new XmlSerializer(typeof(data));

            foreach (FileInfo file in files)
            {
                try
                {
                    using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                    {

                        playerCharacter = (pc)playerCharacterSerializer.Deserialize(fileStream);
                        PrintablePlayerCharacter _playerCharacter = new FightClubConverter.Converter(playerCharacter).Build();

                    }
                }
                catch (System.InvalidOperationException)
                {
                    using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                    {
                        collectionPlayerCharacter = (data)collectionPlayerCharacterSerializer.Deserialize(fileStream);
                    }
                }
            }
            Console.WriteLine("Finished building character sheets!");
        }
    }
}