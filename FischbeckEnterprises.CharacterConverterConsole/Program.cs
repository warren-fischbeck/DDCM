using System;
using System.Collections.Generic;
using System.Linq;
using FischbeckEnterprises.CharacterConverter;

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
                    CharacterConverter.Models.CharacterModel characterModel = new CharacterConverter.Models.CharacterModel()
                    {
                        CharacterName = "Test Character",
                        PlayerName = "Warren Fischbeck",
                        Charisma = new RandomAbility().AbilityScroe,
                        Constitution = new RandomAbility().AbilityScroe,
                        Dexterity = new RandomAbility().AbilityScroe,
                        Intellegence = new RandomAbility().AbilityScroe,
                        Strength = new RandomAbility().AbilityScroe,
                        Wisdom = new RandomAbility().AbilityScroe
                    };
                    Console.WriteLine($"{characterModel.PlayerName}'s character: {characterModel.CharacterName}");
                    Console.WriteLine($"Strenght:     {characterModel.Strength} - {characterModel.StrenghtModifier}");
                    Console.WriteLine($"Dexterity:    {characterModel.Dexterity} - {characterModel.DexterityModifier}");
                    Console.WriteLine($"Constitution: {characterModel.Constitution} - {characterModel.ConstitutionModifier}");
                    Console.WriteLine($"Intellegence: {characterModel.Intellegence} - {characterModel.IntellegenceModifier}");
                    Console.WriteLine($"Wisdom:       {characterModel.Wisdom} - {characterModel.WisdomModifier}");
                    Console.WriteLine($"Charisma:     {characterModel.Charisma} - {characterModel.CharismaModifier}");
                    Console.WriteLine("\nGo again?");
                }
                else { loop = false; }
            } while (loop);
        }
    }

    class RandomAbility
    {
        private Random random = new Random();
        
        
        private List<int> sum;

        private int sumResult;
        public int AbilityScroe { get { return sumResult; } }

        public RandomAbility()
        {
            sum = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                sum.Add(random.Next(1, 7));
            }
            sumResult = GenerateAbilityScore();
        }

        private int GenerateAbilityScore()
        {
            int lowest = sum.Min();
            sum.Remove(lowest);
            return sum.Sum();
        }
    }
}
