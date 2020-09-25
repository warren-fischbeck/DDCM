using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.CharacterConverter.Models
{
    public class SkillModel
    {
        /// <summary>
        /// string value representing skill name
        /// </summary>
        public string SkillName { get; set; }
        
        /// <summary>
        /// bool value if skill has a proficiency bonus for this character
        /// </summary>
        public bool ProficiencyBonus { get; set; }
        
        /// <summary>
        /// bool value if skill has an expertise bonus for this character
        /// </summary>
        public bool ExpertiseBonus { get; set; }
        
        /// <summary>
        /// int value representing the default ability score that the skill is attached to
        /// </summary>
        public int AbilityScore { get; set; }
        
        /// <summary>
        /// int value of the default ability score modifier that the skill is attached to
        /// </summary>
        public int AbilityScoreModifier { get; set; }
    }

    class DefaultSkills
    {
        public List<SkillModel> Skills { get; }

        public DefaultSkills()
        {

        }
        public DefaultSkills(List<string> ProficentSkills)
        {
            foreach (var skill in ProficentSkills)
            {
                AddSkill(skill, true);
            }
        }
        private void AddSkill(string SkillName, int Ability)
        {
            Skills.Add(new SkillModel()
            {
                SkillName = SkillName,
                AbilityScore = Ability,
                AbilityScoreModifier = ConvertScoreIntoModifier(Ability),
                ProficiencyBonus = false,
                ExpertiseBonus = false
            });
        }
        private void AddSkill(string SkillName, bool Proficiency)
        {
            Skills.Add(new SkillModel()
            {
                SkillName = SkillName,
                ProficiencyBonus = Proficiency,
                ExpertiseBonus = false
            });
        }
        private void AddSkill(string SkillName, int Ability, bool Proficiency)
        {
            Skills.Add(new SkillModel()
            {
                SkillName = SkillName,
                AbilityScore = Ability,
                AbilityScoreModifier = ConvertScoreIntoModifier(Ability),
                ProficiencyBonus = Proficiency,
                ExpertiseBonus = false
            });
        }
        private void AddSkill(string SkillName, int Ability, bool Proficiency, bool Expertise)
        {
            Skills.Add(new SkillModel()
            {
                SkillName = SkillName,
                AbilityScore = Ability,
                AbilityScoreModifier = ConvertScoreIntoModifier(Ability),
                ProficiencyBonus = Proficiency,
                ExpertiseBonus = Expertise
            });
        }

        /// <summary>
        /// calculates the ability score modifier for the passed in ability score
        /// </summary>
        /// <param name="AbilityScore">ability score to calculate</param>
        /// <returns>int value of the ability score modifier</returns>
        private int ConvertScoreIntoModifier(int AbilityScore) { return (AbilityScore - 10) / 2; }
    }
}
