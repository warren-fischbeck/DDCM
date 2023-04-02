using System;
using System.Collections.Generic;
using System.Linq;
using FischbeckEnterprises.CharacterConverter;
using FischbeckEnterprises.CharacterConverter.Models;

namespace FischbeckEnterprises.CharacterConverterConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any letter other than y exits.");
            bool loop = true;
            do
            {
                string r = Console.ReadLine();
                if (r == "y")
                {
                    string skills = string.Empty;
                    CharacterModel characterModel = new GenerateRandomCharacter().CharacterModel;
                    Console.WriteLine($"{characterModel.PlayerName}'s character: {characterModel.CharacterName}");
                    Console.WriteLine($"Strenght:     {characterModel.Strength} - {characterModel.StrenghtModifier}");
                    Console.WriteLine($"Dexterity:    {characterModel.Dexterity} - {characterModel.DexterityModifier}");
                    Console.WriteLine($"Constitution: {characterModel.Constitution} - {characterModel.ConstitutionModifier}");
                    Console.WriteLine($"Intellegence: {characterModel.Intellegence} - {characterModel.IntellegenceModifier}");
                    Console.WriteLine($"Wisdom:       {characterModel.Wisdom} - {characterModel.WisdomModifier}");
                    Console.WriteLine($"Charisma:     {characterModel.Charisma} - {characterModel.CharismaModifier}");
                    Console.WriteLine($"Experience:   {characterModel.ExperiencePoints}");
                    Console.WriteLine($"Proficiency:  {characterModel.ProficiencyBonus}");
                    Console.WriteLine($"Total Level:  {characterModel.TotalLevels}");

                    foreach (var str in characterModel.Skills)
                    {
                        if (skills == string.Empty) { skills = $"{str.SkillName}"; }
                        else { skills += $",{str.SkillName}"; }
                    }
                    Console.WriteLine($"Total Skills:  {skills}");

                    Console.WriteLine("\nGo again?");
                }
                else { loop = false; }
            } while (loop);
        }
    }

}
