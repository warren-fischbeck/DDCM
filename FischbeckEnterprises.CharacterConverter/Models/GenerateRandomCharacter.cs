using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.CharacterConverter.Models
{
    public class GenerateRandomCharacter
    {
        /// <summary>
        /// holds the charactermodel for the random character
        /// </summary>
        public CharacterModel CharacterModel { get; }
        
        /// <summary>
        /// public constructor that builds a random character
        /// </summary>
        public GenerateRandomCharacter()
        {
            CharacterModel = new CharacterModel()
            {
                CharacterName = "Test Character",
                PlayerName = "Warren Fischbeck",
                Charisma = new GenerateRandomAbility().AbilityScore,
                Constitution = new GenerateRandomAbility().AbilityScore,
                Dexterity = new GenerateRandomAbility().AbilityScore,
                Intellegence = new GenerateRandomAbility().AbilityScore,
                Strength = new GenerateRandomAbility().AbilityScore,
                Wisdom = new GenerateRandomAbility().AbilityScore,
                ExperiencePoints = new Random().Next(0, 355000)
            };
        }
    }
    internal class GenerateRandomAbility
    {
        /// <summary>
        /// holds a random object
        /// </summary>
        private Random random = new Random();

        /// <summary>
        /// list of int that represents the d6 roll when creating random characters
        /// </summary>
        private List<int> rolls;

        /// <summary>
        /// private field for the total after dropping the lowest rolled d6
        /// </summary>
        private int rollResult;
        public int AbilityScore { get { return rollResult; } }

        /// <summary>
        /// public constructor that will generate one ability score
        /// </summary>
        public GenerateRandomAbility()
        {
            rolls = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                rolls.Add(random.Next(1, 7));
            }
            rollResult = GenerateAbilityScore();
        }

        /// <summary>
        /// private method that drops the lowest roll on the ability score
        /// </summary>
        /// <returns>int value returned for the rolled 4d6 dropping the lowest d6</returns>
        private int GenerateAbilityScore()
        {
            int lowest = rolls.Min();
            rolls.Remove(lowest);
            return rolls.Sum();
        }
    }

}
