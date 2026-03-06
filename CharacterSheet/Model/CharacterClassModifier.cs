using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.Model
{
    internal class CharacterClassModifier
    {
        public string ModifierName = string.Empty;
        public string ModifierDescription = string.Empty;
        public ModifierEnum ModifierType = ModifierEnum.None;
        public int ModifierValue = 0;
    }
}
