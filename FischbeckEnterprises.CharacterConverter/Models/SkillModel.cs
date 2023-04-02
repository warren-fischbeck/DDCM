using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.CharacterConverter.Models
{
    public class SkillModel
    {
        /// <summary>
        /// enum value representing skill name
        /// </summary>
        public Skill SkillName { get; set; }

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
}
