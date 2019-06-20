using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.XML.Core
{
    public partial class Spell
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public School School { get; set; }
        public bool Ritual { get; set; }
        public string Time { get; set; }
        public string Range { get; set; }
        public List<Component> Component { get; set; }
        public string MaterialComponent { get; set; }
        public string Duration { get; set; }
        public string Text { get; set; }
        public Dice[] Roll { get; set; }
        public List<string> Class { get; set; }
    }

    public partial class SpellCasting
    {
        public string SpellCastingClass { get; set; }
        public string AbilityScore { get; set; }
        public int SpellAttachBonus { get; set; }
        public int SpellDC { get; set; }
        public List<Spell> SpellsKnown { get; set; }
        public int CantripsKnown { get; set; }
        public int _1stLevelSlots { get; set; }
        public int _2ndLevelSlots { get; set; }
        public int _3rdLevelSlots { get; set; }
        public int _4thLevelSlots { get; set; }
        public int _5thLevelSlots { get; set; }
        public int _6thLevelSlots { get; set; }
        public int _7thLevelSlots { get; set; }
        public int _8thLevelSlots { get; set; }
        public int _9thLevelSlots { get; set; }
        public int _10thLevelSlots { get; set; }
        public int SpellsPrepaired { get; set; }
    }
}
