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
        /// calculates the ability score modifier for the passed in ability score
        /// </summary>
        /// <param name="AbilityScore">ability score to calculate</param>
        /// <returns>int value of the ability score modifier</returns>
        private int ConvertScoreIntoModifier(int AbilityScore) { return (AbilityScore - 10) / 2; }
    }
}
