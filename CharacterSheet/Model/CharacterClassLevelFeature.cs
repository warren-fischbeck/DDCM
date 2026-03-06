using System;
using System.Collections.Generic;
using System.Text;

namespace CharacterSheet.Model
{
    internal class CharacterClassLevelFeature
    {
        public int ClassFeatureLevel = 0;
        public CharacterClassModifier? ClassLevelModifier = null;
        public string ClassLevelFeatureName=string.Empty;
        public string ClassLevelFeatureDescription = string.Empty;
    }
}
