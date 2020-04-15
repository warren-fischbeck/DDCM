using FischbeckEnterprises.FightClub.CharacterSheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FischbeckEnterprises.FightClub.CharacterSheet.Converter
{
    partial class XMLConverter
    {
        private void ClassAndLevel()
        {
            string _classAndLevel = string.Empty;

            _pc.character.ForEach(e => e.@class.ForEach(b => CAndL(ref _classAndLevel, b.name, b.level)));
            _printablePlayerCharacter.ClassLevel = _classAndLevel;
        }

        private void CAndL(ref string _CAndL, string name, int level)
        {
            if (level == 0) { level++; }
            if (string.IsNullOrEmpty(_CAndL))
                _CAndL = $"{name} - {level}";
            else
                _CAndL += $", {name} - {level}";
        }
    }
}
