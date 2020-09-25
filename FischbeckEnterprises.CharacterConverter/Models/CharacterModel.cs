using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace FischbeckEnterprises.CharacterConverter.Models
{
    public class CharacterModel
    {
        /// <summary>
        /// charactername is the character name
        /// </summary>
        public string CharacterName { get; set; }
        
        /// <summary>
        /// playername is the character owner name
        /// </summary>
        public string PlayerName { get; set; }
        
        /// <summary>
        /// int value of the strength abilitiy score
        /// </summary>
        public int Strength { get; set; }
        
        /// <summary>
        /// int value of the strength modifier
        /// </summary>
        public int StrenghtModifier { get { return ConvertScoreIntoModifier(this.Strength); } }
        
        /// <summary>
        /// int value of the dexterity ability score
        /// </summary>
        public int Dexterity { get; set; }
        
        /// <summary>
        /// int value of the dexterity modifier
        /// </summary>
        public int DexterityModifier { get { return ConvertScoreIntoModifier(this.Dexterity); } }
       
        /// <summary>
        /// int value of the consitution ability score
        /// </summary>
        public int Constitution { get; set; }
       
        /// <summary>
        /// int value of the consitution modifier
        /// </summary>
        public int ConstitutionModifier { get { return ConvertScoreIntoModifier(this.Constitution); } }
        
        /// <summary>
        /// int value of the intelligence ability score
        /// </summary>
        public int Intellegence { get; set; }
        
        /// <summary>
        /// int value of the intelligence modifier
        /// </summary>
        public int IntellegenceModifier { get { return ConvertScoreIntoModifier(this.Intellegence); } }
        
        /// <summary>
        /// int value of the wisdom ability score
        /// </summary>
        public int Wisdom { get; set; }
        
        /// <summary>
        /// int value of the wisdom modifier
        /// </summary>
        public int WisdomModifier { get { return ConvertScoreIntoModifier(this.Wisdom); } }
        
        /// <summary>
        /// int value of the charisma ability score
        /// </summary>
        public int Charisma { get; set; }
        
        /// <summary>
        /// int value of the charisma modifier
        /// </summary>
        public int CharismaModifier { get { return ConvertScoreIntoModifier(this.Charisma); } }

        /// <summary>
        /// int value of the experience points the character has
        /// </summary>
        public int ExperiencePoints { get; set; }

        /// <summary>
        /// int value of the characters proficiency bonus
        /// </summary>
        public int ProficiencyBonus { get { return GenerateProficiencyBonus(this.ExperiencePoints); } }

        /// <summary>
        /// int value of the characters total levels
        /// </summary>
        public int TotalLevels { get { return GenerateCharacterLevel(this.ExperiencePoints); } }

        public List<SkillModel> Skills { get; } = new List<SkillModel>();

        /// <summary>
        /// calculates the ability score modifier for the passed in ability score
        /// </summary>
        /// <param name="AbilityScore">ability score to calculate</param>
        /// <returns>int value of the ability score modifier</returns>
        private int ConvertScoreIntoModifier(int AbilityScore) { return (AbilityScore - 10) / 2; }

        /// <summary>
        /// calculates the proficiency bonus for the passed in experience total
        /// </summary>
        /// <param name="ExperiencePoints">total experience points the character has aquired</param>
        /// <returns>int value of the characters calculated proficiency bonus</returns>
        private int GenerateProficiencyBonus(int ExperiencePoints)
        {
            if (ExperiencePoints < 6500) { return 2; }
            else if (ExperiencePoints >= 6500 && ExperiencePoints < 48000) { return 3; }
            else if (ExperiencePoints >= 48000 && ExperiencePoints < 120000) { return 4; }
            else if (ExperiencePoints >= 120000 && ExperiencePoints < 225000) { return 5; }
            else if (ExperiencePoints >= 225000) { return 6; }
            else { return 2; }
        }

        /// <summary>
        /// calculates the total character levels based on the passed in experience total
        /// </summary>
        /// <param name="ExperiencePoints">total experience points the character has aquired</param>
        /// <returns>int value of hte characters total character level</returns>
        private int GenerateCharacterLevel(int ExperiencePoints)
        {
            if (ExperiencePoints < 300) { return 1; }
            if (ExperiencePoints >= 300 && ExperiencePoints < 900) { return 2; }
            if (ExperiencePoints >= 900 && ExperiencePoints < 2700) { return 3; }
            if (ExperiencePoints >= 2700 && ExperiencePoints < 6500) { return 4; }
            if (ExperiencePoints >= 6500 && ExperiencePoints < 14000) { return 5; }
            if (ExperiencePoints >= 14000 && ExperiencePoints < 23000) { return 6; }
            if (ExperiencePoints >= 23000 && ExperiencePoints < 34000) { return 7; }
            if (ExperiencePoints >= 34000 && ExperiencePoints < 48000) { return 8; }
            if (ExperiencePoints >= 48000 && ExperiencePoints < 64000) { return 9; }
            if (ExperiencePoints >= 64000 && ExperiencePoints < 85000) { return 10; }
            if (ExperiencePoints >= 85000 && ExperiencePoints < 100000) { return 11; }
            if (ExperiencePoints >= 100000 && ExperiencePoints < 120000) { return 12; }
            if (ExperiencePoints >= 120000 && ExperiencePoints < 140000) { return 13; }
            if (ExperiencePoints >= 140000 && ExperiencePoints < 165000) { return 14; }
            if (ExperiencePoints >= 165000 && ExperiencePoints < 195000) { return 15; }
            if (ExperiencePoints >= 195000 && ExperiencePoints < 225000) { return 16; }
            if (ExperiencePoints >= 225000 && ExperiencePoints < 265000) { return 17; }
            if (ExperiencePoints >= 265000 && ExperiencePoints < 305000) { return 18; }
            if (ExperiencePoints >= 305000 && ExperiencePoints < 355000) { return 19; }
            if (ExperiencePoints >= 355000) { return 20; }
            else { return 0; }
        }
    }
}
