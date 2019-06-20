using System;
using System.Collections.Generic;
using System.Text;

namespace DDCM.Types
{
    class Base_Creature
    {
        public int Strength_Score { get; set; }
        public int Strenght_Modifier { get; set; }
        public int Dexterity_Score { get; set; }
        public int Dexterity_Modifier { get; set; }
        public int Constitution_Score { get; set; }
        public int Constitution_Modifier { get; set; }
        public int Intelligence_Score { get; set; }
        public int Intelligence_Modifier { get; set; }
        public int Wisdom_Score { get; set; }
        public int Wisdom_Modifier { get; set; }
        public int Charisma_Score { get; set; }
        public int Charisma_Modifier { get; set; }
    }

    class Base_Character : Base_Creature
    {
        public int Proficiency_Bonus { get; set; }
        public Int32 Experience_Points { get; set; }
        public string Character_Name { get; set; }
        public string Player_Name { get; set; }
    }
}
