using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.FightClubConverter
{
    internal partial class Converter
    {
        internal void CharacterLevel()
        {
            string _characterLevel = string.Empty;
            string _hitDice = string.Empty;
            foreach (Character c in _pc.character)
            {
                foreach (PcClass pcClass in c.@class)
                {
                    string _dice = string.Empty;
                    switch (pcClass.hd)
                    {
                        case 0: { _dice = "6"; break; }
                        case 1: { _dice = "6"; break; }
                        case 2: { _dice = "8"; break; }
                        case 3: { _dice = "10"; break; }
                        case 4: { _dice = "12"; break; }
                        default:
                            break;
                    }
                    if (string.IsNullOrEmpty(_characterLevel))
                    {
                        _characterLevel = $"{pcClass.name} - {pcClass.level}";
                        _hitDice = $"{pcClass.level}d{_dice}";
                    }

                    else
                    {
                        _characterLevel = $"{_characterLevel} \\ {pcClass.name} - {pcClass.level}";
                        _hitDice = $"{_hitDice} \\ {pcClass.level}d{_dice}";
                    }
                }
            }
            _printablePlayerCharacter.ClassLevel = _characterLevel;
            _printablePlayerCharacter.HitDiceTotal = _hitDice;
            _printablePlayerCharacter.HitDice = "";
        }
    }
}