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
                int[] tempProficiency = CollectProficiency(file.FullName);
                using (FileStream fileStream = new FileStream(file.FullName, FileMode.Open))
                {
                    try
                    {
                        result = (pc)serializer.Deserialize(fileStream);
                        if (result.character[0].@class[0].proficiency.Length < 1)
                            result.character[0].@class[0].proficiency = tempProficiency;
                        PrintablePlayerCharacter _character = new Converter().Build(result);
                        new PDFCreator(_character);
                    }
                    catch 
                    {
                    }
                }
            }
            Console.WriteLine("Finished building character sheets!");
            Console.ReadLine();

        }

        static private int[] CollectProficiency (string _File) 
        { 
            XmlDocument doc = new XmlDocument();
            doc.Load(_File);
            XmlNodeList list = doc.SelectNodes("pc/character/class/proficiency");
            int[] classProfic = new int[0];
            foreach (XmlNode node in list)
            {
                int addto = Convert.ToInt32(node.InnerText);
                int[] newArray = new int[classProfic.Length + 1];
                classProfic.CopyTo(newArray, 1);
                newArray[0] = addto;
                classProfic = newArray;
            }
            return classProfic;
        }
    }
}
