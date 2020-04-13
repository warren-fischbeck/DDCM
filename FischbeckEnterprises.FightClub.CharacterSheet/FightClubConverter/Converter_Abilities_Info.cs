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
    }
}
