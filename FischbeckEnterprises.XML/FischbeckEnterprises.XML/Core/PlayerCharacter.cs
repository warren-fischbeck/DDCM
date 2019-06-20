using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{
    partial class PlayerCharacter
    {
        public string CharacterName { get; set; }
        public string PlayerName { get; set; }
        public int ExperiencePoints { get; set; }
        public int CharacterLevel { get; set; }
        public int ProficencyBonus { get; private set; }
        public List<Attributes> Attributes { get; set; }
        public List<Skills> Skills { get; set; }
        public string PersonalityTraits { get; set; }
        public string PersonalityBonds { get; set; }
        public string PersonalityIdeals { get; set; }
        public string PersonalityFlaws { get; set; }
        public int HitPointMax { get; set; }
        public int HitPointCurrent { get; set; }
        public int PassivePerception { get; set; }
        public int PassiveInititive { get; set; }
        public int PassiveInsight { get; set; }
        public int Inspiration { get; set; }


        public PlayerCharacter() { }
    }
}