using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.CharacterConverter.Models
{
    internal class DefaultSkills
    {
        /// <summary>
        /// Returns a Skillmodel list of skills for the character.
        /// </summary>
        public List<SkillModel> Skills { get; } = new List<SkillModel>();

        public DefaultSkills()
        {

        }

        /// <summary>
        /// Over-ride with list of passed in skills
        /// </summary>
        /// <param name="ProficentSkills">Lisk of Skill type passed in.</param>
        public DefaultSkills(List<Skill> ProficentSkills)
        {
            foreach (Skill skill in ProficentSkills)
            {
                AddSkill(skill, true);
            }
        }
        private void AddSkill(Skill SkillName, bool Proficiency)
        {
            Skills.Add(new SkillModel()
            {
                SkillName = SkillName,
                ProficiencyBonus = Proficiency,
                ExpertiseBonus = false
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
