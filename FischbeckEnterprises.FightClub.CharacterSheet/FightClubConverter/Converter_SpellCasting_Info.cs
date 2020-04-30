using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using FischbeckEnterprises.FightClub.CharacterSheet.Printable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void BuildSpellCasting()
        {
            List<PcClass> pcClasses = _pc.character.FirstOrDefault().@class.ToList();
            Race race = _pc.character.FirstOrDefault().race;
            if (race.spellSpecified)
            {
                SpellCasting racialSpells = new SpellCasting();
                racialSpells.SpellCastingClass = race.name;
                XmlSpellAbility(racialSpells, race.spellAbility);
                foreach (Models.Spell spell in race.spell)
                {
                    racialSpells.SpellsKnown.Add(XMLSpellConvert(spell));
                }
                _printablePlayerCharacter.SpellCasting.Add(racialSpells);
            }
            foreach (PcClass p in pcClasses)
            {
                if (p.spellSpecified)
                {
                    SpellCasting spells = new SpellCasting();
                    spells.SpellCastingClass = p.name;
                    XmlSpellAbility(spells, p.spellAbility);
                    XmlSlotConverter(spells, p.slots.Split(','));
                    foreach (Models.Spell spell in p.spell)
                    {
                        spells.SpellsKnown.Add(XMLSpellConvert(spell));
                    }
                    _printablePlayerCharacter.SpellCasting.Add(spells);
                }
            }
        }

        private void XmlSlotConverter(SpellCasting spellCasting, string[] SpellSlots)
        {
            for (int i = 0; i < SpellSlots.Length; i++)
            {
                if (string.IsNullOrEmpty(SpellSlots[i])) { SpellSlots[i] = "0"; }
                int number = Convert.ToInt16(SpellSlots[i]);
                switch (i)
                {
                    case 0: { spellCasting.CantripsKnown = number; break; }
                    case 1: { spellCasting._1stLevelSlots = number; break; }
                    case 2: { spellCasting._2ndLevelSlots = number; break; }
                    case 3: { spellCasting._3rdLevelSlots = number; break; }
                    case 4: { spellCasting._4thLevelSlots = number; break; }
                    case 5: { spellCasting._5thLevelSlots = number; break; }
                    case 6: { spellCasting._6thLevelSlots = number; break; }
                    case 7: { spellCasting._7thLevelSlots = number; break; }
                    case 8: { spellCasting._8thLevelSlots = number; break; }
                    case 9: { spellCasting._9thLevelSlots = number; break; }
                    case 10: { spellCasting._10thLevelSlots = number; break; }
                    default:
                        break;
                }
            }
        }

        private void XmlSpellAbility(SpellCasting spellCasting, int spellAbility)
        {
            switch (spellAbility)
            {
                case 0:
                    {
                        spellCasting.AbilityScore = "STRENGTH";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.StrengthModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.StrengthModifier;
                        break;
                    }
                case 1:
                    {
                        spellCasting.AbilityScore = "DEXTERITY";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.DexterityModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.DexterityModifier;
                        break;
                    }
                case 2:
                    {
                        spellCasting.AbilityScore = "CONSTITUTION";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.ConstitutionModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.ConstitutionModifier;
                        break;
                    }
                case 3:
                    {
                        spellCasting.AbilityScore = "INTELLEGENCE";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.IntelligenceModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.IntelligenceModifier;
                        break;
                    }
                case 4:
                    {
                        spellCasting.AbilityScore = "WISDOM";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.WisdomModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.WisdomModifier;
                        break;
                    }
                case 5:
                    {
                        spellCasting.AbilityScore = "CHARISMA";
                        spellCasting.SpellAttachBonus = _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.CharismaModifier;
                        spellCasting.SpellDC = 8 + _printablePlayerCharacter.ProficencyBonus + _printablePlayerCharacter.CharismaModifier;
                        break;
                    }
                default: break;
            }
        }

        private Printable.Spell XMLSpellConvert(Models.Spell spell)
        {
            Printable.Spell s = new Printable.Spell();
            List<Component> componets = new List<Component>();
            if (spell.vSpecified)
                componets.Add(Component.V);

            if (spell.sSpecified)
                componets.Add(Component.S);

            if (spell.mSpecified)
                componets.Add(Component.M);

            s.Component = componets;
            s.Duration = spell.duration;
            s.Level = spell.level;
            s.Name = spell.name;
            s.Range = spell.range;
            foreach (string t in spell.text)
            {
                s.Text += t;
            }
            s.Time = spell.time;
            s.prepared = spell.preparedSpecified;
            s.School = (School)spell.school;
            return s;
        }
    }
}