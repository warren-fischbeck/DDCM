using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        private void Abilities()
        {
            foreach(Character c in _pc.character)
            {
                string[] a = c.abilities.Split(',');
                _printablePlayerCharacter.Strength = Convert.ToInt32(a[0]);
                _printablePlayerCharacter.Dexterity = Convert.ToInt32(a[1]);
                _printablePlayerCharacter.Constitution = Convert.ToInt32(a[2]);
                _printablePlayerCharacter.Intelligence = Convert.ToInt32(a[3]);
                _printablePlayerCharacter.Wisdom = Convert.ToInt32(a[4]);
                _printablePlayerCharacter.Charisma = Convert.ToInt32(a[5]);

                foreach (Feat f in c.race.feat)
                {
                    if (f.modSpecified)
                    {
                        foreach (Mod m in f.mod)
                        {
                            AbilityModifier(m);
                        }
                    }
                }

                if (c.race.modSpecified)
                {
                    foreach (Mod m in c.race.mod)
                    {
                        AbilityModifier(m);
                    }
                }

                foreach (Feat f in c.feat)
                {
                    if (f.modSpecified)
                    {
                        foreach (Mod m in f.mod)
                        {
                            AbilityModifier(m);
                        }
                    }
                }

                foreach(PcClass pcClass in c.@class)
                {
                    if (pcClass.featSpecified)
                    {
                        foreach (Feat f in pcClass.feat)
                        {
                            if (f.modSpecified)
                            {
                                foreach (Mod m in f.mod)
                                {
                                    AbilityModifier(m);
                                }
                            }
                        }
                    }

                    if (pcClass.modSpecified)
                    {
                        foreach (Mod m in pcClass.mod)
                        {
                            AbilityModifier(m);
                        }
                    }
                }
            }

            _printablePlayerCharacter.StrengthModifier = AbilityModifier(_printablePlayerCharacter.Strength);
            _printablePlayerCharacter.DexterityModifier = AbilityModifier(_printablePlayerCharacter.Dexterity);
            _printablePlayerCharacter.ConstitutionModifier = AbilityModifier(_printablePlayerCharacter.Constitution);
            _printablePlayerCharacter.IntelligenceModifier = AbilityModifier(_printablePlayerCharacter.Intelligence);
            _printablePlayerCharacter.WisdomModifier = AbilityModifier(_printablePlayerCharacter.Wisdom);
            _printablePlayerCharacter.CharismaModifier = AbilityModifier(_printablePlayerCharacter.Charisma);
        }

        private int AbilityModifier(int Score)
        {
            return (Score - 10) / 2;
        }

        private void AbilityModifier (Mod mod)
        {
            switch (mod.type)
            {
                case 0: { _printablePlayerCharacter.Strength = _printablePlayerCharacter.Strength + mod.value; break; }
                case 1: { _printablePlayerCharacter.Dexterity = _printablePlayerCharacter.Dexterity + mod.value; break; }
                case 2: { _printablePlayerCharacter.Constitution = _printablePlayerCharacter.Constitution + mod.value; break; }
                case 3: { _printablePlayerCharacter.Intelligence = _printablePlayerCharacter.Intelligence + mod.value; break; }
                case 4: { _printablePlayerCharacter.Wisdom = _printablePlayerCharacter.Wisdom + mod.value; break; }
                case 5: { _printablePlayerCharacter.Charisma = _printablePlayerCharacter.Charisma + mod.value; break; }
                case 14: { _printablePlayerCharacter.PassivePerception = 10+_printablePlayerCharacter.Wisdom + mod.value; break; }
                default:
                    break;
            }
        }
    }
}
